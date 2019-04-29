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
    public partial class FrmSolicitationChoices : Form
    {
        public FrmSolicitationChoices()
        {
            InitializeComponent();
        }

        private void btn13Salary_Click(object sender, EventArgs e)
        {
            Frm13SalarySolicit frm13SalarySolicit = new Frm13SalarySolicit();
            frm13SalarySolicit.ShowDialog();
        }

        private void btnVacation_Click(object sender, EventArgs e)
        {
            FrmVacationSolicit frmVacationSolicit = new FrmVacationSolicit();
            frmVacationSolicit.ShowDialog();
        }

        private void btnPenalty_Click(object sender, EventArgs e)
        {

        }
    }
}
