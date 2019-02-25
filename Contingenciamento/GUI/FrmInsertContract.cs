using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertContract : Form
    {
        Facade _facade = new Facade();
        List<ContingencyFund> contingencyFunds;
        List<TextBox> contingencyFundsAliquots = new List<TextBox>();
        HashSet<Department> allDeptCodes = new HashSet<Department>(new DepartmentComparer());

        public FrmInsertContract()
        {
            InitializeComponent();
        }

        private void FrmInsertContract_Load(object sender, EventArgs e)
        {
            //Preenchendo as verbas e populando as checkBoxes
            contingencyFunds = _facade.GetTopContigencyFund();
            FillCbBox(contingencyFunds);

            //Parte do Panel que receberá as alíquotas
            contingencyFundsAliquots = new List<TextBox>(contingencyFunds.Count);
            this.panelAliquots.RowCount = contingencyFunds.Count;
            formatTxtBoxAliquot();

            //#Colunas de Verbas Monetárias
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "Código do Departamento";
            this.listDepts.Columns.Add(c1);
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Nome do Departamento";
            this.listDepts.Columns.Add(c2);
            this.listDepts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listDepts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FillCbBox(List<ContingencyFund> contingencyFunds)
        {
            var source = new BindingSource();
            source.DataSource = contingencyFunds;
            cbContigencyFunds.DataSource = source;
            cbContigencyFunds.DisplayMember = "Name";
            cbContigencyFunds.ValueMember = "Id";
        }

        private void formatTxtBoxAliquot()
        {
            TextBox t1;

            for (int i = 0; i < contingencyFunds.Count; i++)
            {
                t1 = new TextBox();
                t1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                t1.Font = new System.Drawing.Font("Microsoft Himalaya", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                t1.ForeColor = System.Drawing.Color.Maroon;
                t1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                t1.Size = new System.Drawing.Size(100, 20);
                t1.Text = i.ToString();
                t1.Enabled = false;
                if (i>0)
                    this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                //this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle());
                //this.panelAliquots.Controls.Add(t1, 0, contingencyFunds.Count-1-i);
                this.panelAliquots.Controls.Add(t1, 0, i);
                contingencyFundsAliquots.Add(t1);
            }
            
        }

        private void cbContigencyFunds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contingencyFundsAliquots.Count > 0)
            {

                int selIndex = this.cbContigencyFunds.SelectedIndex;
                if (cbContigencyFunds.GetItemChecked(selIndex))
                {
                    this.contingencyFundsAliquots[selIndex].Enabled = true;
                }
                else
                {
                    this.contingencyFundsAliquots[selIndex].Enabled = false;
                }
            }
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            string dptCode = this.txtDptCode.Text;
            Department dept = _facade.GetDepartmentByCode(dptCode);
            if (dept == null)
            {
                if (DialogResult.Yes == MessageBox.Show("Departamento não encontrado na base de dados, deseja adicioná-lo?", "Adicionar Departamento Novo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    FrmAddDepartment frmAddDepartment = new FrmAddDepartment(dptCode);                  
                    frmAddDepartment.FormClosed += new FormClosedEventHandler(_FormAddDeptClosed);
                    frmAddDepartment.ShowDialog();
                }
            }
            else
            {
                _TryAddingDept(dept);
            }
        }

        private void _TryAddingDept(Department dept)
        {
            if (this.allDeptCodes.Add(dept))
            {
                ListViewItem item;
                item = new ListViewItem();
                item.Text = dept.Code;
                item.SubItems.Add(dept.Name);
                this.listDepts.Items.Add(item);
                this.txtDptCode.Text = "";
            }
        }

        private void _FormAddDeptClosed (object sender, FormClosedEventArgs e)
        {
            FrmAddDepartment frmAddDepartment = (FrmAddDepartment)sender;
            _TryAddingDept(frmAddDepartment.Department);
        }
    }
}
