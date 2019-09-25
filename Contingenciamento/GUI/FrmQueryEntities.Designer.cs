namespace Contingenciamento.GUI
{
    partial class FrmQueryEntities
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
            this.btnEmployeeHistory = new System.Windows.Forms.Button();
            this.btnContracts = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnContingencyFund = new System.Windows.Forms.Button();
            this.btnMonetaryFunds = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEmployeeHistory
            // 
            this.btnEmployeeHistory.Location = new System.Drawing.Point(6, 273);
            this.btnEmployeeHistory.Name = "btnEmployeeHistory";
            this.btnEmployeeHistory.Size = new System.Drawing.Size(169, 52);
            this.btnEmployeeHistory.TabIndex = 12;
            this.btnEmployeeHistory.Text = "Histórico de Funcionários";
            this.btnEmployeeHistory.UseVisualStyleBackColor = true;
            this.btnEmployeeHistory.Click += new System.EventHandler(this.BtnEmployeeHistory_Click);
            // 
            // btnContracts
            // 
            this.btnContracts.Location = new System.Drawing.Point(6, 331);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(169, 41);
            this.btnContracts.TabIndex = 10;
            this.btnContracts.Text = "Contratos";
            this.btnContracts.UseVisualStyleBackColor = true;
            this.btnContracts.Click += new System.EventHandler(this.BtnContracts_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(6, 226);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(169, 41);
            this.btnEmployees.TabIndex = 11;
            this.btnEmployees.Text = "Funcionários";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.BtnEmployees_Click);
            // 
            // btnContingencyFund
            // 
            this.btnContingencyFund.Location = new System.Drawing.Point(6, 162);
            this.btnContingencyFund.Name = "btnContingencyFund";
            this.btnContingencyFund.Size = new System.Drawing.Size(169, 58);
            this.btnContingencyFund.TabIndex = 9;
            this.btnContingencyFund.Text = "Verbas de Contingenciamento";
            this.btnContingencyFund.UseVisualStyleBackColor = true;
            this.btnContingencyFund.Click += new System.EventHandler(this.BtnContingencyFund_Click);
            // 
            // btnMonetaryFunds
            // 
            this.btnMonetaryFunds.Location = new System.Drawing.Point(6, 115);
            this.btnMonetaryFunds.Name = "btnMonetaryFunds";
            this.btnMonetaryFunds.Size = new System.Drawing.Size(169, 41);
            this.btnMonetaryFunds.TabIndex = 8;
            this.btnMonetaryFunds.Text = "Verbas Monetárias";
            this.btnMonetaryFunds.UseVisualStyleBackColor = true;
            this.btnMonetaryFunds.Click += new System.EventHandler(this.BtnMonetaryFunds_Click);
            // 
            // btnDepartments
            // 
            this.btnDepartments.Location = new System.Drawing.Point(6, 68);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(169, 41);
            this.btnDepartments.TabIndex = 7;
            this.btnDepartments.Text = "Departamentos";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.BtnDepartments_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRoles.Location = new System.Drawing.Point(6, 21);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(169, 41);
            this.btnRoles.TabIndex = 6;
            this.btnRoles.Text = "Cargos";
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.BtnRoles_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRoles);
            this.groupBox1.Controls.Add(this.btnEmployeeHistory);
            this.groupBox1.Controls.Add(this.btnDepartments);
            this.groupBox1.Controls.Add(this.btnContracts);
            this.groupBox1.Controls.Add(this.btnMonetaryFunds);
            this.groupBox1.Controls.Add(this.btnEmployees);
            this.groupBox1.Controls.Add(this.btnContingencyFund);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(59)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 643);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione a Entidade";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelContent);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(59)))), ((int)(((byte)(128)))));
            this.groupBox2.Location = new System.Drawing.Point(199, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 643);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultar e Editar a Entidade";
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(6, 21);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(792, 614);
            this.panelContent.TabIndex = 0;
            // 
            // FrmQueryEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1014, 663);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmQueryEntities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Entidades do Sistema";
            this.Load += new System.EventHandler(this.FrmQueryEntities_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployeeHistory;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnContingencyFund;
        private System.Windows.Forms.Button btnMonetaryFunds;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelContent;
    }
}