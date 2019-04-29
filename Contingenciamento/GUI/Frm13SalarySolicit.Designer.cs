namespace Contingenciamento.GUI
{
    partial class Frm13SalarySolicit
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtEmployeesCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContractDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbContracts = new System.Windows.Forms.ComboBox();
            this.cbLowYear = new System.Windows.Forms.ComboBox();
            this.sfDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLowYear);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.txtEmployeesCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtContractDescription);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtContractName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbContracts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1015, 134);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parâmetros de Entrada";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExport.Font = new System.Drawing.Font("FontAwesome", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Location = new System.Drawing.Point(6, 90);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(123, 39);
            this.btnExport.TabIndex = 59;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtEmployeesCount
            // 
            this.txtEmployeesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeesCount.Location = new System.Drawing.Point(737, 102);
            this.txtEmployeesCount.Name = "txtEmployeesCount";
            this.txtEmployeesCount.ReadOnly = true;
            this.txtEmployeesCount.Size = new System.Drawing.Size(53, 22);
            this.txtEmployeesCount.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(633, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "Funcionários:";
            // 
            // txtContractDescription
            // 
            this.txtContractDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractDescription.Location = new System.Drawing.Point(737, 43);
            this.txtContractDescription.Multiline = true;
            this.txtContractDescription.Name = "txtContractDescription";
            this.txtContractDescription.ReadOnly = true;
            this.txtContractDescription.Size = new System.Drawing.Size(267, 48);
            this.txtContractDescription.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(633, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Descrição:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(633, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Contrato:";
            // 
            // txtContractName
            // 
            this.txtContractName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.Location = new System.Drawing.Point(737, 15);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.ReadOnly = true;
            this.txtContractName.Size = new System.Drawing.Size(267, 22);
            this.txtContractName.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selecione um período para visualizar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione um Contrato para visualizar:";
            // 
            // cbContracts
            // 
            this.cbContracts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContracts.FormattingEnabled = true;
            this.cbContracts.Location = new System.Drawing.Point(274, 15);
            this.cbContracts.Name = "cbContracts";
            this.cbContracts.Size = new System.Drawing.Size(342, 24);
            this.cbContracts.TabIndex = 4;
            this.cbContracts.SelectedIndexChanged += new System.EventHandler(this.cbContracts_SelectedIndexChanged);
            // 
            // cbLowYear
            // 
            this.cbLowYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLowYear.FormattingEnabled = true;
            this.cbLowYear.Location = new System.Drawing.Point(274, 53);
            this.cbLowYear.Name = "cbLowYear";
            this.cbLowYear.Size = new System.Drawing.Size(114, 28);
            this.cbLowYear.TabIndex = 60;
            // 
            // Frm13SalarySolicit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1039, 170);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm13SalarySolicit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitação de 13º Salário";
            this.Load += new System.EventHandler(this.Frm13SalarySolicit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtEmployeesCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContractDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbContracts;
        private System.Windows.Forms.ComboBox cbLowYear;
        private System.Windows.Forms.SaveFileDialog sfDlg;
    }
}