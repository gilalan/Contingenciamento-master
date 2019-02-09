namespace Contingenciamento.GUI
{
    partial class FrmCadastrosChoices
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
            this.btnCadAliq = new System.Windows.Forms.Button();
            this.btnCadHistFunc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadAliq
            // 
            this.btnCadAliq.BackColor = System.Drawing.Color.Transparent;
            this.btnCadAliq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadAliq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadAliq.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadAliq.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadAliq.Image = global::Contingenciamento.Properties.Resources.percent_1281;
            this.btnCadAliq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadAliq.Location = new System.Drawing.Point(278, 59);
            this.btnCadAliq.Name = "btnCadAliq";
            this.btnCadAliq.Size = new System.Drawing.Size(185, 185);
            this.btnCadAliq.TabIndex = 5;
            this.btnCadAliq.Text = "Cadastrar Alíquotas de Clientes ou Contratos";
            this.btnCadAliq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCadAliq.UseVisualStyleBackColor = false;
            this.btnCadAliq.Click += new System.EventHandler(this.btnCadAliq_Click);
            // 
            // btnCadHistFunc
            // 
            this.btnCadHistFunc.BackColor = System.Drawing.Color.Transparent;
            this.btnCadHistFunc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadHistFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadHistFunc.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadHistFunc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadHistFunc.Image = global::Contingenciamento.Properties.Resources.logo_excel_128;
            this.btnCadHistFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadHistFunc.Location = new System.Drawing.Point(52, 59);
            this.btnCadHistFunc.Name = "btnCadHistFunc";
            this.btnCadHistFunc.Size = new System.Drawing.Size(185, 185);
            this.btnCadHistFunc.TabIndex = 4;
            this.btnCadHistFunc.Text = "Cadastrar Histórico de Funcionário";
            this.btnCadHistFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCadHistFunc.UseVisualStyleBackColor = false;
            this.btnCadHistFunc.Click += new System.EventHandler(this.btnCadHistFunc_Click);
            // 
            // FrmCadastrosChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(514, 303);
            this.Controls.Add(this.btnCadAliq);
            this.Controls.Add(this.btnCadHistFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCadastrosChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Cadastro ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadAliq;
        private System.Windows.Forms.Button btnCadHistFunc;
    }
}