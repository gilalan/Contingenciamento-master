using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class MonetaryFund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Primal { get; set; }
        public double Tax { get; set; }
        public List<ExtraFund> ExtraFunds { get; set; }

        public MonetaryFund(int id, string name, bool primal, double tax)
        {
            Id = id;
            Name = name;
            Primal = primal;
            Tax = tax;
        }

        public MonetaryFund(int id, string name, bool primal)
        {
            Id = id;
            Name = name;
            Primal = primal;
        }

        public MonetaryFund(string name, bool primal)
        {
            Name = name;
            Primal = primal;
        }

        public MonetaryFund()
        {
        }
    }
}