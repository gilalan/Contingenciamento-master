using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmViewContingency : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        Contract passedContract;
        List<Contract> allContracts;
        List<int> orderedYears;
        Dictionary<int, List<ContingencyPast>> yearListCPsPairs;
        Dictionary<KeyValuePair<int,int>, List<ContingencyPast>> yearMonthCPsList;

        public FrmViewContingency()
        {
            InitializeComponent();
        }

        public FrmViewContingency(List<ContingencyPast> contingencyPasts, Contract passedContract)
        {
            this.passedContract = passedContract;
            InitializeComponent();
        }

        private void FrmViewContingency_Load(object sender, EventArgs e)
        {
            allContracts = _facade.GetTopContract();
            _FillContractsCB(allContracts);
        }

        private void _FillContractsCB(List<Contract> contracts)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = contracts;
            this.cbContracts.DataSource = source;
            this.cbContracts.DisplayMember = "Name";
            this.cbContracts.ValueMember = "Id";
            if (this.passedContract != null)
            {
                foreach (var item in this.cbContracts.Items)
                {
                    if (this.passedContract.Id == (item as Contract).Id)
                        this.cbContracts.SelectedItem = item;
                }
            }
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
            this.panelGrid.Controls.Clear();
        }

        private void _LoadingContractInfo(Contract ct)
        {
            this.txtContractName.Text = ct.Name;
            this.txtContractDescription.Text = ct.Description;
        }

        private void _GetEmployeesInContract(Contract ct)
        {
            this.txtEmployeesCount.Text = _facade.GetEmployeesCountByContract(ct).ToString();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Pegar a lista de contPasts cujo contrato = idContract selecionado e mostrar na estrutura de visualização que projetei
            List<ContingencyPast> cps = _facade.GetContingencyPastsByContract(this.currentContract);
            if (cps.Count == 0)
            {
                MessageBox.Show("Atenção: não foram encontrados registros de processamento de contingenciamento para o contrato: " + this.currentContract.Name,
                    "Realizar Contingenciamento antes de visualizar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            _CreateDataSet(cps);
        }

        private void _CreateDataSet(List<ContingencyPast> contPasts)
        {
            HashSet<int> years = new HashSet<int>();

            foreach (ContingencyPast cp in contPasts)
            {
                years.Add(cp.EmployeeHistory.Epoch.Year);
            }

            this.yearListCPsPairs = new Dictionary<int, List<ContingencyPast>>();
            this.yearMonthCPsList = new Dictionary<KeyValuePair<int, int>, List<ContingencyPast>>();
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
            orderedYears = new List<int>(years);
            orderedYears.Sort();
            _FillYearsCB(orderedYears);
        }

        private void _FillYearsCB(List<int> years)
        {
            var source = new BindingSource();
            source.DataSource = years;
            this.cbYears.DataSource = source;
            //this.cbContracts.DisplayMember = "Name";
            //this.cbContracts.ValueMember = "Id";
        }

        private void cbYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = (int)this.cbYears.SelectedItem;
            this.panelGrid.Controls.Clear();
            _FillDataGridView(year);
        }

        private void _FillDataGridView(int year)
        {
            string[] namedMonths = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho",
                "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

            if (this.yearListCPsPairs.ContainsKey(year))
            {
                List<ContingencyPast> cpList = this.yearListCPsPairs[year];
                List<ContingencyPast> SortedCPList = cpList.OrderBy(o => o.EmployeeHistory.Epoch.Month).ThenBy(o => o.EmployeeHistory.Employee.Name).ToList();
                List<ContingencyAliquot> SortedCAList = this.currentContract.ContingencyAliquot.OrderBy(o => o.ContingencyFund.Id).ToList();
                List<DataTable> tables = new List<DataTable>();
                DataGridContingency dataGridContingency;
                DataRow row;
                string selectedMFToContingency = "Verba Monetaria";
                double total = 0;
                int countMonthRows = 0;
                KeyValuePair<int,int> kvpMonthYear;
                List<ContingencyPast> monthYearCPList; 
                //Serão 12 dataTables representando os 12 meses do ano.
                for (int i = 1; i <= namedMonths.Length; i++)
                {
                    kvpMonthYear = new KeyValuePair<int, int>(year, i);
                    monthYearCPList = new List<ContingencyPast>();
                    countMonthRows = 0;
                    DataTable dt = new DataTable(namedMonths[i - 1]);
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
                        //selectedMFToContingency = cp.MonetaryFundName;
                        if (cp.EmployeeHistory.Epoch.Month == i)
                        {
                            countMonthRows++;
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
                            monthYearCPList.Add(cp);
                        }
                    }
                    if (countMonthRows > 0)
                    {
                        dataGridContingency = new DataGridContingency(dt, this.panelGrid.Size);
                        this.panelGrid.Controls.Add(dataGridContingency);
                    }
                    yearMonthCPsList.Add(kvpMonthYear, monthYearCPList);
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

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (this.cbYears.Items.Count > 0)
            {
                int objYear = (int)this.cbYears.SelectedIndex;
                FrmExcelExport frmExcelExp = new FrmExcelExport(objYear, orderedYears, yearMonthCPsList, currentContract);
                frmExcelExp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para exportar, deve existir um contingenciamento ativo para um contrato.", 
                    "Escolha um contrato antes de exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
