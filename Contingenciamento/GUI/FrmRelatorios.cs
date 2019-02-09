using Contingenciamento.GUI;
using System;
using System.Windows.Forms;

namespace Contingenciamento
{
    public partial class FrmRelatorios : Form
    {
        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void bntRelFuncionario_Click(object sender, EventArgs e)
        {
            FrmRelatorioFuncionario frmRelFunc = new FrmRelatorioFuncionario();
            frmRelFunc.ShowDialog();
        }

        private void btnRelClient_Click(object sender, EventArgs e)
        {
            FrmRelatorioCliente frmRelCliente = new FrmRelatorioCliente();
            frmRelCliente.ShowDialog();
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            FrmRelatorioContrato frmRelContrato = new FrmRelatorioContrato();
            frmRelContrato.ShowDialog();
        }

        private void btnUnidade_Click(object sender, EventArgs e)
        {
            FrmRelatorioVerba frmRelatorioVerba = new FrmRelatorioVerba();
            frmRelatorioVerba.ShowDialog();
        }
    }
}
