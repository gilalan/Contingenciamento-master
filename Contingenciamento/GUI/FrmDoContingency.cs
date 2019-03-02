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
        List<Contract> allContracts;

        public FrmDoContingency()
        {
            InitializeComponent();
        }

        private void FrmDoContingency_Load(object sender, EventArgs e)
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
        }

        private void cbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contract ct = this.cbContracts.SelectedItem as Contract;

            //this.lblDeptsCount.Text = ct.Departments.Count.ToString();
            this.lblContFundsCount.Text = ct.ContingencyAliquot.Count.ToString();
            //this.lblMonetaryFundType.Text;
            this.lblEmployeesCount.Text = _GetEmployeesInContract(ct);
        }

        private string _GetEmployeesInContract(Contract ct)
        {
            //List<EmployeeHistory> employeeHistoriesCT = _facade.GetHistoryFromContract(ct); REFAZER!!!!
            //List<EmployeeHistory> employeeHistoriesCT = _facade.GetTopEmployeeHistory();
            //foreach (EmployeeHistory eh in employeeHistoriesCT)
            //{

            //}
            return "";
        }

        private void btnDoConting_Click(object sender, EventArgs e)
        {

        }

    }
}
