using System;
using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class ContingencyAliquot
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Contract Contract { get; set; }
        public ContingencyFund ContingencyFund { get; set; }
        public double CalculatedValue { get; set; } //usado apenas na exibição dos dados

        public ContingencyAliquot(long id, double value, DateTime startDate, DateTime endDate, ContingencyFund contingencyFund)
        {
            Id = id;
            Value = value;
            StartDate = startDate;
            EndDate = endDate;
            ContingencyFund = contingencyFund;
        }

        public ContingencyAliquot(long id, double value, ContingencyFund contingencyFund, double calculatedValue)
        {
            Id = id;
            Value = value;
            ContingencyFund = contingencyFund;
            CalculatedValue = calculatedValue;
        }

        public ContingencyAliquot(double value, ContingencyFund contingencyFund)
        {
            Value = value;
            ContingencyFund = contingencyFund;
        }

        public ContingencyAliquot()
        {
        }
    }

    class ContingencyAliquotComparer : IEqualityComparer<ContingencyAliquot>
    {
        public bool Equals(ContingencyAliquot x, ContingencyAliquot y)
        {
            if (x == null || y == null || x.GetType() != y.GetType() || x.ContingencyFund == null || y.ContingencyFund == null)
                return false;
            
            return x.ContingencyFund.Id == y.ContingencyFund.Id;
        }

        public int GetHashCode(ContingencyAliquot obj)
        {
            // Don't compute hash code on null object.
            if (obj == null || obj.ContingencyFund == null)
            {
                return 0;
            }
            else
            {
                return obj.ContingencyFund.Id.GetHashCode();
            }
        }
    }
}