using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Vacation
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartAcquisitionPeriod { get; set; }
        public DateTime EndAcquisitionPeriod { get; set; }
        public DateTime StartTaken { get; set; }
        public DateTime EndTaken { get; set; }

        public Vacation(int id, Employee employee, DateTime startAcquisitionPeriod, DateTime endAcquisitionPeriod, DateTime startTaken, DateTime endTaken)
        {
            Id = id;
            Employee = employee;
            StartAcquisitionPeriod = startAcquisitionPeriod;
            EndAcquisitionPeriod = endAcquisitionPeriod;
            StartTaken = startTaken;
            EndTaken = endTaken;
        }
    }
}
