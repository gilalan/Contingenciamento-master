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
            ExtraFunds = new List<ExtraFund>();
        }

        public MonetaryFund(int id, string name, bool primal)
        {
            Id = id;
            Name = name;
            Primal = primal;
            ExtraFunds = new List<ExtraFund>();
        }

        public MonetaryFund(string name, bool primal)
        {
            Name = name;
            Primal = primal;
            ExtraFunds = new List<ExtraFund>();
        }

        public MonetaryFund()
        {
            ExtraFunds = new List<ExtraFund>();
        }
    }

    class MonetaryFundComparer : IEqualityComparer<MonetaryFund>
    {
        public bool Equals(MonetaryFund x, MonetaryFund y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(MonetaryFund obj)
        {
            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}