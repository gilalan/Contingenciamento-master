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
    public partial class FrmConfiguracoes : Form
    {
        public FrmConfiguracoes()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmConfiguracoes_Load(object sender, EventArgs e)
        {
            this.txtServer.Text = Properties.Settings.Default.Server;
            this.txtPort.Text = Properties.Settings.Default.Port;
            this.txtDatabase.Text = Properties.Settings.Default.Database;
            this.txtUser.Text = Properties.Settings.Default.User;
            this.txtPassword.Text = Properties.Settings.Default.Password;
        }
    }
}
