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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Total de Proventos");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Salário Líquido");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Adicional de Insalubridade");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Adicional de Periculosidade");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Horas Extras");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Salário Base", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            this.btnSaveAliq = new System.Windows.Forms.Button();
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContractName = new System.Windows.Forms.TextBox();
            this.dateTPStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dptCodeFirstLevel = new System.Windows.Forms.NumericUpDown();
            this.deptCodeSndLevel = new System.Windows.Forms.NumericUpDown();
            this.dptCodeTrdLevel = new System.Windows.Forms.NumericUpDown();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAliquota13 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAliquotaFerias = new System.Windows.Forms.TextBox();
            this.txtAliquotaRescisao = new System.Windows.Forms.TextBox();
            this.txtAliquotaIncidencia = new System.Windows.Forms.TextBox();
            this.txtAliquotaLucro = new System.Windows.Forms.TextBox();
            this.gBoxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dptCodeFirstLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeSndLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptCodeTrdLevel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveAliq
            // 
            this.btnSaveAliq.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAliq.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveAliq.Location = new System.Drawing.Point(11, 626);
            this.btnSaveAliq.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveAliq.Name = "btnSaveAliq";
            this.btnSaveAliq.Size = new System.Drawing.Size(84, 38);
            this.btnSaveAliq.TabIndex = 9;
            this.btnSaveAliq.Text = "Salvar";
            this.btnSaveAliq.UseVisualStyleBackColor = false;
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.label10);
            this.gBoxDados.Controls.Add(this.label9);
            this.gBoxDados.Controls.Add(this.panel1);
            this.gBoxDados.Controls.Add(this.treeView1);
            this.gBoxDados.Controls.Add(this.label8);
            this.gBoxDados.Controls.Add(this.checkedListBox1);
            this.gBoxDados.Controls.Add(this.dptCodeTrdLevel);
            this.gBoxDados.Controls.Add(this.deptCodeSndLevel);
            this.gBoxDados.Controls.Add(this.dptCodeFirstLevel);
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
            this.gBoxDados.Margin = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Padding = new System.Windows.Forms.Padding(2);
            this.gBoxDados.Size = new System.Drawing.Size(554, 611);
            this.gBoxDados.TabIndex = 10;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Novo Contrato";
            // 
            // txtAno
            // 
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.ForeColor = System.Drawing.Color.Maroon;
            this.txtAno.Location = new System.Drawing.Point(7, 542);
            this.txtAno.Margin = new System.Windows.Forms.Padding(2);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(354, 23);
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
            this.label3.Location = new System.Drawing.Point(4, 83);
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
            // txtContractName
            // 
            this.txtContractName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContractName.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractName.ForeColor = System.Drawing.Color.Maroon;
            this.txtContractName.Location = new System.Drawing.Point(7, 47);
            this.txtContractName.Margin = new System.Windows.Forms.Padding(2);
            this.txtContractName.Name = "txtContractName";
            this.txtContractName.Size = new System.Drawing.Size(275, 23);
            this.txtContractName.TabIndex = 22;
            // 
            // dateTPStart
            // 
            this.dateTPStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPStart.Location = new System.Drawing.Point(7, 116);
            this.dateTPStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateTPStart.Name = "dateTPStart";
            this.dateTPStart.Size = new System.Drawing.Size(120, 24);
            this.dateTPStart.TabIndex = 23;
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 116);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 24);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // dptCodeFirstLevel
            // 
            this.dptCodeFirstLevel.Location = new System.Drawing.Point(7, 172);
            this.dptCodeFirstLevel.Name = "dptCodeFirstLevel";
            this.dptCodeFirstLevel.Size = new System.Drawing.Size(49, 23);
            this.dptCodeFirstLevel.TabIndex = 27;
            // 
            // deptCodeSndLevel
            // 
            this.deptCodeSndLevel.Location = new System.Drawing.Point(62, 172);
            this.deptCodeSndLevel.Name = "deptCodeSndLevel";
            this.deptCodeSndLevel.Size = new System.Drawing.Size(49, 23);
            this.deptCodeSndLevel.TabIndex = 27;
            // 
            // dptCodeTrdLevel
            // 
            this.dptCodeTrdLevel.Location = new System.Drawing.Point(117, 172);
            this.dptCodeTrdLevel.Name = "dptCodeTrdLevel";
            this.dptCodeTrdLevel.Size = new System.Drawing.Size(49, 23);
            this.dptCodeTrdLevel.TabIndex = 27;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "13º",
            "Férias",
            "Rescisão",
            "Incidência",
            "Lucro"});
            this.checkedListBox1.Location = new System.Drawing.Point(7, 237);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(211, 112);
            this.checkedListBox1.TabIndex = 28;
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
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(7, 382);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "nodeTotal";
            treeNode7.Text = "Total de Proventos";
            treeNode8.Name = "nodeSalarioLiquido";
            treeNode8.Text = "Salário Líquido";
            treeNode9.Name = "nodeAdicionalInsalubridade";
            treeNode9.Text = "Adicional de Insalubridade";
            treeNode10.Name = "nodePericulosidade";
            treeNode10.Text = "Adicional de Periculosidade";
            treeNode11.Name = "nodeHoraExtra";
            treeNode11.Text = "Horas Extras";
            treeNode12.Name = "nodeSalarioBase";
            treeNode12.Text = "Salário Base";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(542, 128);
            this.treeView1.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAliquotaLucro);
            this.panel1.Controls.Add(this.txtAliquotaIncidencia);
            this.panel1.Controls.Add(this.txtAliquotaRescisao);
            this.panel1.Controls.Add(this.txtAliquotaFerias);
            this.panel1.Controls.Add(this.txtAliquota13);
            this.panel1.Location = new System.Drawing.Point(224, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 112);
            this.panel1.TabIndex = 31;
            // 
            // txtAliquota13
            // 
            this.txtAliquota13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquota13.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquota13.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquota13.Location = new System.Drawing.Point(2, 2);
            this.txtAliquota13.Margin = new System.Windows.Forms.Padding(2);
            this.txtAliquota13.Name = "txtAliquota13";
            this.txtAliquota13.Size = new System.Drawing.Size(98, 18);
            this.txtAliquota13.TabIndex = 32;
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
            // txtAliquotaFerias
            // 
            this.txtAliquotaFerias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquotaFerias.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquotaFerias.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquotaFerias.Location = new System.Drawing.Point(2, 24);
            this.txtAliquotaFerias.Margin = new System.Windows.Forms.Padding(2);
            this.txtAliquotaFerias.Name = "txtAliquotaFerias";
            this.txtAliquotaFerias.Size = new System.Drawing.Size(98, 18);
            this.txtAliquotaFerias.TabIndex = 33;
            // 
            // txtAliquotaRescisao
            // 
            this.txtAliquotaRescisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquotaRescisao.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquotaRescisao.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquotaRescisao.Location = new System.Drawing.Point(2, 46);
            this.txtAliquotaRescisao.Margin = new System.Windows.Forms.Padding(2);
            this.txtAliquotaRescisao.Name = "txtAliquotaRescisao";
            this.txtAliquotaRescisao.Size = new System.Drawing.Size(98, 18);
            this.txtAliquotaRescisao.TabIndex = 34;
            // 
            // txtAliquotaIncidencia
            // 
            this.txtAliquotaIncidencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquotaIncidencia.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquotaIncidencia.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquotaIncidencia.Location = new System.Drawing.Point(2, 68);
            this.txtAliquotaIncidencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtAliquotaIncidencia.Name = "txtAliquotaIncidencia";
            this.txtAliquotaIncidencia.Size = new System.Drawing.Size(98, 18);
            this.txtAliquotaIncidencia.TabIndex = 35;
            // 
            // txtAliquotaLucro
            // 
            this.txtAliquotaLucro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquotaLucro.Font = new System.Drawing.Font("Microsoft Himalaya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquotaLucro.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquotaLucro.Location = new System.Drawing.Point(2, 90);
            this.txtAliquotaLucro.Margin = new System.Windows.Forms.Padding(2);
            this.txtAliquotaLucro.Name = "txtAliquotaLucro";
            this.txtAliquotaLucro.Size = new System.Drawing.Size(98, 18);
            this.txtAliquotaLucro.TabIndex = 36;
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
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dptCodeFirstLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deptCodeSndLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptCodeTrdLevel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown dptCodeTrdLevel;
        private System.Windows.Forms.NumericUpDown deptCodeSndLevel;
        private System.Windows.Forms.NumericUpDown dptCodeFirstLevel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTPStart;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAliquotaLucro;
        private System.Windows.Forms.TextBox txtAliquotaIncidencia;
        private System.Windows.Forms.TextBox txtAliquotaRescisao;
        private System.Windows.Forms.TextBox txtAliquotaFerias;
        private System.Windows.Forms.TextBox txtAliquota13;
    }
}