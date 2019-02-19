﻿namespace Contingenciamento
{
    partial class FrmCadastros
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPlanilha = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbRoles = new System.Windows.Forms.RadioButton();
            this.rbEmployeeHistory = new System.Windows.Forms.RadioButton();
            this.rbEmployeeInfo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.pbSave = new System.Windows.Forms.ProgressBar();
            this.bgWorkerDatabase = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Importar Planilha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(425, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(982, 323);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtPlanilha
            // 
            this.txtPlanilha.Location = new System.Drawing.Point(190, 59);
            this.txtPlanilha.Name = "txtPlanilha";
            this.txtPlanilha.Size = new System.Drawing.Size(804, 22);
            this.txtPlanilha.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "ofd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selecione Planilha:";
            // 
            // cboSheet
            // 
            this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(190, 92);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(804, 24);
            this.cboSheet.TabIndex = 7;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Clique para salvar o processamento na base de dados.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Qual é o tipo de planilha?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbRoles);
            this.panel1.Controls.Add(this.rbEmployeeHistory);
            this.panel1.Controls.Add(this.rbEmployeeInfo);
            this.panel1.Location = new System.Drawing.Point(190, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 37);
            this.panel1.TabIndex = 10;
            // 
            // rbRoles
            // 
            this.rbRoles.AutoSize = true;
            this.rbRoles.Checked = true;
            this.rbRoles.Location = new System.Drawing.Point(3, 8);
            this.rbRoles.Name = "rbRoles";
            this.rbRoles.Size = new System.Drawing.Size(74, 21);
            this.rbRoles.TabIndex = 0;
            this.rbRoles.TabStop = true;
            this.rbRoles.Text = "Cargos";
            this.rbRoles.UseVisualStyleBackColor = true;
            // 
            // rbEmployeeHistory
            // 
            this.rbEmployeeHistory.AutoSize = true;
            this.rbEmployeeHistory.Location = new System.Drawing.Point(354, 8);
            this.rbEmployeeHistory.Name = "rbEmployeeHistory";
            this.rbEmployeeHistory.Size = new System.Drawing.Size(182, 21);
            this.rbEmployeeHistory.TabIndex = 2;
            this.rbEmployeeHistory.TabStop = true;
            this.rbEmployeeHistory.Text = "Histórico do Funcionário";
            this.rbEmployeeHistory.UseVisualStyleBackColor = true;
            // 
            // rbEmployeeInfo
            // 
            this.rbEmployeeInfo.AutoSize = true;
            this.rbEmployeeInfo.Location = new System.Drawing.Point(83, 8);
            this.rbEmployeeInfo.Name = "rbEmployeeInfo";
            this.rbEmployeeInfo.Size = new System.Drawing.Size(265, 21);
            this.rbEmployeeInfo.TabIndex = 1;
            this.rbEmployeeInfo.Text = "Informações Pessoais do Funcionário";
            this.rbEmployeeInfo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Clique para processar e categorizar os dados";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.Goldenrod;
            this.btnProcess.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcess.Location = new System.Drawing.Point(425, 460);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(86, 40);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Processar";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(528, 468);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(466, 23);
            this.pbProcess.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 566);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Saída:";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutput.Location = new System.Drawing.Point(15, 586);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(979, 125);
            this.txtOutput.TabIndex = 13;
            // 
            // pbSave
            // 
            this.pbSave.Location = new System.Drawing.Point(528, 525);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(465, 23);
            this.pbSave.TabIndex = 14;
            // 
            // bgWorkerDatabase
            // 
            this.bgWorkerDatabase.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDatabase_DoWork);
            this.bgWorkerDatabase.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDatabase_RunWorkerCompleted);
            // 
            // FrmCadastros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlanilha);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmCadastros";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Entidades";
            this.Load += new System.EventHandler(this.FrmCadastros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;      
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPlanilha;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbEmployeeHistory;
        private System.Windows.Forms.RadioButton rbEmployeeInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.RadioButton rbRoles;
        private System.Windows.Forms.ProgressBar pbSave;
        private System.ComponentModel.BackgroundWorker bgWorkerDatabase;
    }
}