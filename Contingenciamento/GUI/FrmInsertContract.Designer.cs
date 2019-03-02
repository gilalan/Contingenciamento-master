namespace Contingenciamento.GUI
{
    partial class FrmInsertContract
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
            this.btnSaveContract = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAliquotValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddAliquot = new System.Windows.Forms.Button();
            this.listContFundsAliquots = new System.Windows.Forms.ListView();
            this.cbContigencyFunds = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTPEnd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTPStart = new System.Windows.Forms.DateTimePicker();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bgWorkerDatabase = new System.ComponentModel.BackgroundWorker();
            this.pbSaveDatabase = new System.Windows.Forms.ProgressBar();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gBoxDados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveContract
            // 
            this.btnSaveContract.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveContract.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveContract.Location = new System.Drawing.Point(12, 556);
            this.btnSaveContract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveContract.Name = "btnSaveContract";
            this.btnSaveContract.Size = new System.Drawing.Size(112, 47);
            this.btnSaveContract.TabIndex = 9;
            this.btnSaveContract.Text = "Salvar";
            this.btnSaveContract.UseVisualStyleBackColor = false;
            this.btnSaveContract.Click += new System.EventHandler(this.btnSaveContract_Click);
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.groupBox2);
            this.gBoxDados.Controls.Add(this.groupBox1);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(12, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Size = new System.Drawing.Size(1170, 541);
            this.gBoxDados.TabIndex = 10;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Novo Contrato";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(405, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "%";
            // 
            // txtAliquotValue
            // 
            this.txtAliquotValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquotValue.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquotValue.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquotValue.Location = new System.Drawing.Point(348, 65);
            this.txtAliquotValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAliquotValue.MaxLength = 5;
            this.txtAliquotValue.Name = "txtAliquotValue";
            this.txtAliquotValue.Size = new System.Drawing.Size(56, 27);
            this.txtAliquotValue.TabIndex = 45;
            this.txtAliquotValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquotValue_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label11.ForeColor = System.Drawing.Color.DarkCyan;
            this.label11.Location = new System.Drawing.Point(324, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 17);
            this.label11.TabIndex = 43;
            this.label11.Text = "Valor da Alíquota";
            // 
            // btnAddAliquot
            // 
            this.btnAddAliquot.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddAliquot.Font = new System.Drawing.Font("Modern No. 20", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAliquot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddAliquot.Location = new System.Drawing.Point(447, 65);
            this.btnAddAliquot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAliquot.Name = "btnAddAliquot";
            this.btnAddAliquot.Size = new System.Drawing.Size(92, 27);
            this.btnAddAliquot.TabIndex = 42;
            this.btnAddAliquot.Text = "Adicionar";
            this.btnAddAliquot.UseVisualStyleBackColor = false;
            this.btnAddAliquot.Click += new System.EventHandler(this.btnAddAliquot_Click);
            // 
            // listContFundsAliquots
            // 
            this.listContFundsAliquots.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContFundsAliquots.FullRowSelect = true;
            this.listContFundsAliquots.GridLines = true;
            this.listContFundsAliquots.Location = new System.Drawing.Point(9, 132);
            this.listContFundsAliquots.MultiSelect = false;
            this.listContFundsAliquots.Name = "listContFundsAliquots";
            this.listContFundsAliquots.Size = new System.Drawing.Size(564, 148);
            this.listContFundsAliquots.TabIndex = 40;
            this.listContFundsAliquots.UseCompatibleStateImageBehavior = false;
            this.listContFundsAliquots.View = System.Windows.Forms.View.Details;
            // 
            // cbContigencyFunds
            // 
            this.cbContigencyFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContigencyFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContigencyFunds.FormattingEnabled = true;
            this.cbContigencyFunds.Location = new System.Drawing.Point(9, 65);
            this.cbContigencyFunds.Margin = new System.Windows.Forms.Padding(4);
            this.cbContigencyFunds.Name = "cbContigencyFunds";
            this.cbContigencyFunds.Size = new System.Drawing.Size(311, 28);
            this.cbContigencyFunds.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(7, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(308, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Lista de Verbas e Alíquotas a serem adicionadas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Nome da Verba";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(9, 344);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(563, 157);
            this.treeView1.TabIndex = 30;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(6, 297);
            this.label8.MaximumSize = new System.Drawing.Size(575, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(517, 40);
            this.label8.TabIndex = 29;
            this.label8.Text = "Informe quais verbas monetárias serão utilizadas para o cálculo do contingenciame" +
    "nto:";
            // 
            // dateTPEnd
            // 
            this.dateTPEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPEnd.Location = new System.Drawing.Point(217, 267);
            this.dateTPEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPEnd.Name = "dateTPEnd";
            this.dateTPEnd.Size = new System.Drawing.Size(159, 28);
            this.dateTPEnd.TabIndex = 26;
            this.dateTPEnd.ValueChanged += new System.EventHandler(this.dateTPEnd_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(220, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(6, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Início";
            // 
            // dateTPStart
            // 
            this.dateTPStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPStart.Location = new System.Drawing.Point(10, 267);
            this.dateTPStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(159, 28);
            this.dateTPStart.TabIndex = 23;
            this.dateTPStart.ValueChanged += new System.EventHandler(this.dateTPStart_ValueChanged);
            // 
            // txtContractName
            // 
            this.txtContractName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractName.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.ForeColor = System.Drawing.Color.Maroon;
            this.txtContractName.Location = new System.Drawing.Point(10, 53);
            this.txtContractName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(544, 27);
            this.txtContractName.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(6, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Informe o período de vigência do Contrato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para o Contrato:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.MaximumSize = new System.Drawing.Size(575, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(567, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Informe quais verbas de contingenciamento são relacionadas ao Contrato:";
            // 
            // bgWorkerDatabase
            // 
            this.bgWorkerDatabase.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDatabase_DoWork);
            this.bgWorkerDatabase.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDatabase_RunWorkerCompleted);
            // 
            // pbSaveDatabase
            // 
            this.pbSaveDatabase.Location = new System.Drawing.Point(130, 570);
            this.pbSaveDatabase.Name = "pbSaveDatabase";
            this.pbSaveDatabase.Size = new System.Drawing.Size(448, 23);
            this.pbSaveDatabase.TabIndex = 11;
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.lblWaiting.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblWaiting.Location = new System.Drawing.Point(584, 570);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(0, 17);
            this.lblWaiting.TabIndex = 48;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtContractName);
            this.groupBox1.Controls.Add(this.dateTPStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTPEnd);
            this.groupBox1.Location = new System.Drawing.Point(6, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 305);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações Básicas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(6, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Informe o objetivo/descrição do Contrato:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(544, 86);
            this.txtDescription.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbContigencyFunds);
            this.groupBox2.Controls.Add(this.txtAliquotValue);
            this.groupBox2.Controls.Add(this.listContFundsAliquots);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnAddAliquot);
            this.groupBox2.Location = new System.Drawing.Point(572, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 511);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verbas e Alíquotas";
            // 
            // FrmInsertContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1196, 613);
            this.Controls.Add(this.lblWaiting);
            this.Controls.Add(this.pbSaveDatabase);
            this.Controls.Add(this.btnSaveContract);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmInsertContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Contrato";
            this.Load += new System.EventHandler(this.FrmInsertContract_Load);
            this.gBoxDados.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveContract;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTPEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTPStart;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbContigencyFunds;
        private System.Windows.Forms.ListView listContFundsAliquots;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddAliquot;
        private System.Windows.Forms.TextBox txtAliquotValue;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker bgWorkerDatabase;
        private System.Windows.Forms.ProgressBar pbSaveDatabase;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}