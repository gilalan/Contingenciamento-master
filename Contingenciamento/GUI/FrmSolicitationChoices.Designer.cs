namespace Contingenciamento.GUI
{
    partial class FrmSolicitationChoices
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
            this.btnVacation = new System.Windows.Forms.Button();
            this.btn13Salary = new System.Windows.Forms.Button();
            this.btnPenalty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVacation
            // 
            this.btnVacation.BackColor = System.Drawing.Color.Transparent;
            this.btnVacation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVacation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVacation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVacation.ForeColor = System.Drawing.Color.Black;
            this.btnVacation.Image = global::Contingenciamento.Properties.Resources.vacation_128;
            this.btnVacation.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVacation.Location = new System.Drawing.Point(35, 39);
            this.btnVacation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVacation.Name = "btnVacation";
            this.btnVacation.Size = new System.Drawing.Size(185, 185);
            this.btnVacation.TabIndex = 13;
            this.btnVacation.Text = "Solicitação de Férias";
            this.btnVacation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVacation.UseVisualStyleBackColor = false;
            // 
            // btn13Salary
            // 
            this.btn13Salary.BackColor = System.Drawing.Color.Transparent;
            this.btn13Salary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn13Salary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn13Salary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn13Salary.ForeColor = System.Drawing.Color.Black;
            this.btn13Salary.Image = global::Contingenciamento.Properties.Resources.money_128;
            this.btn13Salary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn13Salary.Location = new System.Drawing.Point(259, 39);
            this.btn13Salary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn13Salary.Name = "btn13Salary";
            this.btn13Salary.Size = new System.Drawing.Size(185, 185);
            this.btn13Salary.TabIndex = 11;
            this.btn13Salary.Text = "Solicitação de 13º Salário";
            this.btn13Salary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn13Salary.UseVisualStyleBackColor = false;
            this.btn13Salary.Click += new System.EventHandler(this.btn13Salary_Click);
            // 
            // btnPenalty
            // 
            this.btnPenalty.BackColor = System.Drawing.Color.Transparent;
            this.btnPenalty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPenalty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPenalty.ForeColor = System.Drawing.Color.Black;
            this.btnPenalty.Image = global::Contingenciamento.Properties.Resources.demission_128;
            this.btnPenalty.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPenalty.Location = new System.Drawing.Point(481, 39);
            this.btnPenalty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPenalty.Name = "btnPenalty";
            this.btnPenalty.Size = new System.Drawing.Size(185, 185);
            this.btnPenalty.TabIndex = 12;
            this.btnPenalty.Text = "Solicitação de Rescisão";
            this.btnPenalty.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPenalty.UseVisualStyleBackColor = false;
            // 
            // FrmSolicitationChoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(703, 268);
            this.Controls.Add(this.btnVacation);
            this.Controls.Add(this.btn13Salary);
            this.Controls.Add(this.btnPenalty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSolicitationChoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitação de Verba";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVacation;
        private System.Windows.Forms.Button btn13Salary;
        private System.Windows.Forms.Button btnPenalty;
    }
}