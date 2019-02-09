using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contingenciamento.Entidades;
using Contingenciamento.BLL;
using System.Text;
using Contingenciamento.Util;

namespace Contingenciamento.GUI
{
    public partial class FrmRelatorioCliente : Form
    {
        Facade _facade = new Facade();
        List<Verba> verbas;
        List<ContratoAliquota> contratosAliquotas;
        List<Cliente> clientes;

        public FrmRelatorioCliente()
        {
            InitializeComponent();
        }
        
        private void FrmRelatorioCliente_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            clientes = _facade.GetTopCliente();
            verbas = _facade.GetTopVerba();
            contratosAliquotas = _facade.GetTopContratoAliquota();
            FillCbBox(clientes);
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

        private void FillCbBox(List<Cliente> clientes)
        {
            var source = new BindingSource();
            source.DataSource = clientes;
            cbClientes.DataSource = source;
            cbClientes.DisplayMember = "Name";
            cbClientes.ValueMember = "Id";
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime start = dateTPStart.Value;
            DateTime end = dateTPEnd.Value;
            searchClient(cbClientes.SelectedItem, start, end);
        }

        private void searchClient(object item, DateTime start, DateTime end)
        {
            Cliente cliente = (Cliente)item;
            txtResult.Clear();
            List<HistoricoFuncionario> histFuncs = _facade.GetHistoricoByClienteAndDatas(cliente.Id, start, end);
            StringBuilder stb = new StringBuilder();
            stb.AppendLine("Foram encontradas " + histFuncs.Count + " ocorrências");
            stb.AppendLine("ID: " + cliente.Id);
            stb.AppendLine("Nome: " + cliente.Name);
            stb.AppendLine("Período: " + start.Month + "/" + start.Year + " até " + end.Month + "/" + end.Year);

            stb.AppendLine("---------------------------------------------------------------");

            List<RelatorioCliente> relatorioClientes = new List<RelatorioCliente>();
            List<ContratoAliquota> aliquotasList = new List<ContratoAliquota>();

            RelatorioCliente relCliente;

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
                } else
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
                stb.AppendLine("Funcionário: " + relC.Funcionario.Name + "(" + relC.Funcionario.Matriculation + ")");
                stb.AppendLine("Contrato: " + relC.Contrato.Name);
                stb.AppendLine("Ano: " + relC.Ano);
                //stb.AppendLine("Férias: " + relC.AcumuladoFerias);
                string moneyAF = String.Format("{0:C}", relC.AcumuladoFerias);
                stb.AppendLine("Férias: " + moneyAF);
                //stb.AppendLine("Décimo Salário: " + relC.AcumuladoDecimo);
                string moneyAD = String.Format("{0:C}", relC.AcumuladoDecimo);
                stb.AppendLine("Décimo Salário: " + moneyAD);
                //stb.AppendLine("Multa: " + relC.AcumuladoMulta);
                string moneyAM = String.Format("{0:C}", relC.AcumuladoMulta);
                stb.AppendLine("Multa: " + moneyAM);
                //stb.AppendLine("Lucro: " + relC.AcumuladoLucro);
                string moneyAL = String.Format("{0:C}", relC.AcumuladoLucro);
                stb.AppendLine("Lucro: " + moneyAL);
                //stb.AppendLine("Encargos Sociais: " + relC.AcumuladoEncSociais);
                string moneyAES = String.Format("{0:C}", relC.AcumuladoEncSociais);
                stb.AppendLine("Encargos Sociais: " + moneyAES);
                stb.AppendLine("********************************************************");
            }

            txtResult.Text = stb.ToString();
        }
    }
}
