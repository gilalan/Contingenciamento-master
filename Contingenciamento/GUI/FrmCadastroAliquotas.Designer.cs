namespace Contingenciamento.GUI
{
    partial class FrmCadastroAliquotas
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
            this.gBoxDados = new System.Windows.Forms.GroupBox();
            this.txtAliquota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVerbasFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveAliq = new System.Windows.Forms.Button();
            this.cbContratos = new System.Windows.Forms.ComboBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gBoxDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxDados
            // 
            this.gBoxDados.Controls.Add(this.txtAno);
            this.gBoxDados.Controls.Add(this.label4);
            this.gBoxDados.Controls.Add(this.cbContratos);
            this.gBoxDados.Controls.Add(this.label3);
            this.gBoxDados.Controls.Add(this.cbClientes);
            this.gBoxDados.Controls.Add(this.label2);
            this.gBoxDados.Controls.Add(this.cbVerbasFilter);
            this.gBoxDados.Controls.Add(this.label1);
            this.gBoxDados.Controls.Add(this.txtAliquota);
            this.gBoxDados.Controls.Add(this.label5);
            this.gBoxDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDados.ForeColor = System.Drawing.Color.Indigo;
            this.gBoxDados.Location = new System.Drawing.Point(12, 12);
            this.gBoxDados.Name = "gBoxDados";
            this.gBoxDados.Size = new System.Drawing.Size(487, 380);
            this.gBoxDados.TabIndex = 8;
            this.gBoxDados.TabStop = false;
            this.gBoxDados.Text = "Selecionar Campos";
            // 
            // txtAliquota
            // 
            this.txtAliquota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAliquota.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAliquota.ForeColor = System.Drawing.Color.Maroon;
            this.txtAliquota.Location = new System.Drawing.Point(9, 273);
            this.txtAliquota.Name = "txtAliquota";
            this.txtAliquota.Size = new System.Drawing.Size(472, 27);
            this.txtAliquota.TabIndex = 4;
            this.txtAliquota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAliquota_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(6, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(264, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Digite o valor da Alíquota (em %):";
            // 
            // cbVerbasFilter
            // 
            this.cbVerbasFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerbasFilter.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVerbasFilter.ForeColor = System.Drawing.Color.Black;
            this.cbVerbasFilter.FormattingEnabled = true;
            this.cbVerbasFilter.Location = new System.Drawing.Point(9, 198);
            this.cbVerbasFilter.Name = "cbVerbasFilter";
            this.cbVerbasFilter.Size = new System.Drawing.Size(474, 28);
            this.cbVerbasFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(6, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Selecione a Verba:";
            // 
            // cbClientes
            // 
            this.cbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientes.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClientes.ForeColor = System.Drawing.Color.Black;
            this.cbClientes.FormattingEnabled = true;
            this.cbClientes.Location = new System.Drawing.Point(9, 54);
            this.cbClientes.Name = "cbClientes";
            this.cbClientes.Size = new System.Drawing.Size(472, 28);
            this.cbClientes.TabIndex = 1;
            this.cbClientes.SelectedIndexChanged += new System.EventHandler(this.cbClientes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Selecione o Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Selecione o Contrato (se houver):";
            // 
            // btnSaveAliq
            // 
            this.btnSaveAliq.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveAliq.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveAliq.Location = new System.Drawing.Point(12, 398);
            this.btnSaveAliq.Name = "btnSaveAliq";
            this.btnSaveAliq.Size = new System.Drawing.Size(112, 47);
            this.btnSaveAliq.TabIndex = 6;
            this.btnSaveAliq.Text = "Salvar";
            this.btnSaveAliq.UseVisualStyleBackColor = false;
            this.btnSaveAliq.Click += new System.EventHandler(this.btnSaveAliq_Click);
            // 
            // cbContratos
            // 
            this.cbContratos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContratos.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContratos.ForeColor = System.Drawing.Color.Black;
            this.cbContratos.FormattingEnabled = true;
            this.cbContratos.Location = new System.Drawing.Point(9, 125);
            this.cbContratos.Name = "cbContratos";
            this.cbContratos.Size = new System.Drawing.Size(472, 28);
            this.cbContratos.TabIndex = 2;
            // 
            // txtAno
            // 
            this.txtAno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAno.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.ForeColor = System.Drawing.Color.Maroon;
            this.txtAno.Location = new System.Drawing.Point(9, 342);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(472, 27);
            this.txtAno.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(6, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Digite o Ano de Referência:";
            // 
            // FrmCadastroAliquotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(511, 457);
            this.Controls.Add(this.btnSaveAliq);
            this.Controls.Add(this.gBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCadastroAliquotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Alíquotas para Verbas";
            this.Load += new System.EventHandler(this.FrmCadastroAliquotas_Load);
            this.gBoxDados.ResumeLayout(false);
            this.gBoxDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxDados;
        private System.Windows.Forms.TextBox txtAliquota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVerbasFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveAliq;
        private System.Windows.Forms.ComboBox cbContratos;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label4;
    }
}