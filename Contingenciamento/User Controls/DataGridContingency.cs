using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Contingenciamento.User_Controls
{
    public partial class DataGridContingency : UserControl
    {
        public DataGridContingency()
        {
            InitializeComponent();
        }

        public DataGridContingency (DataTable dt, Size size)
        {
            InitializeComponent();
            this.UCTitle.Text = dt.TableName;
            this.Size = size;
            this.panel1.Width = size.Width;
            this.UCDataGrid.Size = size;
            this.UCDataGrid.AutoGenerateColumns = true;
            this.UCDataGrid.DataSource = dt;
            //this.UCDataGrid.AutoResizeColumns();
        }
    }
}
