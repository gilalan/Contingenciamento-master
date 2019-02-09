using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class AdmissionDemissionHistory
    {
        public DateTime DataAdmissao { get; set; }
        public DateTime DataRescisao { get; set; }

        public AdmissionDemissionHistory(DateTime dataAdmissao, DateTime dataRescisao)
        {
            DataAdmissao = dataAdmissao;
            DataRescisao = dataRescisao;
        }
    }
}
