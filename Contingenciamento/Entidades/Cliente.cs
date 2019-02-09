using System;
using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class Cliente
    {
        public Cliente() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodigoSOLL { get; set; }
        public string Cnpj { get; set; }

        public Cliente(int id, string name, string codigoSOLL, string cnpj)
        {
            Id = id;
            Name = name;
            CodigoSOLL = codigoSOLL;
            Cnpj = cnpj;
        }

        public Cliente(int id, string name, string codigoSOLL)
        {
            Id = id;
            Name = name;
            CodigoSOLL = codigoSOLL;
        }

        public Cliente(string name, string codigoSOLL)
        {
            Name = name;
            CodigoSOLL = codigoSOLL;
        }

        public void copyInfo(Cliente c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.CodigoSOLL = c.CodigoSOLL;
            this.Cnpj = c.Cnpj;
        }

        public string GetPairName()
        {
            return "[" + Id + "] - " + Name;
        }
    }

    class ClienteComparer : IEqualityComparer<Cliente>
    {
        public bool Equals(Cliente x, Cliente y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return x.CodigoSOLL == y.CodigoSOLL;
        }

        public int GetHashCode(Cliente obj)
        {
            // Stores the result.
            int result = Convert.ToInt32(obj.CodigoSOLL);

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return result;
        }
    }
}