using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class ContingencyFund
    {
        public ContingencyFund() { }
        public long Id { get; set; }
        public string Name { get; set; }

        public ContingencyFund(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public ContingencyFund(string name)
        {
            this.Name = name;
        }
    }
}
