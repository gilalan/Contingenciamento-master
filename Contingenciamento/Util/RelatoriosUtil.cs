using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contingenciamento.Util
{
    public static class RelatoriosUtil
    {
        public static List<ContratoAliquota> FilterAliquotas(HistoricoFuncionario histFunc, List<ContratoAliquota> contratosAliquotas)
        {
            List<ContratoAliquota> filtered = new List<ContratoAliquota>();
            foreach (var contAliq in contratosAliquotas)
            {
                if (histFunc.Contrato == null)
                {
                    if (contAliq.Cliente.Id == histFunc.Cliente.Id && contAliq.Ano == histFunc.Data.Year)
                    {
                        filtered.Add(contAliq);
                    }
                }
                else
                {
                    if (contAliq.Contrato != null)
                    {
                        if (contAliq.Contrato.Id == histFunc.Contrato.Id && contAliq.Ano == histFunc.Data.Year)
                        {
                            filtered.Add(contAliq);
                        }
                    }
                }
            }
            return filtered;
        }

        public static List<string> ExportSolicitationFuncText(ExportFuncionario exportFuncionario)
        {
            List<string> stringsReturned = new List<string>();

            foreach (var relatorioFunc in exportFuncionario.RelFuncionarios)
            {
                double total = 0;
                StringBuilder stb = new StringBuilder();
                stb.AppendLine("Prezado, ");
                stb.AppendLine("");
                stb.AppendLine("");
                stb.AppendLine("através desta declaração de pagamentos, a empresa SOLL - Serviços, Obras e Locações LTDA solicita o reembolso da quantia contingenciada pelo contrato " + (relatorioFunc.Contrato == null ? relatorioFunc.Cliente.Name : relatorioFunc.Contrato.Name) + ".");
                stb.AppendLine("Nome do Funcionário: " + exportFuncionario.Funcionario.Name + ".");
                stb.AppendLine("Discriminação dos pagamentos efetuados: ");
                if (exportFuncionario.Verba.Codigo == -1)
                {
                    string moneyAF = String.Format("{0:C}", relatorioFunc.AcumuladoFerias);
                    stb.AppendLine("Férias: " + moneyAF);
                    string moneyAD = String.Format("{0:C}", relatorioFunc.AcumuladoDecimo);
                    stb.AppendLine("Décimo Salário: " + moneyAD);
                    string moneyAM = String.Format("{0:C}", relatorioFunc.AcumuladoMulta);
                    stb.AppendLine("Multa: " + moneyAM);
                    string moneyAL = String.Format("{0:C}", relatorioFunc.AcumuladoLucro);
                    stb.AppendLine("Lucro: " + moneyAL);
                    string moneyAES = String.Format("{0:C}", relatorioFunc.AcumuladoEncSociais);
                    stb.AppendLine("Encargos Sociais: " + moneyAES);
                    total = relatorioFunc.AcumuladoFerias + relatorioFunc.AcumuladoDecimo + relatorioFunc.AcumuladoMulta +
                        relatorioFunc.AcumuladoLucro + relatorioFunc.AcumuladoEncSociais;
                }
                else
                {
                    if (exportFuncionario.Verba.Codigo == 1) //Férias
                    {
                        string moneyAF = String.Format("{0:C}", relatorioFunc.AcumuladoFerias);
                        stb.AppendLine("Férias: " + moneyAF);
                        total = relatorioFunc.AcumuladoFerias;
                    }
                    else if (exportFuncionario.Verba.Codigo == 2)
                    {
                        string moneyAD = String.Format("{0:C}", relatorioFunc.AcumuladoDecimo);
                        stb.AppendLine("Décimo Salário: " + moneyAD);
                        total = relatorioFunc.AcumuladoDecimo;
                    }
                    else if (exportFuncionario.Verba.Codigo == 3)
                    {
                        string moneyAM = String.Format("{0:C}", relatorioFunc.AcumuladoMulta);
                        stb.AppendLine("Multa: " + moneyAM);
                        total = relatorioFunc.AcumuladoMulta;
                    }
                    else if (exportFuncionario.Verba.Codigo == 4)
                    {
                        string moneyAL = String.Format("{0:C}", relatorioFunc.AcumuladoLucro);
                        stb.AppendLine("Lucro: " + moneyAL);
                        total = relatorioFunc.AcumuladoLucro;
                    }
                    else if (exportFuncionario.Verba.Codigo == 5)
                    {
                        string moneyAES = String.Format("{0:C}", relatorioFunc.AcumuladoEncSociais);
                        stb.AppendLine("Encargos Sociais: " + moneyAES);
                        total = relatorioFunc.AcumuladoEncSociais;
                    }
                }
                stb.AppendLine("");
                stb.AppendLine("");
                stb.AppendLine("A discriminação de gastos é referente ao " + exportFuncionario.Periodo);
                stb.AppendLine("Em anexo, envio todos os comprovantes dos gastos a serem reembolsados.");
                stb.AppendLine("");
                stb.AppendLine("");
                stb.AppendLine("Cordialmente,");

                stringsReturned.Add(stb.ToString());
            }

            return stringsReturned;
        }
    }
}
