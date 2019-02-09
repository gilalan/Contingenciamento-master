using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contingenciamento.Entidades;
using Contingenciamento.BLL;
using Contingenciamento.GUI;

namespace Contingenciamento
{
    public partial class MenuPrincipal : Form
    {        

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {
            FrmCadastrosChoices frmCadastrosChoices = new FrmCadastrosChoices();
            frmCadastrosChoices.ShowDialog();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            FrmConsultas frmConsultas = new FrmConsultas();
            frmConsultas.ShowDialog();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            FrmRelatorios frmRelatorios = new FrmRelatorios();
            frmRelatorios.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConfiguracoes frmConfig = new FrmConfiguracoes();
            frmConfig.ShowDialog();
        }
    }
}
