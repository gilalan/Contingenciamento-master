using System;
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
    public partial class FrmCadastrosChoices : Form
    {
        public FrmCadastrosChoices()
        {
            InitializeComponent();
        }

        private void btnCadHistFunc_Click(object sender, EventArgs e)
        {
            FrmCadastros frmCadastros = new FrmCadastros();
            frmCadastros.ShowDialog();
        }

        private void btnCadAliq_Click(object sender, EventArgs e)
        {
            FrmCadastroAliquotas frmCadastrosAliquotas = new FrmCadastroAliquotas();
            frmCadastrosAliquotas.ShowDialog();
        }              

        private void btnAddManyFunds_Click(object sender, EventArgs e)
        {
            FrmAllFunds frmAllFunds = new FrmAllFunds();
            frmAllFunds.ShowDialog();
        }

        private void btnAddContracts_Click(object sender, EventArgs e)
        {
            FrmInsertContract frmInsertContract = new FrmInsertContract();
            frmInsertContract.ShowDialog();
        }

        private void btnAddDeptAndRoles_Click(object sender, EventArgs e)
        {
            FrmInsertEntities frmInsertEntities = new FrmInsertEntities();
            frmInsertEntities.ShowDialog();
        }
    }
}
