namespace Contingenciamento.GUI
{
    partial class FrmAllFunds
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
            this.btnSaveContingencyFunds = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.listContingencyFunds = new System.Windows.Forms.ListView();
            this.txtContingencyFunds = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listMonetaryFunds = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveMonetaryFunds = new System.Windows.Forms.Button();
            this.txtMonetaryFunds = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listExtraFunds = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveExtraFunds = new System.Windows.Forms.Button();
            this.cbMonetaryFunds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExtraFunds = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gBoxDados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveContingencyFunds
            // 
            this.btnSaveContingencyFunds.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveContingencyFunds.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveContingencyFunds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveContingencyFunds.Location = new System.Drawing.Point(324, 391);
            this.btnSaveContingencyFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveContingencyFunds.Name = "btnSaveContingencyFunds";
            this.btnSaveContingencyFunds.Size = new System.Drawing.Size(66, 27);
            this.btnSaveContingencyFunds.TabIndex = 2;
            this.btnSaveContingencyFunds.Text = "Salvar";
            this.btnSaveContingencyFunds.UseVisualStyleBackColor = false;
            this.btnSaveContingencyFunds.Click += new System.EventHandler(this.btnSaveContingencyFunds_Click);
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.listContingencyFunds);
            this.gBoxDados.Controls.Add(this.btnSaveContingencyFunds);
            this.gBoxDados.Controls.Add(this.txtContingencyFunds);
            this.gBoxDados.Controls.Add(this.label1);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(12, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Size = new System.Drawing.Size(396, 428);
            this.gBoxDados.TabIndex = 13;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Verbas de Contingenciamento";
            // 
            // listContingencyFunds
            // 
            this.listContingencyFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContingencyFunds.FullRowSelect = true;
            this.listContingencyFunds.GridLines = true;
            this.listContingencyFunds.Location = new System.Drawing.Point(9, 56);
            this.listContingencyFunds.Name = "listContingencyFunds";
            this.listContingencyFunds.Size = new System.Drawing.Size(381, 308);
            this.listContingencyFunds.TabIndex = 18;
            this.listContingencyFunds.UseCompatibleStateImageBehavior = false;
            this.listContingencyFunds.View = System.Windows.Forms.View.Details;
            // 
            // txtContingencyFunds
            // 
            this.txtContingencyFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContingencyFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContingencyFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtContingencyFunds.Location = new System.Drawing.Point(9, 391);
            this.txtContingencyFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContingencyFunds.Name = "txtContingencyFunds";
            this.txtContingencyFunds.Size = new System.Drawing.Size(312, 27);
            this.txtContingencyFunds.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cadastradas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(6, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para cadastrar uma nova Verba:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listMonetaryFunds);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSaveMonetaryFunds);
            this.groupBox1.Controls.Add(this.txtMonetaryFunds);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(414, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(396, 428);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verbas Monetárias";
            // 
            // listMonetaryFunds
            // 
            this.listMonetaryFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMonetaryFunds.FullRowSelect = true;
            this.listMonetaryFunds.GridLines = true;
            this.listMonetaryFunds.Location = new System.Drawing.Point(9, 56);
            this.listMonetaryFunds.Name = "listMonetaryFunds";
            this.listMonetaryFunds.Size = new System.Drawing.Size(381, 308);
            this.listMonetaryFunds.TabIndex = 19;
            this.listMonetaryFunds.UseCompatibleStateImageBehavior = false;
            this.listMonetaryFunds.View = System.Windows.Forms.View.Details;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cadastradas:";
            // 
            // btnSaveMonetaryFunds
            // 
            this.btnSaveMonetaryFunds.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveMonetaryFunds.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMonetaryFunds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveMonetaryFunds.Location = new System.Drawing.Point(324, 391);
            this.btnSaveMonetaryFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveMonetaryFunds.Name = "btnSaveMonetaryFunds";
            this.btnSaveMonetaryFunds.Size = new System.Drawing.Size(66, 27);
            this.btnSaveMonetaryFunds.TabIndex = 4;
            this.btnSaveMonetaryFunds.Text = "Salvar";
            this.btnSaveMonetaryFunds.UseVisualStyleBackColor = false;
            this.btnSaveMonetaryFunds.Click += new System.EventHandler(this.btnSaveMonetaryFunds_Click);
            // 
            // txtMonetaryFunds
            // 
            this.txtMonetaryFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonetaryFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonetaryFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtMonetaryFunds.Location = new System.Drawing.Point(9, 391);
            this.txtMonetaryFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonetaryFunds.Name = "txtMonetaryFunds";
            this.txtMonetaryFunds.Size = new System.Drawing.Size(312, 27);
            this.txtMonetaryFunds.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(10, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Informe o nome para a Verba Base:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listExtraFunds);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnSaveExtraFunds);
            this.groupBox2.Controls.Add(this.cbMonetaryFunds);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtExtraFunds);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox2.Location = new System.Drawing.Point(816, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(396, 428);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verbas Adicionais";
            // 
            // listExtraFunds
            // 
            this.listExtraFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listExtraFunds.FullRowSelect = true;
            this.listExtraFunds.GridLines = true;
            this.listExtraFunds.Location = new System.Drawing.Point(9, 57);
            this.listExtraFunds.Name = "listExtraFunds";
            this.listExtraFunds.Size = new System.Drawing.Size(381, 254);
            this.listExtraFunds.TabIndex = 28;
            this.listExtraFunds.UseCompatibleStateImageBehavior = false;
            this.listExtraFunds.View = System.Windows.Forms.View.Details;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Location = new System.Drawing.Point(9, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Cadastradas:";
            // 
            // btnSaveExtraFunds
            // 
            this.btnSaveExtraFunds.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveExtraFunds.Font = new System.Drawing.Font("Modern No. 20", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExtraFunds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveExtraFunds.Location = new System.Drawing.Point(324, 391);
            this.btnSaveExtraFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveExtraFunds.Name = "btnSaveExtraFunds";
            this.btnSaveExtraFunds.Size = new System.Drawing.Size(66, 27);
            this.btnSaveExtraFunds.TabIndex = 7;
            this.btnSaveExtraFunds.Text = "Salvar";
            this.btnSaveExtraFunds.UseVisualStyleBackColor = false;
            this.btnSaveExtraFunds.Click += new System.EventHandler(this.btnSaveExtraFunds_Click);
            // 
            // cbMonetaryFunds
            // 
            this.cbMonetaryFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonetaryFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonetaryFunds.FormattingEnabled = true;
            this.cbMonetaryFunds.Location = new System.Drawing.Point(9, 336);
            this.cbMonetaryFunds.Margin = new System.Windows.Forms.Padding(4);
            this.cbMonetaryFunds.Name = "cbMonetaryFunds";
            this.cbMonetaryFunds.Size = new System.Drawing.Size(312, 28);
            this.cbMonetaryFunds.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(6, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Selecione a Verba Base:";
            // 
            // txtExtraFunds
            // 
            this.txtExtraFunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtraFunds.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtraFunds.ForeColor = System.Drawing.Color.Maroon;
            this.txtExtraFunds.Location = new System.Drawing.Point(9, 391);
            this.txtExtraFunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExtraFunds.Name = "txtExtraFunds";
            this.txtExtraFunds.Size = new System.Drawing.Size(312, 27);
            this.txtExtraFunds.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(6, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(278, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Informe o nome para a Verba Adicional:";
            // 
            // FrmAllFunds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1224, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gBoxDados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAllFunds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Vários Tipos de Verbas";
            this.Load += new System.EventHandler(this.FrmAllFunds_Load);
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveContingencyFunds;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.TextBox txtContingencyFunds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMonetaryFunds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbMonetaryFunds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExtraFunds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveMonetaryFunds;
        private System.Windows.Forms.Button btnSaveExtraFunds;
        private System.Windows.Forms.ListView listContingencyFunds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listMonetaryFunds;
        private System.Windows.Forms.ListView listExtraFunds;
    }
}