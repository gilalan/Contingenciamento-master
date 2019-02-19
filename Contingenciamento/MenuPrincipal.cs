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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Facade fac = new Facade();
            //Employee emp = new Employee();
            //emp.Name = "ABIMAEL DE MOURA BATISTA";
            //emp.Matriculation = "010218";
            //emp.PIS = "";
            //emp.CPF = "05479472402";
            //emp.Birthday = new DateTime(1985, 12, 6);
            //emp.CurrentAdmissionDate = new DateTime(2013, 3, 18);
            //Bank bank = new Bank("BB", "001", "3249", "015700", "7");
            //emp.BankData = bank;
            //int idReturned = fac.InsertEmployee(emp);

            //Facade fac = new Facade();
            //Employee emp = new Employee();
            //emp.Name = "ALEXSANDRO SILVA";
            //emp.Matriculation = "010211";
            //emp.PIS = "";
            //emp.CPF = "25479472402";
            //emp.Birthday = new DateTime(1982, 12, 6);
            //emp.CurrentAdmissionDate = new DateTime(2011, 3, 18);
            //Bank bank = new Bank("BB", "001", "3349", "915700", "X");
            //emp.BankData = bank;
            //int idReturned = fac.InsertEmployee(emp);

            //MessageBox.Show("obj: " + idReturned.ToString());
            //DateTime d1 = new DateTime(1985, 12, 6);
            //DateTime d2 = new DateTime(1985, 12, 6);
            //MessageBox.Show("resultado: " + (d1 - d2).TotalHours);
        }
    }
}
