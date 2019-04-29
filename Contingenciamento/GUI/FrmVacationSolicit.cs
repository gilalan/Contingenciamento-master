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
        Dictionary<int, List<ContingencyPast>> yearListCPsPairs;

        public FrmVacationSolicit()
        {
            InitializeComponent();
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
            _LoadingContractInfo(currentContract);
            _GetEmployeesInContract(currentContract);
            _GetContPastForContract(currentContract);
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

            _FillYearsCB(orderedYears);
        }

        private void _FillYearsCB(List<int> orderedYears)
        {
            var source = new BindingSource();
            source.DataSource = orderedYears;
            this.cbLowYear.DataSource = source;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int year = (int)this.cbLowYear.SelectedItem;
            List<ContingencyPast> cpListByYear = this.yearListCPsPairs[year];
            IWorkbook workbook = DefaultExporterWorksheet.ExportCtgencyVacationEmployeeList(cpListByYear, year);
            _SaveExcelFile(workbook);
        }

        private void _SaveExcelFile(IWorkbook wb)
        {
            int year = (int)this.cbLowYear.SelectedItem;

            sfDlg.Title = "Salvar Planilha XLSX";
            sfDlg.Filter = "Excel Worksheet File|.xlsx";
            sfDlg.FilterIndex = 0;
            sfDlg.FileName = "Conting_Ferias_" + this.currentContract.Name + "_" + year;
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
