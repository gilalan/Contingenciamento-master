namespace Contingenciamento.GUI
{
    partial class FrmRelatorioCliente
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gBoxResultado = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTPEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTPStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxResultado.SuspendLayout();
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxResultado
            // 
            this.gBoxResultado.Controls.Add(this.txtResult);
            this.gBoxResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxResultado.ForeColor = System.Drawing.Color.OrangeRed;
            this.gBoxResultado.Location = new System.Drawing.Point(498, 41);
            this.gBoxResultado.Name = "gBoxResultado";
            this.gBoxResultado.Size = new System.Drawing.Size(490, 674);
            this.gBoxResultado.TabIndex = 7;
            this.gBoxResultado.TabStop = false;
            this.gBoxResultado.Text = "Resultado";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtResult.Font = new System.Drawing.Font("Gill Sans MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(6, 23);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(478, 645);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.cbClientes);
            this.gBoxDados.Controls.Add(this.btnSearch);
            this.gBoxDados.Controls.Add(this.dateTPEnd);
            this.gBoxDados.Controls.Add(this.label4);
            this.gBoxDados.Controls.Add(this.dateTPStart);
            this.gBoxDados.Controls.Add(this.label3);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gBoxDados.Location = new System.Drawing.Point(17, 41);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Size = new System.Drawing.Size(475, 674);
            this.gBoxDados.TabIndex = 6;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Dados";
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(9, 49);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(460, 24);
            this.cbClientes.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 163);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 43);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTPEnd
            // 
            this.dateTPEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPEnd.Location = new System.Drawing.Point(310, 110);
            this.dateTPEnd.Name = "dateTPEnd";
            this.dateTPEnd.Size = new System.Drawing.Size(159, 28);
            this.dateTPEnd.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "até";
            // 
            // dateTPStart
            // 
            this.dateTPStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPStart.Location = new System.Drawing.Point(9, 110);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(159, 28);
            this.dateTPStart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Período:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecione o Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtro de Relatório - Cliente";
            // 
            // FrmRelatorioCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1000, 774);
            this.Controls.Add(this.gBoxResultado);
            this.Controls.Add(this.gBoxDados);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRelatorioCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório por Clientes";
            this.Load += new System.EventHandler(this.FrmRelatorioCliente_Load);
            this.gBoxResultado.ResumeLayout(false);
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxResultado;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTPEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTPStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClientes;
    }
}