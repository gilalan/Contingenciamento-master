namespace Contingenciamento.GUI
{
    partial class FrmContingencyChoices
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnProcessCont = new System.Windows.Forms.Button();
            this.btnViewCont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemove.Image = global::Contingenciamento.Properties.Resources.x_button;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemove.Location = new System.Drawing.Point(486, 41);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(185, 185);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remover Contingenciamento";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnProcessCont
            // 
            this.btnProcessCont.BackColor = System.Drawing.Color.Transparent;
            this.btnProcessCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessCont.ForeColor = System.Drawing.Color.Black;
            this.btnProcessCont.Image = global::Contingenciamento.Properties.Resources.verba_128;
            this.btnProcessCont.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcessCont.Location = new System.Drawing.Point(37, 41);
            this.btnProcessCont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcessCont.Name = "btnProcessCont";
            this.btnProcessCont.Size = new System.Drawing.Size(185, 185);
            this.btnProcessCont.TabIndex = 12;
            this.btnProcessCont.Text = "Processar Contingenciamento";
            this.btnProcessCont.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcessCont.UseVisualStyleBackColor = false;
            this.btnProcessCont.Click += new System.EventHandler(this.btnProcessCont_Click);
            // 
            // btnViewCont
            // 
            this.btnViewCont.BackColor = System.Drawing.Color.Transparent;
            this.btnViewCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCont.ForeColor = System.Drawing.Color.Black;
            this.btnViewCont.Image = global::Contingenciamento.Properties.Resources.business_128;
            this.btnViewCont.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewCont.Location = new System.Drawing.Point(261, 41);
            this.btnViewCont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewCont.Name = "btnViewCont";
            this.btnViewCont.Size = new System.Drawing.Size(185, 185);
            this.btnViewCont.TabIndex = 11;
            this.btnViewCont.Text = "Visualizar Contingenciamento";
            this.btnViewCont.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnViewCont.UseVisualStyleBackColor = false;
            this.btnViewCont.Click += new System.EventHandler(this.btnViewCont_Click);
            // 
            // FrmContingencyChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(704, 271);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnProcessCont);
            this.Controls.Add(this.btnViewCont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmContingencyChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ações de Contingenciar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcessCont;
        private System.Windows.Forms.Button btnViewCont;
        private System.Windows.Forms.Button btnRemove;
    }
}