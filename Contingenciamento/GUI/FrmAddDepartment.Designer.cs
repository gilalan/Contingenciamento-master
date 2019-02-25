namespace Contingenciamento.GUI
{
    partial class FrmAddDepartment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveDepto = new System.Windows.Forms.Button();
            this.txtDptCode = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código do Departamento:";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Location = new System.Drawing.Point(193, 49);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(317, 22);
            this.txtDeptName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome do Departamento:";
            // 
            // btnSaveDepto
            // 
            this.btnSaveDepto.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveDepto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveDepto.Location = new System.Drawing.Point(15, 87);
            this.btnSaveDepto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveDepto.Name = "btnSaveDepto";
            this.btnSaveDepto.Size = new System.Drawing.Size(112, 47);
            this.btnSaveDepto.TabIndex = 10;
            this.btnSaveDepto.Text = "Salvar";
            this.btnSaveDepto.UseVisualStyleBackColor = false;
            this.btnSaveDepto.Click += new System.EventHandler(this.btnSaveDepto_Click);
            // 
            // txtDptCode
            // 
            this.txtDptCode.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDptCode.Location = new System.Drawing.Point(193, 16);
            this.txtDptCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDptCode.Mask = "000,999,999";
            this.txtDptCode.Name = "txtDptCode";
            this.txtDptCode.Size = new System.Drawing.Size(116, 22);
            this.txtDptCode.TabIndex = 35;
            this.txtDptCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // FrmAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(522, 145);
            this.Controls.Add(this.txtDptCode);
            this.Controls.Add(this.btnSaveDepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeptName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Departamento";
            this.Load += new System.EventHandler(this.FrmAddDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDepto;
        private System.Windows.Forms.MaskedTextBox txtDptCode;
    }
}