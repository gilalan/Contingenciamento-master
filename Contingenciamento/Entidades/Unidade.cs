using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Unidade
    {
        public Unidade() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodigoSOLL { get; set; }
        public Contrato Contrato { get; set; }
        public string CodigoDepartamento { get; set; }

        public Unidade(int id, string name, string codigoSOLL, Contrato contrato)
        {
            Id = id;
            Name = name;
            CodigoSOLL = codigoSOLL;
            Contrato = contrato;
        }

        public Unidade(int id, string name, string codigoSOLL)
        {
            Id = id;
            Name = name;
            CodigoSOLL = codigoSOLL;
        }

        public Unidade(string name, string codigoSOLL)
        {
            Name = name;
            CodigoSOLL = codigoSOLL;
        }

        public Unidade(string codigoDepartamento)
        {
            CodigoDepartamento = codigoDepartamento;
        }

        public void copyInfo(Unidade u)
        {
            this.Id = u.Id;
            this.Name = u.Name;
            this.CodigoDepartamento = u.CodigoDepartamento;
            this.CodigoSOLL = u.CodigoSOLL;
            this.Contrato.copyInfo(u.Contrato);
        }

        public override bool Equals(Object obj)
        {
            Unidade uObj = obj as Unidade;
            if (uObj == null)
                return false;
            else
                return (uObj.Contrato.Cliente.CodigoSOLL == this.Contrato.Cliente.CodigoSOLL) &&
                    (uObj.Contrato.CodigoSOLL == this.Contrato.CodigoSOLL) &&
                    (uObj.CodigoSOLL == this.CodigoSOLL);
        }

        public override int GetHashCode()
        {
            // Stores the result.
            int cliCod = Convert.ToInt32(this.Contrato.Cliente.CodigoSOLL);
            int contCod = Convert.ToInt32(this.Contrato.CodigoSOLL);
            int undCod = Convert.ToInt32(this.CodigoSOLL);
            int result = cliCod * contCod * undCod * this.Name.Length;
            return result.GetHashCode();
        }
    }

        class UnidadeComparer : IEqualityComparer<Unidade>
    {
        public bool Equals(Unidade x, Unidade y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return (x.Contrato.Cliente.CodigoSOLL == y.Contrato.Cliente.CodigoSOLL) && 
                (x.Contrato.CodigoSOLL == y.Contrato.CodigoSOLL) && 
                (x.CodigoSOLL == y.CodigoSOLL);
        }

        public int GetHashCode(Unidade obj)
        {
            int cliCod = Convert.ToInt32(obj.Contrato.Cliente.CodigoSOLL);
            int contCod = Convert.ToInt32(obj.Contrato.CodigoSOLL);
            int undCod = Convert.ToInt32(obj.CodigoSOLL);
            int result =  cliCod * contCod * undCod * obj.Name.Length;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return result;
        }
    }
}
