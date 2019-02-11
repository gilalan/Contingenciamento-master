namespace Contingenciamento.GUI
{
    partial class FrmInsertContingencyFunds
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
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.txtContingencyFunds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.txtContingencyFunds);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(11, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Size = new System.Drawing.Size(297, 86);
            this.gBoxDados.TabIndex = 11;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Nova Verba de Contingenciamento";
            // 
            // txtContingencyFunds
            // 
            this.txtContingencyFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContingencyFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContingencyFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtContingencyFunds.Location = new System.Drawing.Point(7, 47);
            this.txtContingencyFunds.Margin = new System.Windows.Forms.Padding(2);
            this.txtContingencyFunds.Name = "txtContingencyFunds";
            this.txtContingencyFunds.Size = new System.Drawing.Size(282, 23);
            this.txtContingencyFunds.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para a Verba:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(11, 101);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 38);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmInsertContingencyFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(318, 149);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInsertContingencyFunds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir Verba de Contingenciamento";
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.TextBox txtContingencyFunds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}