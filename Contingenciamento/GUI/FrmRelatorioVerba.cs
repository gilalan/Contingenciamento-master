using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmRelatorioVerba : Form
    {
        Facade _facade = new Facade();
        List<Verba> verbas;
        List<ContratoAliquota> allContratosAliquotas;        
        ExportVerba exportVerba;

        public FrmRelatorioVerba()
        {
            InitializeComponent();
        }

        private void FrmRelatorioVerba_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            verbas = _facade.GetTopVerba();
            allContratosAliquotas = _facade.GetTopContratoAliquota();
            FillVerbasCB(verbas);                                               
        }

        private void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTPStart.Format = DateTimePickerFormat.Custom;
            dateTPStart.CustomFormat = "MM/yyyy";
            dateTPStart.Value = new DateTime(dateTPStart.Value.Year, 1, 1);
            dateTPEnd.Format = DateTimePickerFormat.Custom;
            dateTPEnd.CustomFormat = "MM/yyyy";
            dateTPEnd.Value = new DateTime(dateTPEnd.Value.Year, dateTPEnd.Value.Month, 1);
        }

        private void FillVerbasCB(List<Verba> verbas)
        {
            var source = new BindingSource();
            verbas.Insert(0, new Verba(-1, -1, "Todas", true));
            source.DataSource = verbas;
            this.cbVerbasFilter.DataSource = source;
            this.cbVerbasFilter.DisplayMember = "Nome";
            this.cbVerbasFilter.ValueMember = "Id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dateTPStart.Value != null && dateTPEnd.Value != null)
            {
                DateTime start = dateTPStart.Value;
                DateTime end = dateTPEnd.Value;
                BuildOutput(start, end);
            }
        }

        private void BuildOutput(DateTime start, DateTime end)
        {
            List<HistoricoFuncionario> histFuncs = _facade.GetHistoricoByDatas(start, end);
            txtResult.Clear();
            exportVerba = new ExportVerba();
            string periodo = "Período: " + start.Month + "/" + start.Year + " até " + end.Month + "/" + end.Year;
            exportVerba.Periodo = periodo;
            Verba selectedVerba = (Verba)this.cbVerbasFilter.SelectedItem;
            exportVerba.Verba = selectedVerba;
            int verbaId = selectedVerba.Id;

            List<ContratoAliquota> filteredContratoAliquotas;

            if (verbaId != -1)
            {
                filteredContratoAliquotas = FilteredContratoAliquotas(verbaId, allContratosAliquotas);
            }
            else
            {
                filteredContratoAliquotas = allContratosAliquotas;
            }

            StringBuilder stb = new StringBuilder();
            stb.AppendLine("Foram encontradas " + histFuncs.Count + " ocorrências");
            //stb.AppendLine("ID: " + contratoID);
            //stb.AppendLine("Nome: " + contratoName);
            stb.AppendLine("Verba selecionada: " + selectedVerba.Nome);
            stb.AppendLine(periodo);

            stb.AppendLine("---------------------------------------------------------------");

            List<RelatorioCliente> relatorioClientes = new List<RelatorioCliente>();
            List<ContratoAliquota> aliquotasList = new List<ContratoAliquota>();
            RelatorioCliente relCliente;

            foreach (var histFunc in histFuncs)
            {
                if(histFunc.Contrato == null)
                    relCliente = new RelatorioCliente(histFunc.Cliente, histFunc.Funcionario, histFunc.Data.Year);
                else
                    relCliente = new RelatorioCliente(histFunc.Contrato, histFunc.Funcionario, histFunc.Data.Year);

                if (!relatorioClientes.Contains(relCliente))
                {
                    aliquotasList = RelatoriosUtil.FilterAliquotas(histFunc, filteredContratoAliquotas);
                    foreach (var aliqObj in aliquotasList)
                    {
                        relCliente.computarValores(histFunc.SalarioBase, aliqObj.Verba, aliqObj.Aliquota);
                    }

                    relatorioClientes.Add(relCliente);
                }
                else
                {
                    int index = relatorioClientes.IndexOf(relCliente);
                    foreach (var aliqObj in aliquotasList)
                    {
                        relatorioClientes[index].computarValores(histFunc.SalarioBase, aliqObj.Verba, aliqObj.Aliquota);
                    }
                }
            }

            foreach (var relC in relatorioClientes)
            {
                stb.AppendLine("********************************************************");
                stb.AppendLine("Cliente: " + relC.Contrato.Cliente.Name);
                stb.AppendLine("Contrato: " + relC.Contrato.Name);
                stb.AppendLine("Funcionário: " + relC.Funcionario.Name);
                stb.AppendLine("Referência: " + relC.Ano);
                
                if (verbaId == -1) //calcular todas
                {
                    string moneyAF = String.Format("{0:C}", relC.AcumuladoFerias);
                    stb.AppendLine("Férias: " + moneyAF);
                    string moneyAD = String.Format("{0:C}", relC.AcumuladoDecimo);
                    stb.AppendLine("Décimo Salário: " + moneyAD);
                    string moneyAM = String.Format("{0:C}", relC.AcumuladoMulta);
                    stb.AppendLine("Multa: " + moneyAM);
                    string moneyAL = String.Format("{0:C}", relC.AcumuladoLucro);
                    stb.AppendLine("Lucro: " + moneyAL);
                    string moneyAES = String.Format("{0:C}", relC.AcumuladoEncSociais);
                    stb.AppendLine("Encargos Sociais: " + moneyAES);
                }
                else
                {
                    if (selectedVerba.Codigo == 1) //Férias
                    {
                        string moneyAF = String.Format("{0:C}", relC.AcumuladoFerias);
                        stb.AppendLine("Férias: " + moneyAF);
                    }
                    else if (selectedVerba.Codigo == 2)
                    {
                        string moneyAD = String.Format("{0:C}", relC.AcumuladoDecimo);
                        stb.AppendLine("Décimo Salário: " + moneyAD);
                    }
                    else if (selectedVerba.Codigo == 3)
                    {
                        string moneyAM = String.Format("{0:C}", relC.AcumuladoMulta);
                        stb.AppendLine("Multa: " + moneyAM);
                    }
                    else if (selectedVerba.Codigo == 4)
                    {
                        string moneyAL = String.Format("{0:C}", relC.AcumuladoLucro);
                        stb.AppendLine("Lucro: " + moneyAL);
                    }
                    else if (selectedVerba.Codigo == 5)
                    {
                        string moneyAES = String.Format("{0:C}", relC.AcumuladoEncSociais);
                        stb.AppendLine("Encargos Sociais: " + moneyAES);
                    }
                }
                stb.AppendLine("********************************************************");
                exportVerba.RelClientes.Add(relC);
            }

            txtResult.Text = stb.ToString();
        }

        private List<ContratoAliquota> FilteredContratoAliquotas(int verbaId, List<ContratoAliquota> contratosAliq)
        {
            List<ContratoAliquota> filteredContratoAliq = new List<ContratoAliquota>();
            foreach (var cAliq in contratosAliq)
            {
                if (verbaId == cAliq.Verba.Id)
                    filteredContratoAliq.Add(cAliq);
            }

            return filteredContratoAliq;
        }
    }
}
