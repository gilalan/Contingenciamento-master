using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertMonetaryFunds : Form
    {
        Facade _facade = new Facade();
        public FrmInsertMonetaryFunds()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Cliente cliente = this.cbClientes.SelectedItem as Cliente;
            //Contrato contrato = this.cbContratos.SelectedItem as Contrato;
            //Verba verba = this.cbVerbasFilter.SelectedItem as Verba;
            //ContratoAliquota cAliq = new ContratoAliquota();
            MonetaryFund mf = new MonetaryFund();
            mf.Primal = true;

            if (!String.IsNullOrEmpty(txtMonetaryFunds.Text))
                mf.Name = txtMonetaryFunds.Text;

            //if (contrato != null)
            //    cAliq.Contrato = contrato;

            //if (verba != null)
            //    cAliq.Verba = verba;

            //cAliq.Aliquota = Convert.ToDouble(txtAliquota.Text);
            //cAliq.Ano = Convert.ToInt32(txtAno.Text);

            try
            {
                _facade.InsertMonetaryFund(mf);
                MessageBox.Show("Verba de Base " + mf.Name + " cadastrada com sucesso.",
                    "Cadastro de Verbas de Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Verba de Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
