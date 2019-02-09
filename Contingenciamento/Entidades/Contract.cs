using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SollId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartRange { get; set; }
        public string EndRange { get; set; }
        public List<Department> Departments { get; set; }
        public List<ContingencyFund> ContingencyFunds { get; set; }
        public List<MonetaryFund> MonetaryFunds { get; set; }

    }
}
