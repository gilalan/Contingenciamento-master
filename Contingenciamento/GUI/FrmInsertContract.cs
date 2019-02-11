using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertContract : Form
    {
        Facade _facade = new Facade();
        List<ContingencyFund> contingencyFunds;
        List<TextBox> contingencyFundsAliquots = new List<TextBox>();

        public FrmInsertContract()
        {
            InitializeComponent();
        }

        private void btnAddDepts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FrmInsertContract_Load(object sender, EventArgs e)
        {
            //Preenchendo as verbas e populando as checkBoxes
            contingencyFunds = _facade.GetTopContigencyFund();
            FillCbBox(contingencyFunds);

            //Parte do Panel que receberá as alíquotas
            contingencyFundsAliquots = new List<TextBox>(contingencyFunds.Count);
            this.panelAliquots.RowCount = contingencyFunds.Count;
            formatTxtBoxAliquot();
        }

        private void FillCbBox(List<ContingencyFund> contingencyFunds)
        {
            var source = new BindingSource();
            source.DataSource = contingencyFunds;
            cbContigencyFunds.DataSource = source;
            cbContigencyFunds.DisplayMember = "Name";
            cbContigencyFunds.ValueMember = "Id";
        }

        private void formatTxtBoxAliquot()
        {
            TextBox t1;

            for (int i = 0; i < contingencyFunds.Count; i++)
            {
                t1 = new TextBox();
                t1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                t1.Font = new System.Drawing.Font("Microsoft Himalaya", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                t1.ForeColor = System.Drawing.Color.Maroon;
                t1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
                t1.Size = new System.Drawing.Size(100, 20);
                t1.Text = i.ToString();
                t1.Enabled = false;
                if (i>0)
                    this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                //this.panelAliquots.RowStyles.Add(new System.Windows.Forms.RowStyle());
                //this.panelAliquots.Controls.Add(t1, 0, contingencyFunds.Count-1-i);
                this.panelAliquots.Controls.Add(t1, 0, i);
                contingencyFundsAliquots.Add(t1);
            }
            
        }

        private void cbContigencyFunds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contingencyFundsAliquots.Count > 0)
            {

                int selIndex = this.cbContigencyFunds.SelectedIndex;
                if (cbContigencyFunds.GetItemChecked(selIndex))
                {
                    this.contingencyFundsAliquots[selIndex].Enabled = true;
                }
                else
                {
                    this.contingencyFundsAliquots[selIndex].Enabled = false;
                }
            }
        }
    }
}
