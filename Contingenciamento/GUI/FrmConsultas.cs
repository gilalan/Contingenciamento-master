using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Contingenciamento
{
    public partial class FrmConsultas : Form
    {
        Facade _facade = new Facade();
        //DataSet result;

        public FrmConsultas()
        {
            InitializeComponent();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            buscarFuncionarios();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            buscarClientes();
        }        

        private void btnContratos_Click(object sender, EventArgs e)
        {
            buscarContratos();
        }

        private void btnUnidades_Click(object sender, EventArgs e)
        {
            buscarUnidades();
        }

        private void btnVerbas_Click(object sender, EventArgs e)
        {
            buscarVerbas();
        }

        private void btnContratoAliquotas_Click(object sender, EventArgs e)
        {
            buscarAliquotaContratos();
        }

        private void buscarFuncionarios()
        {
            List<Funcionario> funcs = _facade.GetTopFuncionario();
            var source = new BindingSource();
            source.DataSource = funcs;
            dgvConsultas.DataSource = source;
            dgvConsultas.Columns[2].HeaderText = "Nome";
            dgvConsultas.Columns[3].HeaderText = "Matrícula";
        }

        private void buscarClientes()
        {
            List<Cliente> clientes = _facade.GetTopCliente();
            var source = new BindingSource();
            source.DataSource = clientes;
            dgvConsultas.DataSource = source;
            //dgvConsultas.Columns[2].HeaderText = "Nome";
            //dgvConsultas.Columns[3].HeaderText = "Matrícula";
        }

        private void buscarContratos()
        {
            List<Contrato> contratos = _facade.GetTopContrato();
            var source = new BindingSource();
            source.DataSource = contratos;
            dgvConsultas.DataSource = source;
            //dgvConsultas.Columns[2].HeaderText = "Nome";
            //dgvConsultas.Columns[3].HeaderText = "Matrícula";
        }

        private void buscarUnidades()
        {
            List<Unidade> unidades = _facade.GetTopUnidade();
            var source = new BindingSource();
            source.DataSource = unidades;
            dgvConsultas.DataSource = source;
            //dgvConsultas.Columns[2].HeaderText = "Nome";
            //dgvConsultas.Columns[3].HeaderText = "Matrícula";
        }

        private void buscarVerbas()
        {
            List<Verba> verbas = _facade.GetTopVerba();
            var source = new BindingSource();
            source.DataSource = verbas;
            dgvConsultas.DataSource = source;
            dgvConsultas.Columns[0].HeaderText = "Id";
            dgvConsultas.Columns[1].HeaderText = "Nome";
        }

        private void buscarAliquotaContratos()
        {
            List <ContratoAliquota> contratoAliquotas = _facade.GetTopContratoAliquota();
            var source = new BindingSource();
            source.DataSource = contratoAliquotas;
            dgvConsultas.DataSource = source;
        }
    }
}
