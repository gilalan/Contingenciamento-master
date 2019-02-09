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
    public partial class DlgTextoEmail : Form
    {
        public DlgTextoEmail()
        {
            InitializeComponent();
        }

        public DlgTextoEmail(List<string> fullText)
        {
            InitializeComponent();
            foreach (var strText in fullText)
            {
                txtArea.Text += strText;
            }
        }
    }
}
