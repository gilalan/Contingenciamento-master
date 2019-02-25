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
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Total de Proventos");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Salário Líquido");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Adicional de Insalubridade");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Adicional de Periculosidade");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Horas Extras");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Salário Base", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23});
            this.btnSaveAliq = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.listDepts = new System.Windows.Forms.ListView();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.panelAliquots = new System.Windows.Forms.TableLayoutPanel();
            this.txtDptCode = new System.Windows.Forms.MaskedTextBox();
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
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveAliq
            // 
            this.btnSaveAliq.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAliq.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveAliq.Location = new System.Drawing.Point(15, 509);
            this.btnSaveAliq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveAliq.Name = "btnSaveAliq";
            this.btnSaveAliq.Size = new System.Drawing.Size(112, 47);
            this.btnSaveAliq.TabIndex = 9;
            this.btnSaveAliq.Text = "Salvar";
            this.btnSaveAliq.UseVisualStyleBackColor = false;
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.listDepts);
            this.gBoxDados.Controls.Add(this.btnAddDept);
            this.gBoxDados.Controls.Add(this.panelAliquots);
            this.gBoxDados.Controls.Add(this.txtDptCode);
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
            this.gBoxDados.Location = new System.Drawing.Point(12, 11);
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gBoxDados.Size = new System.Drawing.Size(1227, 481);
            this.gBoxDados.TabIndex = 10;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Novo Contrato";
            // 
            // listDepts
            // 
            this.listDepts.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listDepts.FullRowSelect = true;
            this.listDepts.GridLines = true;
            this.listDepts.Location = new System.Drawing.Point(11, 247);
            this.listDepts.Name = "listDepts";
            this.listDepts.Size = new System.Drawing.Size(561, 225);
            this.listDepts.TabIndex = 38;
            this.listDepts.UseCompatibleStateImageBehavior = false;
            this.listDepts.View = System.Windows.Forms.View.Details;
            // 
            // btnAddDept
            // 
            this.btnAddDept.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddDept.Font = new System.Drawing.Font("Modern No. 20", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDept.Location = new System.Drawing.Point(133, 215);
            this.btnAddDept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(92, 27);
            this.btnAddDept.TabIndex = 11;
            this.btnAddDept.Text = "Adicionar";
            this.btnAddDept.UseVisualStyleBackColor = false;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // panelAliquots
            // 
            this.panelAliquots.AutoScroll = true;
            this.panelAliquots.BackColor = System.Drawing.SystemColors.Info;
            this.panelAliquots.ColumnCount = 1;
            this.panelAliquots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelAliquots.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.panelAliquots.Location = new System.Drawing.Point(937, 76);
            this.panelAliquots.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAliquots.Name = "panelAliquots";
            this.panelAliquots.RowCount = 1;
            this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelAliquots.Size = new System.Drawing.Size(284, 134);
            this.panelAliquots.TabIndex = 37;
            // 
            // txtDptCode
            // 
            this.txtDptCode.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDptCode.Location = new System.Drawing.Point(11, 215);
            this.txtDptCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDptCode.Mask = "000,999,999";
            this.txtDptCode.Name = "txtDptCode";
            this.txtDptCode.Size = new System.Drawing.Size(116, 27);
            this.txtDptCode.TabIndex = 34;
            this.txtDptCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(934, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Alíquotas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(642, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Nome da Verba";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(646, 266);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode19.Name = "nodeTotal";
            treeNode19.Text = "Total de Proventos";
            treeNode20.Name = "nodeSalarioLiquido";
            treeNode20.Text = "Salário Líquido";
            treeNode21.Name = "nodeAdicionalInsalubridade";
            treeNode21.Text = "Adicional de Insalubridade";
            treeNode22.Name = "nodePericulosidade";
            treeNode22.Text = "Adicional de Periculosidade";
            treeNode23.Name = "nodeHoraExtra";
            treeNode23.Text = "Horas Extras";
            treeNode24.Name = "nodeSalarioBase";
            treeNode24.Text = "Salário Base";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(575, 157);
            this.treeView1.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(642, 222);
            this.label8.MaximumSize = new System.Drawing.Size(575, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(517, 40);
            this.label8.TabIndex = 29;
            this.label8.Text = "Informe quais verbas monetárias serão utilizadas para o cálculo do contingenciame" +
    "nto:";
            // 
            // cbContigencyFunds
            // 
            this.cbContigencyFunds.CheckOnClick = true;
            this.cbContigencyFunds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContigencyFunds.FormattingEnabled = true;
            this.cbContigencyFunds.Location = new System.Drawing.Point(646, 76);
            this.cbContigencyFunds.Margin = new System.Windows.Forms.Padding(4);
            this.cbContigencyFunds.Name = "cbContigencyFunds";
            this.cbContigencyFunds.Size = new System.Drawing.Size(280, 129);
            this.cbContigencyFunds.TabIndex = 28;
            this.cbContigencyFunds.SelectedIndexChanged += new System.EventHandler(this.cbContigencyFunds_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(216, 143);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 28);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 8.2F);
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(219, 123);
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
            this.label6.Location = new System.Drawing.Point(5, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Início";
            // 
            // dateTPStart
            // 
            this.dateTPStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPStart.Location = new System.Drawing.Point(9, 143);
            this.dateTPStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(159, 28);
            this.dateTPStart.TabIndex = 23;
            // 
            // txtContractName
            // 
            this.txtContractName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractName.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.ForeColor = System.Drawing.Color.Maroon;
            this.txtContractName.Location = new System.Drawing.Point(9, 58);
            this.txtContractName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(366, 27);
            this.txtContractName.TabIndex = 22;
            // 
            // txtAno
            // 
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.ForeColor = System.Drawing.Color.Maroon;
            this.txtAno.Location = new System.Drawing.Point(646, 449);
            this.txtAno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(471, 23);
            this.txtAno.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(642, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Deseja cadastrar alíquotas anteriores para o Contrato atual?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(5, 105);
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
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informe o nome para o Contrato:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(5, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Informe os códigos de Departamentos englobados no Contrato atual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(642, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(567, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Informe quais verbas de contingenciamento são relacionadas ao Contrato:";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmInsertContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1252, 566);
            this.Controls.Add(this.btnSaveAliq);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.MaskedTextBox txtDptCode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel panelAliquots;
        private System.Windows.Forms.ListView listDepts;
        private System.Windows.Forms.Button btnAddDept;
    }
}