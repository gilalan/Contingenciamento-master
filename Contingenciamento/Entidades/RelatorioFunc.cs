using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class RelatorioFunc
    {
        public RelatorioFunc() { }
        public Cliente Cliente { get; set; }
        public Contrato Contrato { get; set; }
        public int Ano { get; set; }
        public double AcumuladoFerias { get; set; }
        public double AcumuladoDecimo { get; set; }
        public double AcumuladoMulta { get; set; }
        public double AcumuladoLucro { get; set; }
        public double AcumuladoEncSociais { get; set; }

        public RelatorioFunc(Cliente cli, int ano)
        {
            Cliente = cli;
            Ano = ano;
        }

        public RelatorioFunc(Contrato contrato, int ano)
        {
            Contrato = contrato;
            Ano = ano;
        }

        public override bool Equals(Object obj)
        {
            RelatorioFunc relObj = obj as RelatorioFunc;
            if (relObj == null)
            {
                return false;
            }
            else
            {
                if (this.Contrato == null)
                    return (relObj.Cliente.Id == this.Cliente.Id) && (relObj.Ano == this.Ano);
                else
                    return (relObj.Contrato.Id == this.Contrato.Id) &&
                        (relObj.Ano == this.Ano);
            }

        }

        public override int GetHashCode()
        {
            int cID = this.Cliente.Id;
            int id = this.Contrato == null ? 1 : this.Contrato.Id;
            int ano = this.Ano;
            int result = 0;
            result = cID * id * ano;
            return result.GetHashCode();
        }

        public void computarValores(double salarioBase, Verba verba, double aliquota)
        {
            switch (verba.Codigo)
            {
                case 1: //Férias
                    AcumuladoFerias += salarioBase * (aliquota/100);
                    break;
                case 2:
                    AcumuladoDecimo += salarioBase * (aliquota/100);
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
