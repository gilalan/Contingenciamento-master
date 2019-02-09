using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using Contingenciamento.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmRelatorioFuncionario : Form
    {

        Facade _facade = new Facade();
        AutoCompleteStringCollection nomesAutoComplete;
        List<Verba> verbas;
        List<ContratoAliquota> allContratosAliquotas;
        string matricula;
        ExportFuncionario exportFuncionario;

        public FrmRelatorioFuncionario()
        {
            InitializeComponent();
            
        }

        private void FrmRelatorioFuncionario_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            nomesAutoComplete = _facade.GetNomesFuncionarios();
            txtNomeFuncionario.AutoCompleteCustomSource = nomesAutoComplete;
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

        private void txtNomeFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                String selItem = this.txtNomeFuncionario.Text;
                Console.Write(selItem);
                txtResult.AppendText("From KeyDown: " + selItem);
                int start = selItem.IndexOf('(');
                int end = selItem.IndexOf(')');
                matricula = selItem.Substring(++start, end - start);
                txtResult.AppendText("Matrícula: " + matricula);
            }
        }        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(matricula))
            {
                DateTime start = dateTPStart.Value;
                DateTime end = dateTPEnd.Value;
                searchFuncionario(matricula, start, end);
            }
        }

        private void searchFuncionario(string funcionarioMatr, DateTime start, DateTime end)
        {
            Funcionario funcionario = _facade.GetFuncionarioByMatricula(funcionarioMatr);
            txtResult.Clear();
            exportFuncionario = new ExportFuncionario();
            exportFuncionario.Funcionario = funcionario;
            string periodo = "Período: " + start.Month + "/" + start.Year + " até " + end.Month + "/" + end.Year;
            exportFuncionario.Periodo = periodo;
            Verba selectedVerba = (Verba)this.cbVerbasFilter.SelectedItem;
            exportFuncionario.Verba = selectedVerba;
            int verbaId = selectedVerba.Id;
            
            List<ContratoAliquota> filteredContratoAliquotas;
            
            //Filtra o tipo de VERBA em filteredContratoAliquotas
            if (verbaId != -1)
            {
                filteredContratoAliquotas = FilteredContratoAliquotas(verbaId, allContratosAliquotas);
            } else
            {
                filteredContratoAliquotas = allContratosAliquotas;
            }

            List<HistoricoFuncionario> histFuncList = _facade.GetHistoricoByFuncAndDatas(
                funcionario.Id, start, end);

            StringBuilder stb = new StringBuilder();
            stb.AppendLine("Foram encontradas " + histFuncList.Count + " ocorrências");
            stb.AppendLine("ID: " + funcionario.Id);
            stb.AppendLine("Nome: " + funcionario.Name);
            stb.AppendLine("Matrícula: " + funcionario.Matriculation);
            stb.AppendLine("Verba para cálculo: " + selectedVerba.Nome);
            stb.AppendLine(periodo);

            stb.AppendLine("---------------------------------------------------------------");
           
            List<RelatorioFunc> relatorioFuncs = new List<RelatorioFunc>();
            List<ContratoAliquota> aliquotasList = new List<ContratoAliquota>();

            RelatorioFunc relFunc;

            foreach (var histFunc in histFuncList)
            {
                if (histFunc.Contrato == null)
                    relFunc = new RelatorioFunc(histFunc.Cliente, histFunc.Data.Year);
                else
                    relFunc = new RelatorioFunc(histFunc.Contrato, histFunc.Data.Year);

                if (!relatorioFuncs.Contains(relFunc))
                {
                    aliquotasList = RelatoriosUtil.FilterAliquotas(histFunc, filteredContratoAliquotas);
                    foreach (var aliqObj in aliquotasList)
                    {
                        relFunc.computarValores(histFunc.SalarioBase, aliqObj.Verba, aliqObj.Aliquota); 
                    }
                    
                    relatorioFuncs.Add(relFunc);
                }
                else
                {
                    int index = relatorioFuncs.IndexOf(relFunc);
                    foreach (var aliqObj in aliquotasList)
                    {
                        relatorioFuncs[index].computarValores(histFunc.SalarioBase, aliqObj.Verba, aliqObj.Aliquota);
                    }
                }
               
                //stb.AppendLine(histFunc.Data.Month + "/" + histFunc.Data.Year);
                //stb.AppendLine(histFunc.SalarioBase.ToString());
            }

            foreach (var relF in relatorioFuncs)
            {
                stb.AppendLine("********************************************************");

                if (relF.Contrato == null)
                    stb.AppendLine("Cliente: " + relF.Cliente.Name);
                else
                    stb.AppendLine("Contrato: " + relF.Contrato.Name);

                stb.AppendLine("Ano: " + relF.Ano);
                //stb.AppendLine("Férias: " + relF.AcumuladoFerias);
                //stb.AppendLine("Décimo Salário: " + relF.AcumuladoDecimo);
                //stb.AppendLine("Multa: " + relF.AcumuladoMulta);
                //stb.AppendLine("Lucro: " + relF.AcumuladoLucro);
                //stb.AppendLine("Encargos Sociais: " + relF.AcumuladoEncSociais);
                if (verbaId == -1) //calcular todas
                {
                    string moneyAF = String.Format("{0:C}", relF.AcumuladoFerias);
                    stb.AppendLine("Férias: " + moneyAF);
                    string moneyAD = String.Format("{0:C}", relF.AcumuladoDecimo);
                    stb.AppendLine("Décimo Salário: " + moneyAD);
                    string moneyAM = String.Format("{0:C}", relF.AcumuladoMulta);
                    stb.AppendLine("Multa: " + moneyAM);
                    string moneyAL = String.Format("{0:C}", relF.AcumuladoLucro);
                    stb.AppendLine("Lucro: " + moneyAL);
                    string moneyAES = String.Format("{0:C}", relF.AcumuladoEncSociais);
                    stb.AppendLine("Encargos Sociais: " + moneyAES);
                } else
                {
                    if (selectedVerba.Codigo == 1) //Férias
                    {
                        string moneyAF = String.Format("{0:C}", relF.AcumuladoFerias);
                        stb.AppendLine("Férias: " + moneyAF);
                    }
                    else if (selectedVerba.Codigo == 2)
                    {
                        string moneyAD = String.Format("{0:C}", relF.AcumuladoDecimo);
                        stb.AppendLine("Décimo Salário: " + moneyAD);
                    }
                    else if (selectedVerba.Codigo == 3)
                    {
                        string moneyAM = String.Format("{0:C}", relF.AcumuladoMulta);
                        stb.AppendLine("Multa: " + moneyAM);
                    }
                    else if (selectedVerba.Codigo == 4)
                    {
                        string moneyAL = String.Format("{0:C}", relF.AcumuladoLucro);
                        stb.AppendLine("Lucro: " + moneyAL);
                    }
                    else if (selectedVerba.Codigo == 5)
                    {
                        string moneyAES = String.Format("{0:C}", relF.AcumuladoEncSociais);
                        stb.AppendLine("Encargos Sociais: " + moneyAES);
                    }
                }
                stb.AppendLine("********************************************************");
                exportFuncionario.RelFuncionarios.Add(relF);
            }

            txtResult.Text = stb.ToString();
        }
        
        private Verba GetSelectedVerba(int verbaId)
        {
            Verba founded = null;
            foreach (var verba in this.verbas)
            {
                if (verba.Id == verbaId)
                {
                    founded = verba;
                    break;
                }
            }
            return founded;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> stringsToEmail = RelatoriosUtil.ExportSolicitationFuncText(exportFuncionario);
            DlgTextoEmail dlgTextoEmail = new DlgTextoEmail(stringsToEmail);
            dlgTextoEmail.ShowDialog();
        }
    }
}
