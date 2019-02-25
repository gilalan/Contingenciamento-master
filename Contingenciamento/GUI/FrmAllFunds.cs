using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmAllFunds : Form
    {
        Facade _facade = new Facade();
        List<ContingencyFund> contingencyFunds;
        List<MonetaryFund> monetaryFunds;
        List<ExtraFund> extraFunds;

        public FrmAllFunds()
        {
            InitializeComponent();
        }

        private void FrmAllFunds_Load(object sender, EventArgs e)
        {
            contingencyFunds = _facade.GetTopContigencyFund();
            monetaryFunds = _facade.GetTopMonetaryFund();
            extraFunds = _facade.GetTopExtraFund();
            _FillListViews();
            _FillMonetaryFundsCB(monetaryFunds);
        }

        private void _FillMonetaryFundsCB(List<MonetaryFund> monetaryFunds)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = monetaryFunds;
            this.cbMonetaryFunds.DataSource = source;
            this.cbMonetaryFunds.DisplayMember = "Name";
            this.cbMonetaryFunds.ValueMember = "Id";
        }

        //Esse preenchimento manual das colunas não está legal!
        private void _FillListViews()
        {
            //#Colunas de Verbas de Contingenciamento
            ColumnHeader ch = new ColumnHeader();
            ch.Text = "ID";
            this.listContingencyFunds.Columns.Add(ch);
            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "Nome";
            this.listContingencyFunds.Columns.Add(ch1);
            listContingencyFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listContingencyFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ListViewItem item;
            foreach (ContingencyFund cFund in contingencyFunds)
            {
                item = new ListViewItem();
                item.Text = cFund.Id.ToString();
                item.SubItems.Add(cFund.Name);
                this.listContingencyFunds.Items.Add(item);
            }

            //#Colunas de Verbas Monetárias
            ColumnHeader chMF1 = new ColumnHeader();
            chMF1.Text = "ID";
            this.listMonetaryFunds.Columns.Add(chMF1);
            ColumnHeader chMF2 = new ColumnHeader();
            chMF2.Text = "Nome";
            this.listMonetaryFunds.Columns.Add(chMF2);
            listMonetaryFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listMonetaryFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (MonetaryFund mFund in monetaryFunds)
            {
                item = new ListViewItem();
                item.Text = mFund.Id.ToString();
                item.SubItems.Add(mFund.Name);
                this.listMonetaryFunds.Items.Add(item);
            }

            //#Colunas de Verbas Extras/Adicionais
            ColumnHeader chEF1 = new ColumnHeader();
            chEF1.Text = "ID";
            this.listExtraFunds.Columns.Add(chEF1);
            ColumnHeader chEF2 = new ColumnHeader();
            chEF2.Text = "Nome";
            this.listExtraFunds.Columns.Add(chEF2);
            ColumnHeader chEF3 = new ColumnHeader();
            chEF3.Text = "Verba Pai";
            this.listExtraFunds.Columns.Add(chEF3);
            listExtraFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listExtraFunds.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (ExtraFund eFund in extraFunds)
            {
                item = new ListViewItem();
                item.Text = eFund.Id.ToString();
                item.SubItems.Add(eFund.Name);
                item.SubItems.Add(eFund.MonetaryFund.Name);
                this.listExtraFunds.Items.Add(item);
            }
        }

        private void btnSaveExtraFunds_Click(object sender, EventArgs e)
        {
            MonetaryFund mf = this.cbMonetaryFunds.SelectedItem as MonetaryFund;
            ExtraFund ef = new ExtraFund();

            if (!String.IsNullOrEmpty(txtExtraFunds.Text))
                ef.Name = txtExtraFunds.Text;

            if (mf != null)
                ef.MonetaryFund = mf;

            try
            {
                int retId = _facade.InsertExtraFund(ef);
                if (retId > 0)
                {
                    ef.Id = retId;
                    ListViewItem item;
                    this.extraFunds.Add(ef);
                    item = new ListViewItem();
                    item.Text = ef.Id.ToString();
                    item.SubItems.Add(ef.Name);
                    item.SubItems.Add(ef.MonetaryFund.Name);
                    this.listExtraFunds.Items.Add(item);

                    MessageBox.Show("Verba " + ef.Name + " cadastrada com sucesso como verba adicional de " + mf.Name + ".",
                   "Cadastro de Verbas Adicionais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Verba " + ef.Name + " não retornou um ID de cadastro válido!",
                    "Cadastro de Verbas Adicionais", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Verba de Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveMonetaryFunds_Click(object sender, EventArgs e)
        {
            MonetaryFund mf = new MonetaryFund();
            mf.Primal = true;

            if (!String.IsNullOrEmpty(txtMonetaryFunds.Text))
                mf.Name = txtMonetaryFunds.Text;

            try
            {
                int retId = _facade.InsertMonetaryFund(mf);
                if (retId > 0)
                {
                    mf.Id = retId;
                    ListViewItem item;
                    this.monetaryFunds.Add(mf);
                    item = new ListViewItem();
                    item.Text = mf.Id.ToString();
                    item.SubItems.Add(mf.Name);
                    this.listMonetaryFunds.Items.Add(item);
                    this.cbMonetaryFunds.DataSource = this.monetaryFunds;
                    
                    MessageBox.Show("Verba de Base " + mf.Name + " cadastrada com sucesso.",
                   "Cadastro de Verbas de Base", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Verba de Base " + mf.Name + " não retornou um ID de cadastro válido!",
                    "Cadastro de Verbas de Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Verba de Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveContingencyFunds_Click(object sender, EventArgs e)
        {
            ContingencyFund cf = new ContingencyFund();

            if (!String.IsNullOrEmpty(txtContingencyFunds.Text))
                cf.Name = txtContingencyFunds.Text;

            try
            {
                int retId = _facade.InsertContigencyFund(cf);
                if (retId > 0)
                {
                    cf.Id = retId;
                    ListViewItem item;
                    this.contingencyFunds.Add(cf);
                    item = new ListViewItem();
                    item.Text = cf.Id.ToString();
                    item.SubItems.Add(cf.Name);
                    this.listContingencyFunds.Items.Add(item);
                    MessageBox.Show("Verba de Contingenciamento " + cf.Name + " cadastrada com sucesso.",
                    "Cadastro de Verbas de Contingenciamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Verba de Contingenciamento " + cf.Name + " não retornou um ID de cadastro válido!",
                    "Cadastro de Verbas de Contingenciamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Erro no Cadastro da Verba de Contingenciamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
