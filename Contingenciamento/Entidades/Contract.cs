using System;
using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class Contract
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public List<Department> Departments { get; set; }
        public List<ContingencyAliquot> ContingencyAliquot { get; set; }
        public List<MonetaryFund> MonetaryFunds { get; set; }

        public Contract(string name, DateTime startDate, DateTime endDate, List<ContingencyAliquot> contingencyAliquot, List<MonetaryFund> monetaryFunds)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            //Departments = departments;
            ContingencyAliquot = contingencyAliquot;
            MonetaryFunds = monetaryFunds;
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
