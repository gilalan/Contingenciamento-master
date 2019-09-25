using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmRemoveContingency : Form
    {
        Facade _facade = new Facade();
        Contract currentContract;
        Contract passedContract;
        List<Contract> allContracts;

        public FrmRemoveContingency()
        {
            InitializeComponent();
        }

        public FrmRemoveContingency(Contract ct)
        {
            this.passedContract = ct;
            InitializeComponent();
        }

        private void FrmRemoveContingency_Load(object sender, EventArgs e)
        {
            allContracts = _facade.GetTopContract();
            _FillContractsCB(allContracts);
            dtPickerStart.Format = DateTimePickerFormat.Custom;
            dtPickerStart.CustomFormat = "MM/yyyy";
            dtPickerStart.ShowUpDown = true;
            dtPickerEnd.Format = DateTimePickerFormat.Custom;
            dtPickerEnd.CustomFormat = "MM/yyyy";
            dtPickerEnd.ShowUpDown = true;
        }        

        private void CbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentContract = this.cbContracts.SelectedItem as Contract;
            _SetContractOnDialog(currentContract);
        }        

        private void _FillContractsCB(List<Contract> contracts)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = contracts;
            this.cbContracts.DataSource = source;
            this.cbContracts.DisplayMember = "Name";
            this.cbContracts.ValueMember = "Id";
            this.cbContracts.SelectedItem = contracts[0];
            this.currentContract = contracts[0];
        }

        private void _ClearElements()
        {
            this.txtOutput.Text = "";
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
                strBuilder.AppendLine();
                strBuilder.AppendLine("ATENÇÃO: Ao clicar em Remover Contingenciamento (qualquer um dos botões do painel ao lado), o software irá apagar da base o Contingenciamento calculado para o atual Contrato. Esta ação não removerá o histórico dos Colaboradores deste Contrato, apenas apagará o cálculo realizado sobre este histórico.");
                this.txtOutput.Text = strBuilder.ToString();
            }
            else
            {
                this.txtOutput.Text = "Não foi possível obter o histórico de Contingenciamento para o Contrato " + ct.Name;
            }
        }

        private void _SetContractOnDialog(Contract ct)
        {
            _ClearElements();
            _LoadingContractInfo(ct);
            _GetEmployeesInContract(ct);
            _FillOutputInfo(ct);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DateTime start = dtPickerStart.Value;
            DateTime end = dtPickerEnd.Value;

            DateTime argStart = new DateTime(start.Year, start.Month, 1);
            DateTime argEnd = new DateTime(end.Year, end.Month, 1);

            int rowsAffected = _facade.DeleteContingencyByContractAndDateRange(this.currentContract, argStart, argEnd);
            if (rowsAffected <= 0)
            {
                MessageBox.Show("Nenhum registro foi encontrado dentro do período.", "Exclusão de Contingenciamento por Período", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Um total de " + rowsAffected + " foram excluídos da base de dados.", "Exclusão de Contingenciamento por Período", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SetContractOnDialog(this.currentContract);
            }
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            int rowsAffected = _facade.DeleteContingencyByContract(this.currentContract);
            if (rowsAffected <= 0)
            {
                MessageBox.Show("Nenhum registro foi encontrado para exclusão.", "Exclusão de Contingenciamento por Período", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Um total de " + rowsAffected + " foram excluídos da base de dados.", "Exclusão de Contingenciamento por Período", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SetContractOnDialog(this.currentContract);
            }
        }
    }
}
