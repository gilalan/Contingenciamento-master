namespace Contingenciamento
{
    partial class FrmConsultas
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
            this.gbEntidades = new System.Windows.Forms.GroupBox();
            this.btnVerbas = new System.Windows.Forms.Button();
            this.btnUnidades = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnFuncionarios = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.btnContratoAliquotas = new System.Windows.Forms.Button();
            this.gbEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEntidades
            // 
            this.gbEntidades.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbEntidades.Controls.Add(this.btnContratoAliquotas);
            this.gbEntidades.Controls.Add(this.btnVerbas);
            this.gbEntidades.Controls.Add(this.btnUnidades);
            this.gbEntidades.Controls.Add(this.btnContratos);
            this.gbEntidades.Controls.Add(this.btnClientes);
            this.gbEntidades.Controls.Add(this.btnFuncionarios);
            this.gbEntidades.Location = new System.Drawing.Point(12, 12);
            this.gbEntidades.Name = "gbEntidades";
            this.gbEntidades.Size = new System.Drawing.Size(211, 750);
            this.gbEntidades.TabIndex = 0;
            this.gbEntidades.TabStop = false;
            this.gbEntidades.Text = "Classes";
            // 
            // btnVerbas
            // 
            this.btnVerbas.Location = new System.Drawing.Point(6, 439);
            this.btnVerbas.Name = "btnVerbas";
            this.btnVerbas.Size = new System.Drawing.Size(199, 63);
            this.btnVerbas.TabIndex = 4;
            this.btnVerbas.Text = "Verbas";
            this.btnVerbas.UseVisualStyleBackColor = true;
            this.btnVerbas.Click += new System.EventHandler(this.btnVerbas_Click);
            // 
            // btnUnidades
            // 
            this.btnUnidades.Location = new System.Drawing.Point(6, 339);
            this.btnUnidades.Name = "btnUnidades";
            this.btnUnidades.Size = new System.Drawing.Size(199, 63);
            this.btnUnidades.TabIndex = 3;
            this.btnUnidades.Text = "Unidades";
            this.btnUnidades.UseVisualStyleBackColor = true;
            this.btnUnidades.Click += new System.EventHandler(this.btnUnidades_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Location = new System.Drawing.Point(6, 239);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(199, 63);
            this.btnContratos.TabIndex = 2;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(6, 139);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(199, 63);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnFuncionarios
            // 
            this.btnFuncionarios.Location = new System.Drawing.Point(6, 39);
            this.btnFuncionarios.Name = "btnFuncionarios";
            this.btnFuncionarios.Size = new System.Drawing.Size(199, 63);
            this.btnFuncionarios.TabIndex = 0;
            this.btnFuncionarios.Text = "Funcionários";
            this.btnFuncionarios.UseVisualStyleBackColor = true;
            this.btnFuncionarios.Click += new System.EventHandler(this.btnFuncionarios_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(229, 12);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.RowTemplate.Height = 24;
            this.dgvConsultas.Size = new System.Drawing.Size(769, 750);
            this.dgvConsultas.TabIndex = 1;
            // 
            // btnContratoAliquotas
            // 
            this.btnContratoAliquotas.Location = new System.Drawing.Point(6, 539);
            this.btnContratoAliquotas.Name = "btnContratoAliquotas";
            this.btnContratoAliquotas.Size = new System.Drawing.Size(199, 63);
            this.btnContratoAliquotas.TabIndex = 5;
            this.btnContratoAliquotas.Text = "Alíquotas de Contratos";
            this.btnContratoAliquotas.UseVisualStyleBackColor = true;
            this.btnContratoAliquotas.Click += new System.EventHandler(this.btnContratoAliquotas_Click);
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1010, 774);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.gbEntidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmConsultas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.gbEntidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEntidades;
        private System.Windows.Forms.Button btnVerbas;
        private System.Windows.Forms.Button btnUnidades;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnFuncionarios;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Button btnContratoAliquotas;
    }
}