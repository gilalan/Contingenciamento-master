using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Contract
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SollId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartRange { get; set; }
        public string EndRange { get; set; }
        public List<Department> Departments { get; set; }
        public List<ContingencyFund> ContingencyFunds { get; set; }
        public List<MonetaryFund> MonetaryFunds { get; set; }

        public Contract(long id, string name, string sollId, DateTime startDate, DateTime endDate, string startRange, string endRange, List<Department> departments, List<ContingencyFund> contingencyFunds, List<MonetaryFund> monetaryFunds)
        {
            Id = id;
            Name = name;
            SollId = sollId;
            StartDate = startDate;
            EndDate = endDate;
            StartRange = startRange;
            EndRange = endRange;
            Departments = departments;
            ContingencyFunds = contingencyFunds;
            MonetaryFunds = monetaryFunds;
        }

        public Contract(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
