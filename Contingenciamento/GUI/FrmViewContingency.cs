using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmViewContingency : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        List<Contract> allContracts;

        public FrmViewContingency()
        {
            InitializeComponent();
        }

        public FrmViewContingency(List<ContingencyPast> contingencyPasts)
        {
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
        }
    }
}
