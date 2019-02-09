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
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Aliquot> Aliquots { get; set; }

        public ContingencyFund(int id, string name, List<Aliquot> aliquots)
        {
            this.Id = id;
            this.Name = name;
            this.Aliquots = aliquots;
        }
    }
}
