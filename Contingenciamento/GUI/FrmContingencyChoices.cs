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
    public partial class FrmContingencyChoices : Form
    {
        public FrmContingencyChoices()
        {
            InitializeComponent();
        }

        private void btnProcessCont_Click(object sender, EventArgs e)
        {
            FrmDoContingency frmDoContingency = new FrmDoContingency();
            frmDoContingency.ShowDialog();
        }

        private void btnViewCont_Click(object sender, EventArgs e)
        {
            FrmViewContingency frmViewContingency = new FrmViewContingency();
            frmViewContingency.ShowDialog();
        }
    }
}
