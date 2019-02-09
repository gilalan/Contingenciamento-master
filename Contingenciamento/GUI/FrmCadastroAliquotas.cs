using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmCadastroAliquotas : Form
    {
        Facade _facade = new Facade();
        List<Verba> verbas;
        List<Contrato> contratos;
        List<Cliente> clientes;

        public FrmCadastroAliquotas()
        {
            InitializeComponent();
        }

        private void FrmCadastroAliquotas_Load(object sender, EventArgs e)
        {
            clientes = _facade.GetTopCliente();
            contratos = _facade.GetTopContrato();
            verbas = _facade.GetTopVerba();
            FillCbBoxes();
        }

        private void FillCbBoxes()
        {
            //CB Clientes
            var source0 = new BindingSource();
            source0.DataSource = clientes;
            cbClientes.DataSource = source0;
            cbClientes.DisplayMember = "Name";
            cbClientes.ValueMember = "Id";

            //CB Contratos
            var source1 = new BindingSource();
            source1.DataSource = contratos;
            cbContratos.DataSource = source1;
            cbContratos.DisplayMember = "Name";
            cbContratos.ValueMember = "Id";

            //CB Verbas
            var source2 = new BindingSource();
            //verbas.Insert(0, new Verba(-1, -1, "Todas", true));
            source2.DataSource = verbas;
            this.cbVerbasFilter.DataSource = source2;
            this.cbVerbasFilter.DisplayMember = "Nome";
            this.cbVerbasFilter.ValueMember = "Id";
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;
            Cliente cli = c.SelectedItem as Cliente;
            LoadComboBoxContratos(cli);
        }

        private void LoadComboBoxContratos(Cliente cli)
        {
            var source = new BindingSource();
            source.DataSource = FilteredContracts(cli);
            this.cbContratos.DataSource = source;
        }

        private List<Contrato> FilteredContracts(Cliente cli)
        {
            List<Contrato> filteredContracts = new List<Contrato>();
            foreach (var contrato in contratos)
            {
                if (contrato.Cliente.Id == cli.Id)
                    filteredContracts.Add(contrato);
            }
            return filteredContracts;
        }

        private void txtAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && txtAliquota.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void btnSaveAliq_Click(object sender, EventArgs e)
        {

            Cliente cliente = this.cbClientes.SelectedItem as Cliente;
            Contrato contrato = this.cbContratos.SelectedItem as Contrato;
            Verba verba = this.cbVerbasFilter.SelectedItem as Verba;
            ContratoAliquota cAliq = new ContratoAliquota();

            if (cliente != null)
                cAliq.Cliente = cliente;

            if (contrato != null)
                cAliq.Contrato = contrato;

            if (verba != null)
                cAliq.Verba = verba;

            cAliq.Aliquota = Convert.ToDouble(txtAliquota.Text);
            cAliq.Ano = Convert.ToInt32(txtAno.Text);

            try
            {
                _facade.InserirContratoAliquota(cAliq);
                MessageBox.Show("Alíquota da Verba " + verba.Nome + " cadastrada com sucesso.", 
                    "Cadastro de Alíquotas de Verbas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Alíquota", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
