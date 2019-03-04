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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbYears = new System.Windows.Forms.ComboBox();
            this.btnOpenViewContingency = new System.Windows.Forms.Button();
            this.gbData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbData
            // 
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
            this.gbData.Size = new System.Drawing.Size(1293, 292);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "Dados de Entrada";
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
            this.treeMonetaryFunds.Size = new System.Drawing.Size(554, 157);
            this.treeMonetaryFunds.TabIndex = 42;
            this.treeMonetaryFunds.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeMonetaryFunds_AfterCheck);
            // 
            // listContFundsAliquots
            // 
            this.listContFundsAliquots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContFundsAliquots.FullRowSelect = true;
            this.listContFundsAliquots.GridLines = true;
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
            this.btnDoConting.Location = new System.Drawing.Point(12, 309);
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
            this.pbContingency.Location = new System.Drawing.Point(152, 311);
            this.pbContingency.Name = "pbContingency";
            this.pbContingency.Size = new System.Drawing.Size(227, 37);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenViewContingency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbYears);
            this.groupBox1.Location = new System.Drawing.Point(12, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1293, 279);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado do Contingenciamento";
            // 
            // panelGrid
            // 
            this.panelGrid.AutoScroll = true;
            this.panelGrid.BackColor = System.Drawing.Color.Gainsboro;
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGrid.Location = new System.Drawing.Point(12, 407);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1286, 220);
            this.panelGrid.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "Ano:";
            // 
            // cbYears
            // 
            this.cbYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYears.FormattingEnabled = true;
            this.cbYears.Location = new System.Drawing.Point(50, 21);
            this.cbYears.Name = "cbYears";
            this.cbYears.Size = new System.Drawing.Size(274, 26);
            this.cbYears.TabIndex = 53;
            // 
            // btnOpenViewContingency
            // 
            this.btnOpenViewContingency.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenViewContingency.Font = new System.Drawing.Font("FontAwesome", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenViewContingency.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenViewContingency.Location = new System.Drawing.Point(341, 21);
            this.btnOpenViewContingency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenViewContingency.Name = "btnOpenViewContingency";
            this.btnOpenViewContingency.Size = new System.Drawing.Size(123, 26);
            this.btnOpenViewContingency.TabIndex = 56;
            this.btnOpenViewContingency.Text = "Visualizar";
            this.btnOpenViewContingency.UseVisualStyleBackColor = false;
            this.btnOpenViewContingency.Click += new System.EventHandler(this.btnOpenViewContingency_Click);
            // 
            // FrmDoContingency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1317, 645);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbYears;
        private System.Windows.Forms.FlowLayoutPanel panelGrid;
        private System.Windows.Forms.Button btnOpenViewContingency;
    }
}