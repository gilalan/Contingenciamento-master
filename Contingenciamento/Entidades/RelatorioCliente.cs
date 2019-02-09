using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class RelatorioCliente
    {
        public Cliente Cliente { get; set; }
        public Contrato Contrato { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Ano { get; set; }
        public double AcumuladoFerias { get; set; }
        public double AcumuladoDecimo { get; set; }
        public double AcumuladoMulta { get; set; }
        public double AcumuladoLucro { get; set; }
        public double AcumuladoEncSociais { get; set; }

        public RelatorioCliente()
        {
            AcumuladoFerias = 0;
            AcumuladoDecimo = 0;
            AcumuladoMulta = 0;
            AcumuladoLucro = 0;
            AcumuladoEncSociais = 0;
        }

        public RelatorioCliente(Cliente cliente, Funcionario func, int ano)
        {
            Cliente = cliente;
            Funcionario = func;
            Ano = ano;
        }

        public RelatorioCliente(Contrato contrato, Funcionario func, int ano)
        {
            Contrato = contrato;
            Funcionario = func;
            Ano = ano;
        }

        public override bool Equals(Object obj)
        {
            RelatorioCliente relObj = obj as RelatorioCliente;
            if (relObj == null)
                return false;
            else
            {
                if (this.Contrato == null || relObj.Contrato == null)
                    return (relObj.Cliente.Id == this.Cliente.Id) && (relObj.Funcionario.Matriculation == this.Funcionario.Matriculation) &&
                        (relObj.Ano == this.Ano);
                else
                    return (relObj.Contrato.Id == this.Contrato.Id) && (relObj.Funcionario.Matriculation == this.Funcionario.Matriculation) && 
                        (relObj.Ano == this.Ano);

            }
        }

        public override int GetHashCode()
        {
            int cId = this.Cliente.Id;
            int id = this.Contrato == null ? 1 : this.Contrato.Id;
            int fId = Convert.ToInt32(this.Funcionario.Matriculation);
            int ano = this.Ano;
            int result = 0;
            result = cId * id * ano * fId;
            return result.GetHashCode();
        }

        public void computarValores(double salarioBase, Verba verba, double aliquota)
        {
            switch (verba.Codigo)
            {
                case 1: //Férias
                    AcumuladoFerias += salarioBase * (aliquota / 100);
                    break;
                case 2:
                    AcumuladoDecimo += salarioBase * (aliquota / 100);
                    break;
                case 3:
                    AcumuladoMulta += salarioBase * (aliquota / 100);
                    break;
                case 4:
                    AcumuladoLucro += salarioBase * (aliquota / 100);
                    break;
                case 5:
                    AcumuladoEncSociais += salarioBase * (aliquota / 100);
                    break;
                default:
                    break;
            }
        }
    }
}
