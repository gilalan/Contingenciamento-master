using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Contrato
    {
        public Contrato() { }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Name { get; set; }
        public string CodigoSOLL { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public Contrato(int id, Cliente cliente, string name, string codigoSOLL, DateTime inicio, DateTime termino)
        {
            Id = id;
            Cliente = cliente;
            Name = name;
            CodigoSOLL = codigoSOLL;
            Inicio = inicio;
            Termino = termino;
        }

        public Contrato(string name, string codigoSOLL)
        {
            Name = name;
            CodigoSOLL = codigoSOLL;
        }

        public Contrato(string name, string codigoSOLL, Cliente cliente)
        {
            Name = name;
            CodigoSOLL = codigoSOLL;
            Cliente = cliente;
        }

        public Contrato(int id, string name, string codigoSOLL, Cliente cliente)
        {
            Id = id;
            Name = name;
            CodigoSOLL = codigoSOLL;
            Cliente = cliente;
        }

        public void copyInfo(Contrato c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.CodigoSOLL = c.CodigoSOLL;
            this.Inicio = c.Inicio;
            this.Termino = c.Termino;
            this.Cliente.copyInfo(c.Cliente);
        }

        public override bool Equals(Object obj)
        {
            Contrato cObj = obj as Contrato;
            if (cObj == null)
                return false;
            else
                return (cObj.Cliente.CodigoSOLL == this.Cliente.CodigoSOLL) && 
                    (cObj.CodigoSOLL == this.CodigoSOLL);
        }

        public override int GetHashCode()
        {
            // Stores the result.
            int hash = 23;
            int cliCodigo = Convert.ToInt32(this.Cliente.CodigoSOLL);
            int contCodigo = Convert.ToInt32(this.CodigoSOLL);
            int result = hash * 31 + cliCodigo + contCodigo;

            return result.GetHashCode();
        }
    }

    class ContratoComparer : IEqualityComparer<Contrato>
    {
        public bool Equals(Contrato x, Contrato y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return (x.Cliente.CodigoSOLL == y.Cliente.CodigoSOLL) && (x.CodigoSOLL == y.CodigoSOLL);
        }

        public int GetHashCode(Contrato obj)
        {
            // Stores the result.
            int hash = 23;
            int cliCodigo = Convert.ToInt32(obj.Cliente.CodigoSOLL);
            int contCodigo = Convert.ToInt32(obj.CodigoSOLL);
            int result = hash * 31 + cliCodigo + contCodigo;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return result;
        }
    }
}
