using Contingenciamento.Entidades;
using Contingenciamento.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmExcelExport : Form
    {
        int SelectedYear;
        List<int> Years;
        Dictionary<KeyValuePair<int,int>, List<ContingencyPast>> YearMonthCPsList;
        Contract Contract;

        public FrmExcelExport()
        {
            InitializeComponent();
        }

        public FrmExcelExport(int selectedYear, List<int> years, Dictionary<KeyValuePair<int,int>, List<ContingencyPast>> yearMonthCPsList, Contract contract)
        {
            this.SelectedYear = selectedYear;
            this.Years = years;
            this.YearMonthCPsList = yearMonthCPsList;
            this.Contract = contract;
            InitializeComponent();
        }

        private void FrmExcelExport_Load(object sender, EventArgs e)
        {
            _FillMonthsCB();
            _FillYearsCB();
        }

        private void _FillMonthsCB()
        {
            List<string> namedMonths = new List<string> { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho",
                "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            var source = new BindingSource();
            source.DataSource = namedMonths;
            this.cbMonths.DataSource = source;
            //this.cbMonths.DisplayMember = "Name";
            //this.cbMonths.ValueMember = "Id";
        }

        private void _FillYearsCB()
        {
            var source = new BindingSource();
            source.DataSource = Years;
            this.cbYears.DataSource = source;
            //this.cbYears.DisplayMember = "Name";
            //this.cbYears.ValueMember = "Id";
            this.cbYears.SelectedIndex = SelectedYear;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            int year = (int)this.cbYears.SelectedItem;
            int month = (int)this.cbMonths.SelectedIndex;
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(year, month+1);
            List<ContingencyPast> cpListByMonthYear = this.YearMonthCPsList[kvp];
            IWorkbook workbook = DefaultExporterWorksheet.ExportCtgencyEmployeeList(cpListByMonthYear);
            _SaveExcelFile(workbook);
        }

        private void _SaveExcelFile(IWorkbook wb)
        {
            int year = (int)this.cbYears.SelectedItem;
            string month = this.cbMonths.SelectedItem.ToString();
            //define o titulo
            sfDlg.Title = "Salvar Planilha XLSX";
            //Define as extensões permitidas
            sfDlg.Filter = "Excel Worksheet File|.xlsx";
            //define o indice do filtro
            sfDlg.FilterIndex = 0;
            //Atribui um valor vazio ao nome do arquivo
            sfDlg.FileName = "Contingenciamento_" + this.Contract.Name + "_" + month + "_" + year;
            //Define a extensão padrão como .txt
            sfDlg.DefaultExt = ".xlsx";
            //define o diretório padrão
            sfDlg.InitialDirectory = @"D:\TestContingency";
            //restaura o diretorio atual antes de fechar a janela
            sfDlg.RestoreDirectory = true;

            //Abre a caixa de dialogo e determina qual botão foi pressionado
            DialogResult result = sfDlg.ShowDialog();

            //Se o ousuário pressionar o botão Salvar
            if (result == DialogResult.OK)
            {
                //Cria um stream usando o nome do arquivo
                //FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                FileStream fs = new FileStream(sfDlg.FileName, FileMode.Create, FileAccess.Write);
                //Cria um escrito que irá escrever no stream
                wb.Write(fs);
                //StreamWriter writer = new StreamWriter(fs);
                //escreve o conteúdo da caixa de texto no stream
                //writer.Write(txtTexto.Text);
                //fecha o escrito e o stream
                wb.Close();
                MessageBox.Show("O arquivo foi criado com sucesso.",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
