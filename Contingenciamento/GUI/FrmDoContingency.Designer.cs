namespace Contingenciamento.GUI
{
    partial class FrmDoContingency
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
            this.gbData = new System.Windows.Forms.GroupBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtEmployeesCount = new System.Windows.Forms.TextBox();
            this.txtContractDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.treeMonetaryFunds = new System.Windows.Forms.TreeView();
            this.listContFundsAliquots = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbContracts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoConting = new System.Windows.Forms.Button();
            this.pbContingency = new System.Windows.Forms.ProgressBar();
            this.bgWorkDatabase = new System.ComponentModel.BackgroundWorker();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.btnOpenViewContingency = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gbData.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.txtBalance);
            this.gbData.Controls.Add(this.label9);
            this.gbData.Controls.Add(this.label4);
            this.gbData.Controls.Add(this.txtOutput);
            this.gbData.Controls.Add(this.txtEmployeesCount);
            this.gbData.Controls.Add(this.txtContractDescription);
            this.gbData.Controls.Add(this.label8);
            this.gbData.Controls.Add(this.label7);
            this.gbData.Controls.Add(this.txtContractName);
            this.gbData.Controls.Add(this.label6);
            this.gbData.Controls.Add(this.treeMonetaryFunds);
            this.gbData.Controls.Add(this.listContFundsAliquots);
            this.gbData.Controls.Add(this.label5);
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.cbContracts);
            this.gbData.Controls.Add(this.label1);
            this.gbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(1293, 472);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "Dados de Entrada";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(747, 259);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(53, 24);
            this.txtBalance.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(523, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 18);
            this.label9.TabIndex = 64;
            this.label9.Text = "Saldo de Contingenciamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(8, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 18);
            this.label4.TabIndex = 62;
            this.label4.Text = "Resumo do Contingenciamento:";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.Indigo;
            this.txtOutput.Location = new System.Drawing.Point(9, 309);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(1277, 156);
            this.txtOutput.TabIndex = 63;
            // 
            // txtEmployeesCount
            // 
            this.txtEmployeesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeesCount.Location = new System.Drawing.Point(411, 259);
            this.txtEmployeesCount.Name = "txtEmployeesCount";
            this.txtEmployeesCount.ReadOnly = true;
            this.txtEmployeesCount.Size = new System.Drawing.Size(53, 24);
            this.txtEmployeesCount.TabIndex = 48;
            // 
            // txtContractDescription
            // 
            this.txtContractDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractDescription.Location = new System.Drawing.Point(9, 141);
            this.txtContractDescription.Multiline = true;
            this.txtContractDescription.Name = "txtContractDescription";
            this.txtContractDescription.ReadOnly = true;
            this.txtContractDescription.Size = new System.Drawing.Size(347, 106);
            this.txtContractDescription.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "Descrição do Contrato:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "Contrato:";
            // 
            // txtContractName
            // 
            this.txtContractName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.Location = new System.Drawing.Point(9, 90);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.ReadOnly = true;
            this.txtContractName.Size = new System.Drawing.Size(347, 24);
            this.txtContractName.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(729, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 18);
            this.label6.TabIndex = 43;
            this.label6.Text = "Escolha apenas UMA verba monetária para aplicar as alíquotas:";
            // 
            // treeMonetaryFunds
            // 
            this.treeMonetaryFunds.CheckBoxes = true;
            this.treeMonetaryFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMonetaryFunds.Location = new System.Drawing.Point(732, 91);
            this.treeMonetaryFunds.Margin = new System.Windows.Forms.Padding(4);
            this.treeMonetaryFunds.Name = "treeMonetaryFunds";
            this.treeMonetaryFunds.Size = new System.Drawing.Size(554, 156);
            this.treeMonetaryFunds.TabIndex = 42;
            this.treeMonetaryFunds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeMonetaryFunds_AfterCheck);
            // 
            // listContFundsAliquots
            // 
            this.listContFundsAliquots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContFundsAliquots.FullRowSelect = true;
            this.listContFundsAliquots.GridLines = true;
            this.listContFundsAliquots.HideSelection = false;
            this.listContFundsAliquots.Location = new System.Drawing.Point(362, 90);
            this.listContFundsAliquots.MultiSelect = false;
            this.listContFundsAliquots.Name = "listContFundsAliquots";
            this.listContFundsAliquots.Size = new System.Drawing.Size(363, 157);
            this.listContFundsAliquots.TabIndex = 41;
            this.listContFundsAliquots.UseCompatibleStateImageBehavior = false;
            this.listContFundsAliquots.View = System.Windows.Forms.View.Details;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(6, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(361, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Quantidade de Funcionários associados ao Contrato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verbas de contingência associadas ao Contrato atual:";
            // 
            // cbContracts
            // 
            this.cbContracts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContracts.FormattingEnabled = true;
            this.cbContracts.Location = new System.Drawing.Point(362, 24);
            this.cbContracts.Name = "cbContracts";
            this.cbContracts.Size = new System.Drawing.Size(507, 26);
            this.cbContracts.TabIndex = 1;
            this.cbContracts.SelectedIndexChanged += new System.EventHandler(this.cbContracts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione um Contrato para contingenciar:";
            // 
            // btnDoConting
            // 
            this.btnDoConting.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDoConting.Font = new System.Drawing.Font("FontAwesome", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoConting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDoConting.Location = new System.Drawing.Point(23, 489);
            this.btnDoConting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDoConting.Name = "btnDoConting";
            this.btnDoConting.Size = new System.Drawing.Size(123, 39);
            this.btnDoConting.TabIndex = 10;
            this.btnDoConting.Text = "Contingenciar";
            this.btnDoConting.UseVisualStyleBackColor = false;
            this.btnDoConting.Click += new System.EventHandler(this.btnDoConting_Click);
            // 
            // pbContingency
            // 
            this.pbContingency.Location = new System.Drawing.Point(152, 497);
            this.pbContingency.Name = "pbContingency";
            this.pbContingency.Size = new System.Drawing.Size(1146, 24);
            this.pbContingency.TabIndex = 49;
            // 
            // bgWorkDatabase
            // 
            this.bgWorkDatabase.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkDatabase_DoWork);
            this.bgWorkDatabase.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkDatabase_RunWorkerCompleted);
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Location = new System.Drawing.Point(385, 321);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(0, 17);
            this.lblWaiting.TabIndex = 50;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.btnOpenViewContingency);
            this.gbResult.Controls.Add(this.label3);
            this.gbResult.Enabled = false;
            this.gbResult.Location = new System.Drawing.Point(12, 545);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(1293, 71);
            this.gbResult.TabIndex = 51;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Resultado do Contingenciamento";
            // 
            // btnOpenViewContingency
            // 
            this.btnOpenViewContingency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(112)))));
            this.btnOpenViewContingency.Font = new System.Drawing.Font("FontAwesome", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenViewContingency.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenViewContingency.Location = new System.Drawing.Point(11, 24);
            this.btnOpenViewContingency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenViewContingency.Name = "btnOpenViewContingency";
            this.btnOpenViewContingency.Size = new System.Drawing.Size(123, 29);
            this.btnOpenViewContingency.TabIndex = 56;
            this.btnOpenViewContingency.Text = "Clique aqui";
            this.btnOpenViewContingency.UseVisualStyleBackColor = false;
            this.btnOpenViewContingency.Click += new System.EventHandler(this.btnOpenViewContingency_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(461, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "para visualizar o resultado do Contingenciamento em uma tela cheia.";
            // 
            // FrmDoContingency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1317, 627);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.pbContingency);
            this.Controls.Add(this.btnDoConting);
            this.Controls.Add(this.gbData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDoContingency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processar Contingenciamento";
            this.Load += new System.EventHandler(this.FrmDoContingency_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbContracts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDoConting;
        private System.Windows.Forms.ListView listContFundsAliquots;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeMonetaryFunds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.TextBox txtContractDescription;
        private System.Windows.Forms.TextBox txtEmployeesCount;
        private System.Windows.Forms.ProgressBar pbContingency;
        private System.ComponentModel.BackgroundWorker bgWorkDatabase;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenViewContingency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label9;
    }
}