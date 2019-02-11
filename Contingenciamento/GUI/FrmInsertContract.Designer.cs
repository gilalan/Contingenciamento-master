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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode121 = new System.Windows.Forms.TreeNode("Total de Proventos");
            System.Windows.Forms.TreeNode treeNode122 = new System.Windows.Forms.TreeNode("Salário Líquido");
            System.Windows.Forms.TreeNode treeNode123 = new System.Windows.Forms.TreeNode("Adicional de Insalubridade");
            System.Windows.Forms.TreeNode treeNode124 = new System.Windows.Forms.TreeNode("Adicional de Periculosidade");
            System.Windows.Forms.TreeNode treeNode125 = new System.Windows.Forms.TreeNode("Horas Extras");
            System.Windows.Forms.TreeNode treeNode126 = new System.Windows.Forms.TreeNode("Salário Base", new System.Windows.Forms.TreeNode[] {
            treeNode123,
            treeNode124,
            treeNode125});
            this.btnSaveAliq = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.panelAliquots = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDepts = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label8 = new System.Windows.Forms.Label();
            this.cbContigencyFunds = new System.Windows.Forms.CheckedListBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTPStart = new System.Windows.Forms.DateTimePicker();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveAliq
            // 
            this.btnSaveAliq.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAliq.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveAliq.Location = new System.Drawing.Point(11, 626);
            this.btnSaveAliq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveAliq.Name = "btnSaveAliq";
            this.btnSaveAliq.Size = new System.Drawing.Size(84, 38);
            this.btnSaveAliq.TabIndex = 9;
            this.btnSaveAliq.Text = "Salvar";
            this.btnSaveAliq.UseVisualStyleBackColor = false;
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.label12);
            this.gBoxDados.Controls.Add(this.panelAliquots);
            this.gBoxDados.Controls.Add(this.btnAddDepts);
            this.gBoxDados.Controls.Add(this.label11);
            this.gBoxDados.Controls.Add(this.maskedTextBox2);
            this.gBoxDados.Controls.Add(this.maskedTextBox1);
            this.gBoxDados.Controls.Add(this.label10);
            this.gBoxDados.Controls.Add(this.label9);
            this.gBoxDados.Controls.Add(this.treeView1);
            this.gBoxDados.Controls.Add(this.label8);
            this.gBoxDados.Controls.Add(this.cbContigencyFunds);
            this.gBoxDados.Controls.Add(this.dateTimePicker1);
            this.gBoxDados.Controls.Add(this.label7);
            this.gBoxDados.Controls.Add(this.label6);
            this.gBoxDados.Controls.Add(this.dateTPStart);
            this.gBoxDados.Controls.Add(this.txtContractName);
            this.gBoxDados.Controls.Add(this.txtAno);
            this.gBoxDados.Controls.Add(this.label4);
            this.gBoxDados.Controls.Add(this.label3);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Controls.Add(this.label1);
            this.gBoxDados.Controls.Add(this.label5);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(11, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxDados.Size = new System.Drawing.Size(554, 611);
            this.gBoxDados.TabIndex = 10;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Novo Contrato";
            // 
            // panelAliquots
            // 
            this.panelAliquots.AutoScroll = true;
            this.panelAliquots.BackColor = System.Drawing.SystemColors.Info;
            this.panelAliquots.ColumnCount = 1;
            this.panelAliquots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelAliquots.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.panelAliquots.Location = new System.Drawing.Point(225, 237);
            this.panelAliquots.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelAliquots.Name = "panelAliquots";
            this.panelAliquots.RowCount = 1;
            this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelAliquots.Size = new System.Drawing.Size(204, 109);
            this.panelAliquots.TabIndex = 37;
            // 
            // btnAddDepts
            // 
            this.btnAddDepts.AutoSize = true;
            this.btnAddDepts.Location = new System.Drawing.Point(253, 178);
            this.btnAddDepts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnAddDepts.Name = "btnAddDepts";
            this.btnAddDepts.Size = new System.Drawing.Size(175, 17);
            this.btnAddDepts.TabIndex = 36;
            this.btnAddDepts.TabStop = true;
            this.btnAddDepts.Text = "Cadastrar códigos avulsos";
            this.btnAddDepts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddDepts_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 177);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "até";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(128, 175);
            this.maskedTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maskedTextBox2.Mask = "000,999,999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(88, 23);
            this.maskedTextBox2.TabIndex = 34;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(8, 175);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maskedTextBox1.Mask = "000,999,999";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(88, 23);
            this.maskedTextBox1.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(223, 220);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 14);
            this.label10.TabIndex = 33;
            this.label10.Text = "Alíquotas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(4, 220);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 14);
            this.label9.TabIndex = 32;
            this.label9.Text = "Nome da Verba";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(7, 382);
            this.treeView1.Name = "treeView1";
            treeNode121.Name = "nodeTotal";
            treeNode121.Text = "Total de Proventos";
            treeNode122.Name = "nodeSalarioLiquido";
            treeNode122.Text = "Salário Líquido";
            treeNode123.Name = "nodeAdicionalInsalubridade";
            treeNode123.Text = "Adicional de Insalubridade";
            treeNode124.Name = "nodePericulosidade";
            treeNode124.Text = "Adicional de Periculosidade";
            treeNode125.Name = "nodeHoraExtra";
            treeNode125.Text = "Horas Extras";
            treeNode126.Name = "nodeSalarioBase";
            treeNode126.Text = "Salário Base";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode121,
            treeNode122,
            treeNode126});
            this.treeView1.Size = new System.Drawing.Size(542, 128);
            this.treeView1.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(4, 362);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(549, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "Informe quais verbas monetárias serão utilizadas para o cálculo do contingenciame" +
    "nto:";
            // 
            // cbContigencyFunds
            // 
            this.cbContigencyFunds.CheckOnClick = true;
            this.cbContigencyFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContigencyFunds.FormattingEnabled = true;
            this.cbContigencyFunds.Location = new System.Drawing.Point(7, 237);
            this.cbContigencyFunds.Name = "cbContigencyFunds";
            this.cbContigencyFunds.Size = new System.Drawing.Size(211, 109);
            this.cbContigencyFunds.TabIndex = 28;
            this.cbContigencyFunds.SelectedIndexChanged += new System.EventHandler(this.cbContigencyFunds_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 116);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(164, 100);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(4, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 24;
            this.label6.Text = "Início";
            // 
            // dateTPStart
            // 
            this.dateTPStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPStart.Location = new System.Drawing.Point(7, 116);
            this.dateTPStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(120, 24);
            this.dateTPStart.TabIndex = 23;
            // 
            // txtContractName
            // 
            this.txtContractName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractName.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.ForeColor = System.Drawing.Color.Maroon;
            this.txtContractName.Location = new System.Drawing.Point(7, 47);
            this.txtContractName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(275, 23);
            this.txtContractName.TabIndex = 22;
            // 
            // txtAno
            // 
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.ForeColor = System.Drawing.Color.Maroon;
            this.txtAno.Location = new System.Drawing.Point(7, 542);
            this.txtAno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(354, 20);
            this.txtAno.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(4, 524);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Deseja cadastrar alíquotas anteriores para o Contrato atual?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(4, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Informe o período de vigência do Contrato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para o Contrato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(4, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Informe o intervalo de Departamentos (códigos) englobados:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(4, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(469, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Informe quais verbas de contingenciamento são relacionadas ao Contrato:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 178);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "OU";
            // 
            // FrmInsertContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(576, 675);
            this.Controls.Add(this.btnSaveAliq);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInsertContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Contrato";
            this.Load += new System.EventHandler(this.FrmInsertContract_Load);
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAliq;
        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.TextBox txtContractName;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTPStart;
        private System.Windows.Forms.CheckedListBox cbContigencyFunds;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.LinkLabel btnAddDepts;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel panelAliquots;
        private System.Windows.Forms.Label label12;
    }
}