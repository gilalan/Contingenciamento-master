namespace Contingenciamento.GUI
{
    partial class FrmInsertMonetaryFunds
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
            this.panelGroupBox = new System.Windows.Forms.Panel();
            this.rbPrimalFundYes = new System.Windows.Forms.RadioButton();
            this.rbPrimalFundNo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonetaryFunds = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxDados.SuspendLayout();
            this.panelGroupBox.SuspendLayout();
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
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.panelGroupBox);
            this.gBoxDados.Controls.Add(this.label1);
            this.gBoxDados.Controls.Add(this.txtMonetaryFunds);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(11, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Size = new System.Drawing.Size(297, 145);
            this.gBoxDados.TabIndex = 13;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Nova Verba Monetária";
            // 
            // panelGroupBox
            // 
            this.panelGroupBox.Controls.Add(this.rbPrimalFundYes);
            this.panelGroupBox.Controls.Add(this.rbPrimalFundNo);
            this.panelGroupBox.Location = new System.Drawing.Point(7, 106);
            this.panelGroupBox.Name = "panelGroupBox";
            this.panelGroupBox.Size = new System.Drawing.Size(158, 29);
            this.panelGroupBox.TabIndex = 26;
            // 
            // rbPrimalFundYes
            // 
            this.rbPrimalFundYes.AutoSize = true;
            this.rbPrimalFundYes.Checked = true;
            this.rbPrimalFundYes.ForeColor = System.Drawing.Color.DarkBlue;
            this.rbPrimalFundYes.Location = new System.Drawing.Point(3, 3);
            this.rbPrimalFundYes.Name = "rbPrimalFundYes";
            this.rbPrimalFundYes.Size = new System.Drawing.Size(49, 21);
            this.rbPrimalFundYes.TabIndex = 24;
            this.rbPrimalFundYes.TabStop = true;
            this.rbPrimalFundYes.Text = "Sim";
            this.rbPrimalFundYes.UseVisualStyleBackColor = true;
            // 
            // rbPrimalFundNo
            // 
            this.rbPrimalFundNo.AutoSize = true;
            this.rbPrimalFundNo.ForeColor = System.Drawing.Color.DarkBlue;
            this.rbPrimalFundNo.Location = new System.Drawing.Point(97, 3);
            this.rbPrimalFundNo.Name = "rbPrimalFundNo";
            this.rbPrimalFundNo.Size = new System.Drawing.Size(52, 21);
            this.rbPrimalFundNo.TabIndex = 25;
            this.rbPrimalFundNo.Text = "Não";
            this.rbPrimalFundNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(4, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "É uma Verba primária?";
            // 
            // txtMonetaryFunds
            // 
            this.txtMonetaryFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonetaryFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonetaryFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtMonetaryFunds.Location = new System.Drawing.Point(7, 47);
            this.txtMonetaryFunds.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonetaryFunds.Name = "txtMonetaryFunds";
            this.txtMonetaryFunds.Size = new System.Drawing.Size(282, 23);
            this.txtMonetaryFunds.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para a Verba Base:";
            // 
            // FrmInsertMonetaryFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(319, 209);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInsertMonetaryFunds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir Verbas de Base para Cálculo do Contingenciamento";
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.panelGroupBox.ResumeLayout(false);
            this.panelGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.Panel panelGroupBox;
        private System.Windows.Forms.RadioButton rbPrimalFundYes;
        private System.Windows.Forms.RadioButton rbPrimalFundNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonetaryFunds;
        private System.Windows.Forms.Label label2;
    }
}