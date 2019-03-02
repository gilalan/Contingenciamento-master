using System;
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
            FrmInsertHistoryEmployee frmCadastros = new FrmInsertHistoryEmployee();
            frmCadastros.ShowDialog();
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
