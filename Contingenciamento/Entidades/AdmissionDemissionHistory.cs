using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class AdmissionDemissionHistory
    {
        public DateTime AdmissionDate { get; set; }
        public DateTime DemissionDate { get; set; }

        public AdmissionDemissionHistory(DateTime adDate, DateTime demDate)
        {
            AdmissionDate = adDate;
            DemissionDate = demDate;
        }
    }
}
