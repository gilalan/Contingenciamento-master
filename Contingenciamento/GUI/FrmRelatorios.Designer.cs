namespace Contingenciamento
{
    partial class FrmRelatorios
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
            this.btnUnidade = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnRelClient = new System.Windows.Forms.Button();
            this.bntRelFuncionario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnidade
            // 
            this.btnUnidade.BackColor = System.Drawing.Color.Transparent;
            this.btnUnidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnidade.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnidade.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUnidade.Image = global::Contingenciamento.Properties.Resources.verba_128;
            this.btnUnidade.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUnidade.Location = new System.Drawing.Point(685, 55);
            this.btnUnidade.Name = "btnUnidade";
            this.btnUnidade.Size = new System.Drawing.Size(185, 185);
            this.btnUnidade.TabIndex = 5;
            this.btnUnidade.Text = "Por Verba";
            this.btnUnidade.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUnidade.UseVisualStyleBackColor = false;
            this.btnUnidade.Click += new System.EventHandler(this.btnUnidade_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.BackColor = System.Drawing.Color.Transparent;
            this.btnContratos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContratos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContratos.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContratos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnContratos.Image = global::Contingenciamento.Properties.Resources.contract_128;
            this.btnContratos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnContratos.Location = new System.Drawing.Point(462, 55);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(185, 185);
            this.btnContratos.TabIndex = 4;
            this.btnContratos.Text = "Por Contrato";
            this.btnContratos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContratos.UseVisualStyleBackColor = false;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnRelClient
            // 
            this.btnRelClient.BackColor = System.Drawing.Color.Transparent;
            this.btnRelClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelClient.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRelClient.Image = global::Contingenciamento.Properties.Resources.client_128;
            this.btnRelClient.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRelClient.Location = new System.Drawing.Point(238, 55);
            this.btnRelClient.Name = "btnRelClient";
            this.btnRelClient.Size = new System.Drawing.Size(185, 185);
            this.btnRelClient.TabIndex = 3;
            this.btnRelClient.Text = "Por Cliente";
            this.btnRelClient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRelClient.UseVisualStyleBackColor = false;
            this.btnRelClient.Click += new System.EventHandler(this.btnRelClient_Click);
            // 
            // bntRelFuncionario
            // 
            this.bntRelFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.bntRelFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntRelFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntRelFuncionario.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntRelFuncionario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bntRelFuncionario.Image = global::Contingenciamento.Properties.Resources.employee_128;
            this.bntRelFuncionario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bntRelFuncionario.Location = new System.Drawing.Point(12, 55);
            this.bntRelFuncionario.Name = "bntRelFuncionario";
            this.bntRelFuncionario.Size = new System.Drawing.Size(185, 185);
            this.bntRelFuncionario.TabIndex = 2;
            this.bntRelFuncionario.Text = "Por Funcionário";
            this.bntRelFuncionario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntRelFuncionario.UseVisualStyleBackColor = false;
            this.bntRelFuncionario.Click += new System.EventHandler(this.bntRelFuncionario_Click);
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(882, 303);
            this.Controls.Add(this.btnUnidade);
            this.Controls.Add(this.btnContratos);
            this.Controls.Add(this.btnRelClient);
            this.Controls.Add(this.bntRelFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmRelatorios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntRelFuncionario;
        private System.Windows.Forms.Button btnRelClient;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnUnidade;
    }
}