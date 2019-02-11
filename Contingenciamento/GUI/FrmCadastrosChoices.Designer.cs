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
            this.btnAddContract = new System.Windows.Forms.Button();
            this.btnContingencyFunds = new System.Windows.Forms.Button();
            this.btnMonetaryFunds = new System.Windows.Forms.Button();
            this.btnAddExtraFunds = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadAliq
            // 
            this.btnCadAliq.BackColor = System.Drawing.Color.Transparent;
            this.btnCadAliq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadAliq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadAliq.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadAliq.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadAliq.Image = global::Contingenciamento.Properties.Resources.percent_1281;
            this.btnCadAliq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadAliq.Location = new System.Drawing.Point(208, 48);
            this.btnCadAliq.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadAliq.Name = "btnCadAliq";
            this.btnCadAliq.Size = new System.Drawing.Size(139, 150);
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
            this.btnCadHistFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadHistFunc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCadHistFunc.Image = global::Contingenciamento.Properties.Resources.logo_excel_128;
            this.btnCadHistFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadHistFunc.Location = new System.Drawing.Point(39, 48);
            this.btnCadHistFunc.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadHistFunc.Name = "btnCadHistFunc";
            this.btnCadHistFunc.Size = new System.Drawing.Size(139, 150);
            this.btnCadHistFunc.TabIndex = 4;
            this.btnCadHistFunc.Text = "Cadastrar Histórico de Funcionário";
            this.btnCadHistFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCadHistFunc.UseVisualStyleBackColor = false;
            this.btnCadHistFunc.Click += new System.EventHandler(this.btnCadHistFunc_Click);
            // 
            // btnAddContract
            // 
            this.btnAddContract.Location = new System.Drawing.Point(39, 211);
            this.btnAddContract.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddContract.Name = "btnAddContract";
            this.btnAddContract.Size = new System.Drawing.Size(139, 30);
            this.btnAddContract.TabIndex = 6;
            this.btnAddContract.Text = "Cadastrar Contrato";
            this.btnAddContract.UseVisualStyleBackColor = true;
            this.btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            // 
            // btnContingencyFunds
            // 
            this.btnContingencyFunds.Location = new System.Drawing.Point(208, 211);
            this.btnContingencyFunds.Margin = new System.Windows.Forms.Padding(2);
            this.btnContingencyFunds.Name = "btnContingencyFunds";
            this.btnContingencyFunds.Size = new System.Drawing.Size(139, 37);
            this.btnContingencyFunds.TabIndex = 7;
            this.btnContingencyFunds.Text = "Cadastrar Verba de Contingenciamento";
            this.btnContingencyFunds.UseVisualStyleBackColor = true;
            this.btnContingencyFunds.Click += new System.EventHandler(this.btnContingencyFunds_Click);
            // 
            // btnMonetaryFunds
            // 
            this.btnMonetaryFunds.Location = new System.Drawing.Point(39, 257);
            this.btnMonetaryFunds.Margin = new System.Windows.Forms.Padding(2);
            this.btnMonetaryFunds.Name = "btnMonetaryFunds";
            this.btnMonetaryFunds.Size = new System.Drawing.Size(139, 37);
            this.btnMonetaryFunds.TabIndex = 8;
            this.btnMonetaryFunds.Text = "Cadastrar Verbas Monetárias de Base";
            this.btnMonetaryFunds.UseVisualStyleBackColor = true;
            this.btnMonetaryFunds.Click += new System.EventHandler(this.btnMonetaryFunds_Click);
            // 
            // btnAddExtraFunds
            // 
            this.btnAddExtraFunds.Location = new System.Drawing.Point(208, 257);
            this.btnAddExtraFunds.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddExtraFunds.Name = "btnAddExtraFunds";
            this.btnAddExtraFunds.Size = new System.Drawing.Size(139, 37);
            this.btnAddExtraFunds.TabIndex = 9;
            this.btnAddExtraFunds.Text = "Cadastrar Verbas Monetárias Adicionais";
            this.btnAddExtraFunds.UseVisualStyleBackColor = true;
            this.btnAddExtraFunds.Click += new System.EventHandler(this.btnAddExtraFunds_Click);
            // 
            // FrmCadastrosChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(386, 305);
            this.Controls.Add(this.btnAddExtraFunds);
            this.Controls.Add(this.btnMonetaryFunds);
            this.Controls.Add(this.btnContingencyFunds);
            this.Controls.Add(this.btnAddContract);
            this.Controls.Add(this.btnCadAliq);
            this.Controls.Add(this.btnCadHistFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmCadastrosChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Cadastro ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadAliq;
        private System.Windows.Forms.Button btnCadHistFunc;
        private System.Windows.Forms.Button btnAddContract;
        private System.Windows.Forms.Button btnContingencyFunds;
        private System.Windows.Forms.Button btnMonetaryFunds;
        private System.Windows.Forms.Button btnAddExtraFunds;
    }
}