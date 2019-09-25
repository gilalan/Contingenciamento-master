using System;
using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class Contract
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public List<Department> Departments { get; set; }
        public List<ContingencyAliquot> ContingencyAliquot { get; set; }
        public List<MonetaryFund> MonetaryFunds { get; set; }
        public double Balance { get; set; }

        public Contract(string name, string description, DateTime startDate, DateTime endDate, List<ContingencyAliquot> contingencyAliquot, List<MonetaryFund> monetaryFunds)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            //Departments = departments;
            ContingencyAliquot = contingencyAliquot;
            MonetaryFunds = monetaryFunds;
            Balance = 0;
        }

        public Contract(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public Contract (long id)
        {
            Id = id;
        }

        public Contract()
        {

        }
    }
}
