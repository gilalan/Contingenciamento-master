using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Employee
    {
        public int Id { get; set; }
        public int SollId { get; set; }
        public string Name { get; set; }
        public string Matriculation { get; set; }
        public string PIS { get; set; }
        public string CPF { get; set; }
        public string Status { get; set; }
        public DateTime Birthday { get; set; }
        public Bank BankData { get; set; }
        public DateTime CurrentAdmissionDate { get; set; }
        public DateTime CurrentDemissionDate { get; set; }
        public List<AdmissionDemissionHistory> AdmissionDemissionHistories { get; set; }

        public Employee(int id, int sollId, string name, string matriculation, string pIS, string cPF, string status, DateTime birthday, Bank bankData, DateTime currentAdmissionDate, DateTime currentDemissionDate, List<AdmissionDemissionHistory> admissionDemissionHistories)
        {
            Id = id;
            SollId = sollId;
            Name = name;
            Matriculation = matriculation;
            PIS = pIS;
            CPF = cPF;
            Status = status;
            Birthday = birthday;
            BankData = bankData;
            CurrentAdmissionDate = currentAdmissionDate;
            CurrentDemissionDate = currentDemissionDate;
            AdmissionDemissionHistories = admissionDemissionHistories;
        }
    }
       
}
