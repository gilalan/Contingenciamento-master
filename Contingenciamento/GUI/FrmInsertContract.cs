using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertContract : Form
    {
        Facade _facade = new Facade();
        List<ContingencyFund> contingencyFunds;
        List<MonetaryFund> monetaryFunds;
        HashSet<ContingencyAliquot> contingencyFundsAliquots = new HashSet<ContingencyAliquot>(new ContingencyAliquotComparer());
        HashSet<MonetaryFund> monetaryFundsSet = new HashSet<MonetaryFund>(new MonetaryFundComparer());
        String aliqPattern = "[0-9]{1,2},[0-9]{2}";
        HashSet<Department> allDeptCodes = new HashSet<Department>(new DepartmentComparer());

        public FrmInsertContract()
        {
            InitializeComponent();
        }

        private void FrmInsertContract_Load(object sender, EventArgs e)
        {
            //Preenchendo as verbas e populando as checkBoxes
            contingencyFunds = _facade.GetTopContigencyFund();
            monetaryFunds = _facade.GetTopMonetaryFund();
            _FillCbBox(contingencyFunds);
            _StylingListViews();
            _StylingTreeView();
        }        

        private void _FillCbBox(List<ContingencyFund> contingencyFunds)
        {
            var source = new BindingSource();
            source.DataSource = contingencyFunds;
            this.cbContigencyFunds.DataSource = source;
            this.cbContigencyFunds.DisplayMember = "Name";
            this.cbContigencyFunds.ValueMember = "Id";
        }

        private void _StylingListViews()
        {
            //#Colunas de Departamentos
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "Código do Departamento";
            this.listDepts.Columns.Add(c1);
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Nome do Departamento";
            this.listDepts.Columns.Add(c2);
            this.listDepts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listDepts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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

        private void _StylingTreeView()
        {
            //this.treeView1.Nodes
            TreeNode treeNode;
            TreeNode subTreeNode;
            foreach (var mf in monetaryFunds)
            {
                if (mf.ExtraFunds.Count > 0)
                {
                    TreeNode[] arraySub = new TreeNode[mf.ExtraFunds.Count];
                    for (int i=0; i < arraySub.Length; i++)
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

                treeView1.Nodes.Add(treeNode);
            }            
        }

        /*
         * Parte relacionada a adição dos códigos de Depto ao contrato
         */
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            string dptCode = this.txtDptCode.Text;
            Department dept = _facade.GetDepartmentByCode(dptCode);
            if (dept == null)
            {
                if (DialogResult.Yes == MessageBox.Show("Departamento não encontrado na base de dados, deseja adicioná-lo?", "Adicionar Departamento Novo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    FrmAddDepartment frmAddDepartment = new FrmAddDepartment(dptCode);                  
                    frmAddDepartment.FormClosed += new FormClosedEventHandler(_FormAddDeptClosed);
                    frmAddDepartment.ShowDialog();
                }
            }
            else
            {
                _TryAddingDept(dept);
            }
        }

        private void _TryAddingDept(Department dept)
        {
            if (this.allDeptCodes.Add(dept))
            {
                ListViewItem item;
                item = new ListViewItem();
                item.Text = dept.Code;
                item.SubItems.Add(dept.Name);
                this.listDepts.Items.Add(item);
                this.txtDptCode.Text = "";
            }
        }

        private void _FormAddDeptClosed (object sender, FormClosedEventArgs e)
        {
            FrmAddDepartment frmAddDepartment = (FrmAddDepartment)sender;
            _TryAddingDept(frmAddDepartment.Department);
        }

        /*
         * Parte relacionada a adição das alíquotas ao contrato
         */
        private void btnAddAliquot_Click(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(this.txtAliquotValue.Text, aliqPattern))
                {
                    double aliqValue = Convert.ToDouble(this.txtAliquotValue.Text);
                    ContingencyFund cf = this.cbContigencyFunds.SelectedItem as ContingencyFund;
                    ContingencyAliquot contAliq = new ContingencyAliquot(aliqValue, cf);

                    _TryAddingContingencyAliquot(contAliq);
                }
                else
                {
                    MessageBox.Show("A taxa de alíquota inserida deve conter dois dígitos decimais e duas casas decimais separadas por vírgula, exemplo: 10,30%", 
                        "Erro de Conversão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("A taxa de alíquota inserida deve ser válida, exemplo: 10,30%", "Erro de Conversão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("A taxa inserida deve ser entre 00,00 e 99,99%", "Erro de Conversão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _TryAddingContingencyAliquot(ContingencyAliquot contAliq)
        {
            if (this.contingencyFundsAliquots.Add(contAliq))
            {
                ListViewItem item;
                item = new ListViewItem();
                item.Text = contAliq.ContingencyFund.Name;
                item.SubItems.Add(contAliq.Value.ToString());
                this.listContFundsAliquots.Items.Add(item);
                this.txtAliquotValue.Text = "";
            }
        }

        private void txtAliquotValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // temporary invalid inputs like "1," are allowed
            if ((e.KeyChar < 32) || (e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == ','))
                return;

            // only evident errors (like 'A' or '&') are restricted
            e.Handled = true;
        }

        private void linkPastAliquots_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSaveContract_Click(object sender, EventArgs e)
        {
            Contract contract = _GetValidContract();
            if (contract != null)
            {
                try
                {
                    //desabilita os botões enquanto a tarefa é executada.
                    this.btnAddAliquot.Enabled = false;
                    this.btnAddDept.Enabled = false;
                    this.btnSaveContract.Enabled = false;
                    bgWorkerDatabase.RunWorkerAsync(contract);

                    //define a progressBar para Marquee
                    pbSaveDatabase.Style = ProgressBarStyle.Marquee;
                    pbSaveDatabase.MarqueeAnimationSpeed = 6;

                    //informa que a tarefa esta sendo executada.
                    this.lblWaiting.Text = "Aguarde, salvando na base de dados...";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dateTPEnd_ValueChanged(object sender, EventArgs e)
        {
            _CheckDates();
        }

        private void dateTPStart_ValueChanged(object sender, EventArgs e)
        {
            _CheckDates();
        }

        private bool _CheckDates()
        {
            if (this.dateTPStart.Value >= this.dateTPEnd.Value)
            {
                MessageBox.Show("A data final deve ser maior que a data inicial.", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dateTPEnd.Focus();
                return false;
            }

            return true;
        }

        private Contract _GetValidContract()
        {
            if (_ValidateContract())
            {
                Contract contract = new Contract();
                contract.Name = this.txtContractName.Text;
                contract.StartDate = this.dateTPStart.Value;
                contract.EndDate = this.dateTPEnd.Value;
                contract.Departments = new List<Department>(this.allDeptCodes);
                contract.ContingencyAliquot = new List<ContingencyAliquot>(this.contingencyFundsAliquots);
                contract.MonetaryFunds = _GetSelectedMonetaryFunds();
                return contract;
            } 
            else
            {
                return null;
            }
        }

        private bool _ValidateContract()
        {
            if (String.IsNullOrEmpty(txtContractName.Text))
            {
                MessageBox.Show("O nome do contrato deve ser preenchido.", "Novo Contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (!_CheckDates())
            {
                return false;
            }
            
            return true;
        }

        private List<MonetaryFund> _GetSelectedMonetaryFunds()
        {
            List<MonetaryFund> selectedMFs = new List<MonetaryFund>();
            //Varrendo o node pai (verbas monetárias)
            MonetaryFund currentMF;
            ExtraFund currentEF;
            foreach (TreeNode mfNode in this.treeView1.Nodes)
            {
                if (mfNode.Checked)
                {
                    currentMF = (MonetaryFund)mfNode.Tag;
                    selectedMFs.Add(currentMF);
                    //varrendo nodes filhos, se houver(verbas adicionais)
                    foreach (TreeNode efNode in mfNode.Nodes)
                    {
                        //Se o node filho não tiver marcado, removo ele da List do objeto MonetaryFund que vai ser retornada
                        if (!efNode.Checked)
                        {
                            currentEF = (ExtraFund)efNode.Tag;
                            foreach (ExtraFund extraFund in currentMF.ExtraFunds)
                            {
                                if (extraFund.Name.Equals(currentEF.Name))
                                {
                                    currentMF.ExtraFunds.Remove(extraFund);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return selectedMFs;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                if (e.Node.Parent != null)
                {
                    e.Node.Parent.Checked = true;
                }
            } 
        }

        private void bgWorkerDatabase_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Contract contract = (Contract) e.Argument;
            try
            {
                long retId = _facade.InsertContract(contract);
                if (retId > 0)
                {
                    MessageBox.Show("Contrato inserido na base de dados com sucesso. Id Retornado: " + retId, "Contrato Inserido", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    MessageBox.Show("Ops, ocorreu um erro e o contrato não foi inserido!", "Erro ao inserir contrato na base de dados", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao salvar na base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgWorkerDatabase_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //desabilita os botões enquanto a tarefa é executada.
            this.btnAddAliquot.Enabled = true;
            this.btnAddDept.Enabled = true;
            this.btnSaveContract.Enabled = true;

            //Carrega todo progressbar.
            pbSaveDatabase.MarqueeAnimationSpeed = 0;
            pbSaveDatabase.Style = ProgressBarStyle.Blocks;
            pbSaveDatabase.Value = 100;

            //informa que a tarefa esta sendo executada.
            this.lblWaiting.Text = "";
        }
    }
}
