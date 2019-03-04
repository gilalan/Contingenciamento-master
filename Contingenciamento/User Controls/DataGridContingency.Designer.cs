namespace Contingenciamento.User_Controls
{
    partial class DataGridContingency
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UCDataGrid = new System.Windows.Forms.DataGridView();
            this.UCTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.UCDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UCDataGrid
            // 
            this.UCDataGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.UCDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UCDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.UCDataGrid.Location = new System.Drawing.Point(3, 41);
            this.UCDataGrid.Name = "UCDataGrid";
            this.UCDataGrid.ReadOnly = true;
            this.UCDataGrid.RowTemplate.Height = 24;
            this.UCDataGrid.Size = new System.Drawing.Size(828, 240);
            this.UCDataGrid.TabIndex = 0;
            // 
            // UCTitle
            // 
            this.UCTitle.AutoSize = true;
            this.UCTitle.Font = new System.Drawing.Font("Museo Sans For Dell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UCTitle.ForeColor = System.Drawing.Color.White;
            this.UCTitle.Location = new System.Drawing.Point(3, 5);
            this.UCTitle.Name = "UCTitle";
            this.UCTitle.Size = new System.Drawing.Size(112, 23);
            this.UCTitle.TabIndex = 1;
            this.UCTitle.Text = "TableName";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.Controls.Add(this.UCTitle);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel1.Size = new System.Drawing.Size(834, 32);
            this.panel1.TabIndex = 2;
            // 
            // DataGridContingency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UCDataGrid);
            this.Name = "DataGridContingency";
            this.Size = new System.Drawing.Size(834, 284);
            ((System.ComponentModel.ISupportInitialize)(this.UCDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UCDataGrid;
        private System.Windows.Forms.Label UCTitle;
        private System.Windows.Forms.Panel panel1;
    }
}
