using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmDoContingency : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        List<Contract> allContracts;
        Dictionary<int, List<ContingencyPast>> yearListCPsPairs;
        List<ContingencyPast> contPasts;
        string selectedMFToContingency;

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
            this.txtBalance.Text = ct.Balance.ToString();
            foreach (ContingencyAliquot ca in ct.ContingencyAliquot)
            {
                ListViewItem item;
                item = new ListViewItem();
                item.Text = ca.ContingencyFund.Name;
                item.SubItems.Add(ca.Value.ToString());
                this.listContFundsAliquots.Items.Add(item);
            }
            _StylingTreeView(ct.MonetaryFunds);
            _FillOutputInfo(ct);
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

        private void _FillOutputInfo(Contract ct)
        {
            List<long> contRowsSum = _facade.GetContingencyRowsSum(ct);
            if (contRowsSum.Count > 2)
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendLine("## Informação do histórico de Contingenciamento para o Contrato " + ct.Name + " ##");
                strBuilder.AppendLine("Total de registros armazenados na Base: " + contRowsSum[2]);
                strBuilder.AppendLine("Total de registros já processados e calculados para o Contingenciamento: " + contRowsSum[0]);
                strBuilder.AppendLine("Total de registros não processados/calculados: " + contRowsSum[1]);
                strBuilder.AppendLine("ATENÇÃO: Ao clicar em Contingenciar (botão abaixo), o software irá coletar os registros ainda não processados e realizará o cálculo do Contingenciamento apenas sobre eles." );
                this.txtOutput.Text = strBuilder.ToString();
            }
            else
            {
                this.txtOutput.Text = "Não foi possível obter o histórico de Contingenciamento para o Contrato " +ct.Name;
            }
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
                try
                {
                    //desabilita os botões enquanto a tarefa é executada.
                    _EnableAllButtons(false);
                    bgWorkDatabase.RunWorkerAsync(selectedMF);

                    //define a progressBar para Marquee
                    pbContingency.Style = ProgressBarStyle.Marquee;
                    pbContingency.MarqueeAnimationSpeed = 6;

                    //informa que a tarefa esta sendo executada.
                    this.lblWaiting.Text = "Aguarde, processando e salvando na base de dados...";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _CreateDataSet(List<ContingencyPast> contPasts)
        {
            HashSet<int> years = new HashSet<int>();

            foreach (ContingencyPast cp in contPasts)
            {
                years.Add(cp.EmployeeHistory.Epoch.Year);
            }

            this.yearListCPsPairs = new Dictionary<int, List<ContingencyPast>>();
            List<ContingencyPast> limitedCPList;
            foreach (int year in years)
            {
                limitedCPList = new List<ContingencyPast>();
                foreach (ContingencyPast cp in contPasts)
                {
                    if (cp.EmployeeHistory.Epoch.Year == year)
                    {
                        limitedCPList.Add(cp);
                    }
                }
                //limitedCPList.Sort()
                this.yearListCPsPairs.Add(year, limitedCPList);
            }            
        }
        private void _FillDataGridView(int year)
        {
            //DataTable table1 = new DataTable("Janeiro");
            //table1.Columns.Add("Id");
            //table1.Columns.Add("Nome");
            //table1.Columns.Add("13º Salário");
            //table1.Columns.Add("Férias");
            //table1.Columns.Add("Rescisão");
            //table1.Columns.Add("Incidência");
            //table1.Columns.Add("TOTAL");
            //table1.Rows.Add(1, "Valdir Papel", 152, 90, 54, 51, 251);
            //table1.Rows.Add(2, "Lelo Alves", 152, 90, 54, 51, 251);
            //table1.Rows.Add(3, "Marcília Amorim", 152, 90, 54, 51, 251);

            //DataTable table2 = new DataTable("Fevereiro");
            //table2.Columns.Add("Id");
            //table2.Columns.Add("Nome");
            //table2.Columns.Add("13º Salário");
            //table2.Columns.Add("Férias");
            //table2.Columns.Add("Rescisão");
            //table2.Columns.Add("Incidência");
            //table2.Columns.Add("TOTAL");
            //table2.Rows.Add(12, "Papai Noel", 152, 90, 54, 51, 251);

            //DataGridContingency dataGridContingency1 = new DataGridContingency(table1);
            //DataGridContingency dataGridContingency2 = new DataGridContingency(table2);
            //this.panelGrid.Controls.Add(dataGridContingency1);
            //this.panelGrid.Controls.Add(dataGridContingency2);
           
            string[] namedMonths = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};

            if (this.yearListCPsPairs.ContainsKey(year))
            {
                List<ContingencyPast> cpList = this.yearListCPsPairs[year];
                List<ContingencyPast> SortedCPList = cpList.OrderBy(o => o.EmployeeHistory.Epoch.Month).ThenBy(o => o.EmployeeHistory.Employee.Name).ToList();
                List<ContingencyAliquot> SortedCAList = this.currentContract.ContingencyAliquot.OrderBy(o => o.ContingencyFund.Id).ToList();
                List<DataTable> tables = new List<DataTable>();
                DataGridContingency dataGridContingency;
                DataRow row;
                double total = 0;
                //Serão 12 dataTables representando os 12 meses do ano.
                for (int i = 1; i <= namedMonths.Length; i++)
                {
                    DataTable dt = new DataTable(namedMonths[i-1]);
                    dt.Columns.Add("Matrícula");
                    dt.Columns.Add("Nome Completo");
                    dt.Columns.Add("PIS");
                    dt.Columns.Add("CPF");
                    dt.Columns.Add(selectedMFToContingency);
                    foreach (ContingencyAliquot contAliq in SortedCAList)
                    {
                        dt.Columns.Add(contAliq.ContingencyFund.Name);
                    }
                    dt.Columns.Add("Total");
                   // tables.Add(dt);
                    foreach (ContingencyPast cp in SortedCPList)
                    {
                        if (cp.EmployeeHistory.Epoch.Month == i)
                        {
                            total = 0;
                            row = dt.NewRow();
                            row["Matrícula"] = cp.EmployeeHistory.Employee.Matriculation;
                            row["Nome Completo"] = cp.EmployeeHistory.Employee.Name;
                            row["PIS"] = cp.EmployeeHistory.Employee.PIS;
                            row["CPF"] = cp.EmployeeHistory.Employee.CPF;
                            row[selectedMFToContingency] = _GetValueFromSelectMF(selectedMFToContingency, cp.EmployeeHistory);
                            foreach (ContingencyAliquot cal in cp.ContingencyAliquots)
                            {
                                row[cal.ContingencyFund.Name] = cal.CalculatedValue;
                                total += cal.CalculatedValue;
                            }
                            row["Total"] = total;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private double _GetValueFromSelectMF(string selectedMFToContingency, EmployeeHistory employeeHistory)
        {
            if (selectedMFToContingency.ToUpper().Equals("SALÁRIO BASE"))
            {
                return employeeHistory.BaseSalary;
            }
            else if (selectedMFToContingency.ToUpper().Equals("PROVENTOS TOTAIS"))
            {
                return employeeHistory.TotalEarnings;
            }
            else
            {
                return employeeHistory.NetSalary;
            }
        }

        private void bgWorkDatabase_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MonetaryFund selectedMF = (MonetaryFund)e.Argument;
            try
            {
                contPasts = _facade.ProcessContingencyContract(this.currentContract, selectedMF);
                if (contPasts.Count == 0)
                {
                    MessageBox.Show("O histórico para esse contrato já se encontra contingenciado na base de dados.",
                        "Contingenciamento Já Realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    double calcFerias = -1;
                    double calc13Sal = -1;
                    foreach (ContingencyPast cp in contPasts)
                    {
                        calcFerias = -1;
                        calc13Sal = -1;
                        foreach (ContingencyAliquot ca in cp.ContingencyAliquots)
                        {
                            if (ca.ContingencyFund.Name.ToUpper().Equals("FÉRIAS")) //TERIA QUE FAZER DINAMICO!
                            {
                                calcFerias = ca.CalculatedValue;
                            }
                            else if (ca.ContingencyFund.Name.ToUpper().Equals("13º SALÁRIO"))
                            {
                                calc13Sal = ca.CalculatedValue;
                            }
                        }
                        if (calcFerias != -1 && calc13Sal != -1)
                        {
                            foreach (ContingencyAliquot ca in cp.ContingencyAliquots)
                            {
                                if (ca.ContingencyFund.Name.ToUpper().Equals("INCIDÊNCIA")) //TERIA QUE FAZER DINAMICO!
                                {
                                    ca.CalculatedValue = Math.Round((ca.Value / 100) * (calcFerias + calc13Sal), 2);
                                    break;
                                }
                            }
                        }
                    }
                    int countRows = _facade.InsertContingencyPastList(contPasts);
                    this.selectedMFToContingency = selectedMF.Name;
                    _CreateDataSet(contPasts);

                    if (countRows > 0)
                    {//BRIR TELA SIM/NÃO para visualizar no form de visualização correto do contingenciamento
                        MessageBox.Show("O contingenciamento foi processado e salvo com sucesso na base de dados" +
                            "Contagem retornada: " + countRows, "Contingenciamento Salvo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ops, ocorreu um erro e o contingenciamento não foi adicionado a base de dados!", "Erro ao inserir contingenciamento na base de dados",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro ao salvar na base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.lblWaiting.Text = "Tarefa Concluída";
        }

        private void _EnableAllButtons(bool v)
        {
            this.cbContracts.Enabled = v;
            this.btnDoConting.Enabled = v;
            this.btnOpenViewContingency.Enabled = v;
            this.gbResult.Enabled = v;
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

        private void btnOpenViewContingency_Click(object sender, EventArgs e)
        {
            FrmViewContingency frmViewContingency = new FrmViewContingency(contPasts, this.currentContract);
            frmViewContingency.ShowDialog();
        }
    }
}
