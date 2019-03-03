using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmDoContingency : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        List<Contract> allContracts;

        public FrmDoContingency()
        {
            InitializeComponent();
        }

        private void FrmDoContingency_Load(object sender, EventArgs e)
        {
            allContracts = _facade.GetTopContract();
            _StylingComponents();
            _FillContractsCB(allContracts);
        }

        private void _StylingComponents()
        {
            //#Colunas de Alíquotas das Verbas de Contingência
            ColumnHeader colAli1 = new ColumnHeader();
            colAli1.Text = "Nome da Verba";
            this.listContFundsAliquots.Columns.Add(colAli1);
            ColumnHeader colAli2 = new ColumnHeader();
            colAli2.Text = "Valor da Alíquota";
            this.listContFundsAliquots.Columns.Add(colAli2);
            this.listContFundsAliquots.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listContFundsAliquots.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void _FillContractsCB(List<Contract> contracts)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = contracts;
            this.cbContracts.DataSource = source;
            this.cbContracts.DisplayMember = "Name";
            this.cbContracts.ValueMember = "Id";
        }

        private void cbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentContract = this.cbContracts.SelectedItem as Contract;
            _RemoveElements();
            _LoadingContractInfo(currentContract);
            _GetEmployeesInContract(currentContract);
        }

        private void _RemoveElements()
        {
            this.listContFundsAliquots.Items.Clear();
            this.treeMonetaryFunds.Nodes.Clear();
        }

        private void _LoadingContractInfo(Contract ct)
        {
            this.txtContractName.Text = ct.Name;
            this.txtContractDescription.Text = ct.Description;
            foreach (ContingencyAliquot ca in ct.ContingencyAliquot)
            {
                ListViewItem item;
                item = new ListViewItem();
                item.Text = ca.ContingencyFund.Name;
                item.SubItems.Add(ca.Value.ToString());
                this.listContFundsAliquots.Items.Add(item);
            }
            _StylingTreeView(ct.MonetaryFunds);
        }

        private void _StylingTreeView(List<MonetaryFund> monetaryFunds)
        {
            //this.treeView1.Nodes
            TreeNode treeNode;
            TreeNode subTreeNode;
            foreach (var mf in monetaryFunds)
            {
                if (mf.ExtraFunds.Count > 0)
                {
                    TreeNode[] arraySub = new TreeNode[mf.ExtraFunds.Count];
                    for (int i = 0; i < arraySub.Length; i++)
                    {
                        subTreeNode = new TreeNode(mf.ExtraFunds[i].Name);
                        subTreeNode.Tag = mf.ExtraFunds[i];
                        arraySub[i] = subTreeNode;
                    }
                    treeNode = new TreeNode(mf.Name, arraySub);
                    treeNode.Tag = mf;
                }
                else
                {
                    treeNode = new TreeNode(mf.Name);
                    treeNode.Tag = mf;
                }

                treeMonetaryFunds.Nodes.Add(treeNode);
            }
        }

        private void _GetEmployeesInContract(Contract ct)
        {
            this.txtEmployeesCount.Text =  _facade.GetEmployeesCountByContract(ct).ToString();
        }

        private void btnDoConting_Click(object sender, EventArgs e)
        {
            MonetaryFund selectedMF = _GetSelectedMonetaryFund();
            if (selectedMF == null)
            {
                MessageBox.Show("Selecione apenas uma verba monetária.", "Verba Monetária", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                List<ContingencyPast> contPasts = _facade.ProcessContingencyContract(this.currentContract, selectedMF);
                this.dgvContResult.DataSource = contPasts;
            }
            //ContingencyPast contract = _GetValidContract();
            //if (contract != null)
            //{
            //    try
            //    {
            //        //desabilita os botões enquanto a tarefa é executada.
            //        _EnableAllButtons(false);
            //        bgWorkDatabase.RunWorkerAsync(contPast);

            //        //define a progressBar para Marquee
            //        pbContingency.Style = ProgressBarStyle.Marquee;
            //        pbContingency.MarqueeAnimationSpeed = 6;

            //        //informa que a tarefa esta sendo executada.
            //        this.lblWaiting.Text = "Aguarde, salvando na base de dados...";
            //    }

            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void bgWorkDatabase_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //ContingencyPast contPast = (ContingencyPast)e.Argument;
            //try
            //{
            //    long retId = _facade.InsertContingencyPast(contPast);
            //    if (retId > 0)
            //    {
            //        MessageBox.Show("Contrato inserido na base de dados com sucesso. Id Retornado: " + retId, "Contrato Inserido",
            //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ops, ocorreu um erro e o contrato não foi inserido!", "Erro ao inserir contrato na base de dados",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erro: " + ex.Message, "Erro ao salvar na base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void bgWorkDatabase_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //desabilita os botões enquanto a tarefa é executada.
            _EnableAllButtons(true);

            //Carrega todo progressbar.
            pbContingency.MarqueeAnimationSpeed = 0;
            pbContingency.Style = ProgressBarStyle.Blocks;
            pbContingency.Value = 100;

            //informa que a tarefa esta sendo executada.
            this.lblWaiting.Text = "";
        }

        private void _EnableAllButtons(bool v)
        {
            this.cbContracts.Enabled = v;
            this.btnDoConting.Enabled = v;
        }

        private void treeMonetaryFunds_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = true;
                }
            }
        }

        private MonetaryFund _GetSelectedMonetaryFund()
        {
            int checkeds = 0;
            //Varrendo o node pai (verbas monetárias)
            MonetaryFund retMF = null;
            MonetaryFund currentMF;
            foreach (TreeNode mfNode in this.treeMonetaryFunds.Nodes)
            {
                if (mfNode.Checked)
                {
                    checkeds++;
                    currentMF = (MonetaryFund)mfNode.Tag;
                    retMF = new MonetaryFund(currentMF.Id, currentMF.Name, currentMF.Primal);
                    //varrendo nodes filhos, se houver(verbas adicionais)
                    foreach (TreeNode efNode in mfNode.Nodes)
                    {
                        //Se o node filho não tiver marcado, removo ele da List do objeto MonetaryFund que vai ser retornada
                        if (efNode.Checked)
                        {
                            retMF.ExtraFunds.Add((ExtraFund)efNode.Tag);
                        }
                    }
                }
            }
            if (checkeds != 1)
                return null;
            else 
                return retMF;
        }
    }
}
