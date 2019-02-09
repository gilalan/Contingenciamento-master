using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contingenciamento.Entidades;
using Contingenciamento.BLL;
using System.Text;
using Contingenciamento.Util;
using System.Collections;
using System.Data;

namespace Contingenciamento.GUI
{
    public partial class FrmRelatorioContrato : Form
    {

        Facade _facade = new Facade();
        List<Verba> verbas;
        List<ContratoAliquota> contratosAliquotas;
        List<Contrato> contratos;

        public FrmRelatorioContrato()
        {
            InitializeComponent();
        }
              
        private void FrmRelatorioContrato_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            contratos = _facade.GetTopContrato();
            verbas = _facade.GetTopVerba();
            contratosAliquotas = _facade.GetTopContratoAliquota();
            FillCbBox(contratos);
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

        private void FillCbBox(List<Contrato> contratos)
        {   
            
            groupCBContratos.ValueMember = "Value";
            groupCBContratos.DisplayMember = "Display";
            groupCBContratos.GroupMember = "Group";

            object[] items = new object[contratos.Count];
            int contador = 0;
            foreach (var contrato in contratos)
            {
                items[contador] = new { Value= contrato.Id, Display=contrato.Name, Group=contrato.Cliente.GetPairName()};
                contador++;
            }
            groupCBContratos.DataSource = new ArrayList(items);
            /*
            groupCBContratos.DataSource = new ArrayList(new object[] {
                new { Value=100, Display="Apples", Group="Fruit" },
                new { Value=101, Display="Pears", Group="Fruit" },
                new { Value=102, Display="Carrots", Group="Vegetables" },
                new { Value=103, Display="Beef", Group="Meat" },
                new { Value=104, Display="Cucumbers", Group="Vegetables" },
                new { Value=0, Display="(other)", Group=String.Empty },
                new { Value=105, Display="Chillies", Group="Vegetables" },
                new { Value=106, Display="Strawberries", Group="Fruit" }
            });
            */
            /*
            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("Display");
            dt.Columns.Add("Group");

            dt.Rows.Add(100, "Apples", "Fruit");
            dt.Rows.Add(101, "Pears", "Fruit");
            dt.Rows.Add(102, "Carrots", "Vegetables");
            dt.Rows.Add(103, "Beef", "Meat");
            dt.Rows.Add(104, "Cucumbers", "Vegetables");
            dt.Rows.Add(DBNull.Value, "(other)", DBNull.Value);
            dt.Rows.Add(105, "Chillies", "Vegetables");
            dt.Rows.Add(106, "Strawberries", "Fruit");

            groupCBContratos.DataSource = dt.DefaultView;
            */
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime start = dateTPStart.Value;
            DateTime end = dateTPEnd.Value;
            searchContrato(groupCBContratos.SelectedItem, start, end);
        }

        private void searchContrato(object cbItem, DateTime start, DateTime end)
        {
            dynamic d = cbItem;
            int contratoID = d.Value;
            string contratoName = d.Display;
            string clienteIDName = d.Group;            

            int pFrom = 1;//clienteIDName.IndexOf("key : ") + "key : ".Length;
            int pTo = clienteIDName.LastIndexOf("]");
            String result = clienteIDName.Substring(pFrom, pTo - pFrom);
            int clienteID = Convert.ToInt32(result);
         
            txtResult.Clear();
            List<HistoricoFuncionario> histFuncs = _facade.GetHistoricoByContratoAndDatas(clienteID, contratoID, start, end);
            StringBuilder stb = new StringBuilder();
            StringBuilder stbTotais = new StringBuilder();
            stb.AppendLine("Foram encontradas " + histFuncs.Count + " ocorrências");
            stb.AppendLine("ID: " + contratoID);
            stb.AppendLine("Nome: " + contratoName);
            stb.AppendLine("Período: " + start.Month + "/" + start.Year + " até " + end.Month + "/" + end.Year);

            stb.AppendLine("---------------------------------------------------------------");

            List<RelatorioCliente> relatorioClientes = new List<RelatorioCliente>();
            List<ContratoAliquota> aliquotasList = new List<ContratoAliquota>();

            RelatorioCliente relCliente;
            RelatorioCliente relTotais = new RelatorioCliente();

            foreach (var histFunc in histFuncs)
            {
                if (histFunc.Contrato == null)
                    relCliente = new RelatorioCliente(histFunc.Cliente, histFunc.Funcionario, histFunc.Data.Year);
                else
                    relCliente = new RelatorioCliente(histFunc.Contrato, histFunc.Funcionario, histFunc.Data.Year);

                if (!relatorioClientes.Contains(relCliente))
                {
                    aliquotasList = RelatoriosUtil.FilterAliquotas(histFunc, contratosAliquotas);
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
            string moneyAF, moneyAD, moneyAM, moneyAL, moneyAES;
            foreach (var relC in relatorioClientes)
            {
                stb.AppendLine("********************************************************");
                stb.AppendLine("Funcionário: " + relC.Funcionario.Name + "(" + relC.Funcionario.Matriculation + ")");
                stb.AppendLine("Contrato: " + relC.Contrato.Name);
                stb.AppendLine("Ano: " + relC.Ano);
                //stb.AppendLine("Férias: " + relC.AcumuladoFerias);
                moneyAF = String.Format("{0:C}", relC.AcumuladoFerias);
                stb.AppendLine("Férias: " + moneyAF);
                //stb.AppendLine("Décimo Salário: " + relC.AcumuladoDecimo);
                moneyAD = String.Format("{0:C}", relC.AcumuladoDecimo);
                stb.AppendLine("Décimo Salário: " + moneyAD);
                //stb.AppendLine("Multa: " + relC.AcumuladoMulta);
                moneyAM = String.Format("{0:C}", relC.AcumuladoMulta);
                stb.AppendLine("Multa: " + moneyAM);
                //stb.AppendLine("Lucro: " + relC.AcumuladoLucro);
                moneyAL = String.Format("{0:C}", relC.AcumuladoLucro);
                stb.AppendLine("Lucro: " + moneyAL);
                //stb.AppendLine("Encargos Sociais: " + relC.AcumuladoEncSociais);
                moneyAES = String.Format("{0:C}", relC.AcumuladoEncSociais);
                stb.AppendLine("Encargos Sociais: " + moneyAES);
                stb.AppendLine("********************************************************");

                //Para os totais
                relTotais.AcumuladoFerias += relC.AcumuladoFerias;
                relTotais.AcumuladoDecimo += relC.AcumuladoDecimo;
                relTotais.AcumuladoMulta += relC.AcumuladoMulta;
                relTotais.AcumuladoLucro += relC.AcumuladoLucro;
                relTotais.AcumuladoEncSociais += relC.AcumuladoEncSociais;
            }

            txtResult.Text = stb.ToString();

            stbTotais.AppendLine("### Contabilização Total ###");
            moneyAF = String.Format("{0:C}", relTotais.AcumuladoFerias);
            stbTotais.AppendLine("Férias: " + moneyAF);
            moneyAD = String.Format("{0:C}", relTotais.AcumuladoDecimo);
            stbTotais.AppendLine("Décimo Salário: " + moneyAD);
            moneyAM = String.Format("{0:C}", relTotais.AcumuladoMulta);
            stbTotais.AppendLine("Multa: " + moneyAM);
            moneyAL = String.Format("{0:C}", relTotais.AcumuladoLucro);
            stbTotais.AppendLine("Lucro: " + moneyAL);
            moneyAES = String.Format("{0:C}", relTotais.AcumuladoEncSociais);
            stbTotais.AppendLine("Encargos Sociais: " + moneyAES);
            stbTotais.AppendLine("********************************************************");
            double totalGeral = relTotais.AcumuladoFerias + relTotais.AcumuladoDecimo + relTotais.AcumuladoEncSociais +
                relTotais.AcumuladoMulta + relTotais.AcumuladoLucro;
            string moneyTotal = String.Format("{0:C}", totalGeral);
            stbTotais.AppendLine("Somatório Total das Verbas: " + moneyTotal);

            txtTotais.Text = stbTotais.ToString();
        }
    }
}
