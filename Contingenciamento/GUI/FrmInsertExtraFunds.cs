using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertExtraFunds : Form
    {
        Facade _facade = new Facade();
        List<MonetaryFund> monetaryFunds;

        public FrmInsertExtraFunds()
        {
            InitializeComponent();
        }

        private void FrmInsertExtraFunds_Load(object sender, EventArgs e)
        {
            monetaryFunds = _facade.GetTopMonetaryFund();
            FillMonetaryFundsCB(monetaryFunds);
        }

        private void FillMonetaryFundsCB(List<MonetaryFund> monetaryFunds)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = monetaryFunds;
            this.cbMonetaryFunds.DataSource = source;
            this.cbMonetaryFunds.DisplayMember = "Name";
            this.cbMonetaryFunds.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MonetaryFund mf = this.cbMonetaryFunds.SelectedItem as MonetaryFund;
            ExtraFund ef = new ExtraFund();

            if (!String.IsNullOrEmpty(txtExtraFunds.Text))
                ef.Name = txtExtraFunds.Text;

            if (mf != null)
                ef.MonetaryFund = mf;

            try
            {
                _facade.InsertExtraFund(ef);
                MessageBox.Show("Verba " + ef.Name + " cadastrada com sucesso como verba adicional de " + mf.Name + ".",
                    "Cadastro de Verbas de Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Verba de Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
