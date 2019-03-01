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
            this.lblDeptsCount = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbContracts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContFundsCount = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMonetaryFundType = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmployeesCount = new System.Windows.Forms.LinkLabel();
            this.btnDoConting = new System.Windows.Forms.Button();
            this.gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.btnDoConting);
            this.gbData.Controls.Add(this.lblEmployeesCount);
            this.gbData.Controls.Add(this.label5);
            this.gbData.Controls.Add(this.lblMonetaryFundType);
            this.gbData.Controls.Add(this.label4);
            this.gbData.Controls.Add(this.lblContFundsCount);
            this.gbData.Controls.Add(this.label3);
            this.gbData.Controls.Add(this.lblDeptsCount);
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.cbContracts);
            this.gbData.Controls.Add(this.label1);
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(743, 216);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "Dados de Entrada";
            // 
            // lblDeptsCount
            // 
            this.lblDeptsCount.AutoSize = true;
            this.lblDeptsCount.Location = new System.Drawing.Point(372, 62);
            this.lblDeptsCount.Name = "lblDeptsCount";
            this.lblDeptsCount.Size = new System.Drawing.Size(0, 17);
            this.lblDeptsCount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de Departamentos associados ao Contrato:";
            // 
            // cbContracts
            // 
            this.cbContracts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContracts.FormattingEnabled = true;
            this.cbContracts.Location = new System.Drawing.Point(375, 24);
            this.cbContracts.Name = "cbContracts";
            this.cbContracts.Size = new System.Drawing.Size(361, 24);
            this.cbContracts.TabIndex = 1;
            this.cbContracts.SelectedIndexChanged += new System.EventHandler(this.cbContracts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione um Contrato para contingenciar:";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1238, 390);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saída do Contingenciamento";
            // 
            // lblContFundsCount
            // 
            this.lblContFundsCount.AutoSize = true;
            this.lblContFundsCount.Location = new System.Drawing.Point(372, 100);
            this.lblContFundsCount.Name = "lblContFundsCount";
            this.lblContFundsCount.Size = new System.Drawing.Size(0, 17);
            this.lblContFundsCount.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantidade de Verbas associadas ao Contrato:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contingenciamento calculado através de:";
            // 
            // lblMonetaryFundType
            // 
            this.lblMonetaryFundType.AutoSize = true;
            this.lblMonetaryFundType.Location = new System.Drawing.Point(372, 142);
            this.lblMonetaryFundType.Name = "lblMonetaryFundType";
            this.lblMonetaryFundType.Size = new System.Drawing.Size(128, 17);
            this.lblMonetaryFundType.TabIndex = 7;
            this.lblMonetaryFundType.TabStop = true;
            this.lblMonetaryFundType.Text = "Total de Proventos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Quantidade de Funcionários associados ao Contrato:";
            // 
            // lblEmployeesCount
            // 
            this.lblEmployeesCount.AutoSize = true;
            this.lblEmployeesCount.Location = new System.Drawing.Point(372, 184);
            this.lblEmployeesCount.Name = "lblEmployeesCount";
            this.lblEmployeesCount.Size = new System.Drawing.Size(0, 17);
            this.lblEmployeesCount.TabIndex = 9;
            // 
            // btnDoConting
            // 
            this.btnDoConting.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDoConting.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoConting.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDoConting.Location = new System.Drawing.Point(613, 171);
            this.btnDoConting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDoConting.Name = "btnDoConting";
            this.btnDoConting.Size = new System.Drawing.Size(123, 39);
            this.btnDoConting.TabIndex = 10;
            this.btnDoConting.Text = "Contingenciar";
            this.btnDoConting.UseVisualStyleBackColor = false;
            this.btnDoConting.Click += new System.EventHandler(this.btnDoConting_Click);
            // 
            // FrmDoContingency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1262, 645);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDoContingency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processar Contingenciamento";
            this.Load += new System.EventHandler(this.FrmDoContingency_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbContracts;
        private System.Windows.Forms.LinkLabel lblDeptsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblContFundsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblMonetaryFundType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lblEmployeesCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDoConting;
    }
}