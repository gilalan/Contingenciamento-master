using System;
using System.Data;
using System.Windows.Forms;

namespace Contingenciamento.User_Controls
{
    public partial class EntityPanel : UserControl
    {
        private DataTable dataTable { get; set; }
        public EntityPanel()
        {
            InitializeComponent();
            this.datagridView.AutoGenerateColumns = true;
        }

        public EntityPanel(DataTable dt)
        {
            this.dataTable = dt;
        }

        public String TxtId
        {
            get
            {
                return this.txtId.Text;
            }
            set
            {
                this.txtId.Text = value;
            }
        }

        public String TxtName
        {
            get
            {
                return this.txtName.Text;
            }
            set
            {
                this.txtName.Text = value;
            }
        }     
        
        public DataGridView Datagrid
        {
            get
            {
                return this.datagridView;
            }
        }

        private void FillDatagrid()
        {            
            this.datagridView.DataSource = this.dataTable;
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visualizar");
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Novo");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atualizar");
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluir");
        }
    }
}
