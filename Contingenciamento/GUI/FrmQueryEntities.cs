using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.User_Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmQueryEntities : Form
    {
        Facade _facade = new Facade();

        public FrmQueryEntities()
        {
            InitializeComponent();
        }

        private void FrmQueryEntities_Load(object sender, EventArgs e)
        {
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            List<Role> roles = _facade.GetTopRole();
            EntityPanel rolePanel = new EntityPanel();
            rolePanel.Datagrid.DataSource = roles;
            this.panelContent.Controls.Add(rolePanel);
        }

        private void BtnRoles_Click_1(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel rolePanel = new EntityPanel();
            List<Role> roles = _facade.GetTopRole();
            rolePanel.Datagrid.DataSource = roles;
            this.panelContent.Controls.Add(rolePanel);
        }

        private void BtnDepartments_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel departamentPanel = new EntityPanel();
            List<Department> deps = _facade.GetTopDepartment();
            departamentPanel.Datagrid.DataSource = deps;
            this.panelContent.Controls.Add(departamentPanel);
        }

        private void BtnMonetaryFunds_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnMonetaryFunds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel mfPanel = new EntityPanel();
            List<MonetaryFund> mfList = _facade.GetTopMonetaryFund();
            mfPanel.Datagrid.DataSource = mfList;
            this.panelContent.Controls.Add(mfPanel);
        }

        private void BtnContingencyFund_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnContingencyFund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel cfPanel = new EntityPanel();
            List<ContingencyFund> cfList = _facade.GetTopContigencyFund();
            cfPanel.Datagrid.DataSource = cfList;
            this.panelContent.Controls.Add(cfPanel);
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel employeePanel = new EntityPanel();
            List<Employee> emps = _facade.GetTopEmployee();
            employeePanel.Datagrid.DataSource = emps;
            this.panelContent.Controls.Add(employeePanel);
        }

        private void BtnEmployeeHistory_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnEmployeeHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel employeeHistPanel = new EntityPanel();
            List<EmployeeHistory> empHists = _facade.GetTopEmployeeHistory();
            employeeHistPanel.Datagrid.DataSource = empHists;
            this.panelContent.Controls.Add(employeeHistPanel);
        }

        private void BtnContracts_Click(object sender, EventArgs e)
        {
            this._ResetGUI();
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            EntityPanel contractPanel = new EntityPanel();
            List<Contract> contracts = _facade.GetTopContract();
            contractPanel.Datagrid.DataSource = contracts;
            this.panelContent.Controls.Add(contractPanel);
        }

        private void _ResetGUI()
        {
            this.panelContent.Controls.Clear();
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDepartments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContingencyFund.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonetaryFunds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEmployeeHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        }

        private void _AddRolesView()
        {

        }
     
    }
}
