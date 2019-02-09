using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class HistoricoFuncionario
    {
        public HistoricoFuncionario() { }
        public int Id { get; set; }
        public string CodigoDeptoSOLL { get; set; }
        public string NomeDeptoSOLL { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Contrato Contrato { get; set; }
        public Unidade Unidade { get; set; }
        //public int Mes { get; set; }
        //public int Ano { get; set; }
        public DateTime Data { get; set; }
        public double SalarioBase { get; set; }
        public double SalarioLiquido { get; set; }
        public bool EmFerias { get; set; }
        public DateTime InicioAquisicaoFerias { get; set; }
        public DateTime FimAquisicaoFerias { get; set; }
        public double TotalProventos { get; set; }
        public double AdicInsalubridade { get; set; }
        public double AdicPericulosidade { get; set; }
        public double DecimoSalario { get; set; }
        public double DecimoSalarioProporcional { get; set; }
        public double ValorFerias { get; set; }
        public double FeriasProporcional { get; set; }
        public double MultaRescisoria { get; set; }

        public HistoricoFuncionario(int id, string codigoDeptoSOLL, string nomeDeptoSOLL, Funcionario funcionario, Cliente cliente, Contrato contrato, Unidade unidade, DateTime data, double salario, double liquido, bool emFerias, DateTime inicioAquisicaoFerias, DateTime fimAquisicaoFerias, double adicInsalubridade, double adicPericulosidade, double decimoSalario, double decimoSalarioProporcional, double valorFerias, double feriasProporcional, double multaRescisoria)
        {
            Id = id;
            CodigoDeptoSOLL = codigoDeptoSOLL;
            NomeDeptoSOLL = nomeDeptoSOLL;
            Funcionario = funcionario;
            Cliente = cliente;
            Contrato = contrato;
            Unidade = unidade;
            //Mes = mes;
            //Ano = ano;
            Data = data;
            SalarioBase = salario;
            SalarioLiquido = liquido;
            EmFerias = emFerias;
            InicioAquisicaoFerias = inicioAquisicaoFerias;
            FimAquisicaoFerias = fimAquisicaoFerias;
            AdicInsalubridade = adicInsalubridade;
            AdicPericulosidade = adicPericulosidade;
            DecimoSalario = decimoSalario;
            DecimoSalarioProporcional = decimoSalarioProporcional;
            ValorFerias = valorFerias;
            FeriasProporcional = feriasProporcional;
            MultaRescisoria = multaRescisoria;
        }

        public HistoricoFuncionario(Funcionario funcionario, Cliente cliente, Contrato contrato, Unidade unidade)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Contrato = contrato;
            Unidade = unidade;
        }

        public void copyWorkerFinancialEvents (HistoricoFuncionario fromFunc)
        {
            if (fromFunc.AdicInsalubridade != 0)
                this.AdicInsalubridade = fromFunc.AdicInsalubridade;

            if (fromFunc.AdicPericulosidade != 0)
                this.AdicPericulosidade = fromFunc.AdicPericulosidade;

            if (fromFunc.DecimoSalario != 0)
                this.DecimoSalario = fromFunc.DecimoSalario;

            if (fromFunc.DecimoSalarioProporcional != 0)
                this.DecimoSalarioProporcional = fromFunc.DecimoSalarioProporcional;

            if (fromFunc.ValorFerias != 0)
                this.ValorFerias = fromFunc.ValorFerias;

            if (fromFunc.FeriasProporcional != 0)
                this.FeriasProporcional = fromFunc.FeriasProporcional;

            if (fromFunc.MultaRescisoria != 0)
                this.MultaRescisoria= fromFunc.MultaRescisoria;

            if (fromFunc.TotalProventos != 0)
                this.TotalProventos = fromFunc.TotalProventos;

            if (fromFunc.SalarioLiquido != 0)
                this.SalarioLiquido = fromFunc.SalarioLiquido;
        }

        public override bool Equals(Object obj)
        {
            HistoricoFuncionario personObj = obj as HistoricoFuncionario;
            if (personObj == null)
                return false;
            else
                return (personObj.Funcionario.Matriculation == this.Funcionario.Matriculation) && 
                    (personObj.Data.Month == this.Data.Month) && (personObj.Data.Year == this.Data.Year) && 
                    (personObj.EmFerias == this.EmFerias) && (personObj.Cliente.CodigoSOLL.Equals(this.Cliente.CodigoSOLL));
        }

        public override int GetHashCode()
        {
            int codigo = Convert.ToInt32(this.Funcionario.Matriculation);
            int mes = this.Data.Month;
            int ano = this.Data.Year;
            int clientId = Convert.ToInt32(this.Cliente.CodigoSOLL);
            int result = 0;
            result = codigo * mes * ano * clientId;
            return result.GetHashCode();
        }
    }

    class HistoricoFuncionarioComparer : IEqualityComparer<HistoricoFuncionario>
    {
        public bool Equals(HistoricoFuncionario x, HistoricoFuncionario y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return (x.Funcionario.Matriculation == y.Funcionario.Matriculation) && (x.Data.Month == y.Data.Month) && 
                (x.Data.Year == y.Data.Year) && (x.Cliente.CodigoSOLL.Equals(y.Cliente.CodigoSOLL));
        }

        public int GetHashCode(HistoricoFuncionario obj)
        {
            // Stores the result.
            int codigo = Convert.ToInt32(obj.Funcionario.Matriculation);
            int mes = obj.Data.Month;
            int ano = obj.Data.Year;
            int clientId = Convert.ToInt32(obj.Cliente.CodigoSOLL);
            int result = 0;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            // Get length.
            //int length = obj.Funcionario.Matriculation.Length;

            // Return default code for zero-length strings [valid, nothing to hash with].
            //if (length > 0)
            //{
            //    // Compute hash for strings with length greater than 1
            //    char let1 = obj.Funcionario.Matriculation[0];          // First char of string we use
            //    char let2 = obj.Funcionario.Matriculation[length - 1]; // Final char

            //    // Compute hash code from two characters
            //    int part1 = let1 + length;
            //    result = (_multiplier * part1) + let2 + length + mes + ano;
            //}
            result = codigo * mes * ano * clientId;
            return result;
        }
    }
}
