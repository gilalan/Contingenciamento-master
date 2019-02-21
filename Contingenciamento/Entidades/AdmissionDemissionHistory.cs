using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class AdmissionDemissionHistory
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DemissionDate { get; set; }
        public Role Role { get; set; }
        public string Matriculation { get; set; }
        public int EmployeeId { get; set; }

        public AdmissionDemissionHistory(DateTime adDate, DateTime demDate, Role role)
        {
            AdmissionDate = adDate;
            DemissionDate = demDate;
            Role = role;
        }

        public AdmissionDemissionHistory(DateTime adDate, DateTime demDate)
        {
            AdmissionDate = adDate;
            DemissionDate = demDate;
        }

        public AdmissionDemissionHistory(DateTime adDate, string matriculation)
        {
            AdmissionDate = adDate;
            Matriculation = matriculation;
        }

        public AdmissionDemissionHistory()
        {

        }
    }
}
