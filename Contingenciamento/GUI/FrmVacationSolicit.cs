using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmVacationSolicit : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        List<Contract> allContracts;
        List<int> orderedYears;
        List<ContingencyAliquot> taxFunds;
        Dictionary<int, List<ContingencyPast>> yearListCPsPairs;
        CheckBox headerCheckBox = new CheckBox();
        List<EmployeeHistory> employeeHistoriesVacation = new List<EmployeeHistory>();
        bool allSelect = false;

        public FrmVacationSolicit()
        {
            InitializeComponent();
            _SetDatagridSchema();
        }

        private void FrmVacationSolicit_Load(object sender, EventArgs e)
        {            
            allContracts = _facade.GetTopContract();
            _FillContractsCB(allContracts);
        }

        private void _FillContractsCB(List<Contract> contracts)
        {
            var source = new BindingSource();
            source.DataSource = contracts;
            this.cbContracts.DataSource = source;
            this.cbContracts.DisplayMember = "Name";
            this.cbContracts.ValueMember = "Id";
        }

        private void cbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentContract = this.cbContracts.SelectedItem as Contract;
            //_RemoveElements();
            //PEGAR VERBA DE INCIDENCIA!
            _LoadingContractInfo(currentContract);
            _GetEmployeesInContract(currentContract);
            _GetContPastForContract(currentContract);
            _GetEmployeesInVacationByContract(currentContract);
            taxFunds = _facade.GetContingencyAliquotsByContract(this.currentContract);
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

        private void _GetEmployeesInVacationByContract(Contract ct)
        {
            employeeHistoriesVacation = _facade.GetEmployeesVacationByContract(ct);
            _SetDatagridEmployees(employeeHistoriesVacation);
        }

        private void _SetDatagridSchema()
        {
            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dgvEmployees.Columns.Insert(0, checkBoxColumn);

            //Assign Click event to the DataGridView Cell.
            dgvEmployees.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);

            DataGridViewTextBoxColumn matrCol = new DataGridViewTextBoxColumn();
            matrCol.HeaderText = "Matrícula";
            matrCol.Width = 70;
            matrCol.Name = "matriculaColumn";
            matrCol.ReadOnly = true;
            dgvEmployees.Columns.Insert(1, matrCol);

            DataGridViewTextBoxColumn nomeCol = new DataGridViewTextBoxColumn();
            nomeCol.HeaderText = "Nome";
            nomeCol.MinimumWidth = 250;
            nomeCol.Name = "nomeColumn";
            nomeCol.ReadOnly = true;
            dgvEmployees.Columns.Insert(2, nomeCol);

            DataGridViewTextBoxColumn perAqCol = new DataGridViewTextBoxColumn();
            perAqCol.HeaderText = "Período Aquisitivo";
            perAqCol.MinimumWidth = 300;
            perAqCol.Name = "perAqColumn";
            perAqCol.ReadOnly = true;
            dgvEmployees.Columns.Insert(3, perAqCol);

            //Find the Location of Header Cell.
            Point headerCellLocation = this.dgvEmployees.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 60, headerCellLocation.Y + 3);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dgvEmployees.Controls.Add(headerCheckBox);
        }
        private void _SetDatagridEmployees(List<EmployeeHistory> employeeHistoriesVacation)
        {
            //DataGridViewRow dgvRow;
            int rowIndex;
            foreach (EmployeeHistory eh in employeeHistoriesVacation)
            {
                //dgvRow = new DataGridViewRow();
                //dgvRow.SetValues(false, eh.Employee.Matriculation, eh.Employee.Name, 
                //    (eh.StartVacationTaken.ToString("dd/MM/yyyy") + " até " + eh.EndVacationTaken.ToString("dd/MM/yyyy")));
                //this.dgvEmployees.Rows.Add(dgvRow);

                //Create the new row first and get the index of the new row
                rowIndex = this.dgvEmployees.Rows.Add();

                //Obtain a reference to the newly created DataGridViewRow 
                var row = this.dgvEmployees.Rows[rowIndex];

                //Now this won't fail since the row and columns exist 
                row.Cells[0].Value = false;
                row.Cells[1].Value = eh.Employee.Matriculation;
                row.Cells[2].Value = eh.Employee.Name;
                List<DateTime> dateTimes = new List<DateTime>() { eh.StartVacationTaken , eh.EndVacationTaken};
                row.Cells[3].Value = eh.StartVacationTaken.ToString("dd/MM/yyyy") + " até " + eh.EndVacationTaken.ToString("dd/MM/yyyy");
                row.Cells[3].Tag = dateTimes;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {            
            allSelect = !allSelect;
            foreach (DataGridViewRow row in this.dgvEmployees.Rows)
            {
                row.Cells[0].Value = allSelect;
            }
            //foreach (DataGridViewRow sRow in this.dgvEmployees.SelectedRows)
            //{
            //    sRow.Cells[0].Value = allSelect;
            //}
        }

        private void _GetContPastForContract(Contract currentContract)
        {
            //Pegar a lista de contPasts cujo contrato = idContract selecionado
            List<ContingencyPast> contPasts = _facade.GetContingencyPastsByContract(this.currentContract);
            HashSet<int> years = new HashSet<int>();

            foreach (ContingencyPast cp in contPasts)
            {
                years.Add(cp.EmployeeHistory.Epoch.Year);
            }

            this.yearListCPsPairs = new Dictionary<int, List<ContingencyPast>>();
            //this.yearMonthCPsList = new Dictionary<KeyValuePair<int, int>, List<ContingencyPast>>();
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

            //_FillYearsCB(orderedYears);
        }        

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<EmployeeHistory> employeeHistoriesChecked = new List<EmployeeHistory>();
            foreach (DataGridViewRow row in this.dgvEmployees.Rows)
            {
                //se tiver marcado com CHECKED o funcionário
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    foreach (EmployeeHistory eh in employeeHistoriesVacation)
                    {
                        if (eh.Employee.Matriculation == row.Cells["matriculaColumn"].Value.ToString())
                        {
                            List<DateTime> dateTimes = (List<DateTime>) row.Cells["perAqColumn"].Tag;
                            DateTime dt1, dt2;
                            if (dateTimes.Count > 0 && dateTimes.Count < 2)
                            {
                                dt1 = dt2 = dateTimes[0];
                            } 
                            else
                            {
                                dt1 = dateTimes[0];
                                dt2 = dateTimes[1];
                            }
                            if ( (DateTime.Compare(eh.StartVacationTaken, dt1) == 0 || DateTime.Compare(eh.StartVacationTaken, dt2) == 0) &&
                                (DateTime.Compare(eh.EndVacationTaken, dt1) == 0 || DateTime.Compare(eh.EndVacationTaken, dt2) == 0))
                            {
                                employeeHistoriesChecked.Add(eh);
                            }
                        }
                    }
                }
            }

            HashSet<ContingencyPast> empHistoryContPast = 
                _facade.GetContingencyPastsByEmployeeHistoryList(employeeHistoriesChecked, new ContingencyFund("Férias"));
            //int year = (int)this.cbLowYear.SelectedItem;
            //List<ContingencyPast> cpListByYear = this.yearListCPsPairs[year];
            ContingencyAliquot caInc = new ContingencyAliquot();
            foreach (ContingencyAliquot ca in taxFunds)
            {
                if (ca.ContingencyFund.Name.ToUpper().Equals("INCIDÊNCIA"))
                {
                    caInc = ca;
                }
            }
            IWorkbook workbook = DefaultExporterWorksheet.ExportCtgencyVacationEmployeeList(employeeHistoriesChecked, empHistoryContPast, caInc);
            _SaveExcelFile(workbook);
        }

        private void _SaveExcelFile(IWorkbook wb)
        {
            //int year = (int)this.cbLowYear.SelectedItem;

            sfDlg.Title = "Salvar Planilha XLSX";
            sfDlg.Filter = "Excel Worksheet File|.xlsx";
            sfDlg.FilterIndex = 0;
            //sfDlg.FileName = "Conting_Ferias_" + this.currentContract.Name + "_" + year;
            sfDlg.DefaultExt = ".xlsx";
            sfDlg.InitialDirectory = @"D:\TestContingency";
            sfDlg.RestoreDirectory = true;

            DialogResult result = sfDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfDlg.FileName, FileMode.Create, FileAccess.Write);
                wb.Write(fs);
                wb.Close();
                MessageBox.Show("O arquivo \"" + sfDlg.FileName + "\" foi criado com sucesso.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
