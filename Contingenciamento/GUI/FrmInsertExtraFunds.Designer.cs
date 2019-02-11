namespace Contingenciamento.GUI
{
    partial class FrmInsertExtraFunds
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
            this.btnSave = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.txtExtraFunds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMonetaryFunds = new System.Windows.Forms.ComboBox();
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(11, 160);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 38);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.cbMonetaryFunds);
            this.gBoxDados.Controls.Add(this.label3);
            this.gBoxDados.Controls.Add(this.txtExtraFunds);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(11, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Size = new System.Drawing.Size(297, 145);
            this.gBoxDados.TabIndex = 15;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Nova Verba Secundária";
            // 
            // txtExtraFunds
            // 
            this.txtExtraFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtraFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtraFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtExtraFunds.Location = new System.Drawing.Point(7, 108);
            this.txtExtraFunds.Margin = new System.Windows.Forms.Padding(2);
            this.txtExtraFunds.Name = "txtExtraFunds";
            this.txtExtraFunds.Size = new System.Drawing.Size(282, 23);
            this.txtExtraFunds.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para a Verba Secundária:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(4, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Selecione a Verba Base:";
            // 
            // cbMonetaryFunds
            // 
            this.cbMonetaryFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonetaryFunds.FormattingEnabled = true;
            this.cbMonetaryFunds.Location = new System.Drawing.Point(7, 50);
            this.cbMonetaryFunds.Name = "cbMonetaryFunds";
            this.cbMonetaryFunds.Size = new System.Drawing.Size(282, 25);
            this.cbMonetaryFunds.TabIndex = 28;
            // 
            // FrmInsertExtraFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(321, 208);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInsertExtraFunds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Verbas Secundárias";
            this.Load += new System.EventHandler(this.FrmInsertExtraFunds_Load);
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.ComboBox cbMonetaryFunds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtraFunds;
        private System.Windows.Forms.Label label2;
    }
}