using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Employee
    {
        public long Id { get; set; }
        public long SollId { get; set; }
        public string Name { get; set; }
        public string Matriculation { get; set; }
        public string PIS { get; set; }
        public string CPF { get; set; }
        public string Status { get; set; }
        public DateTime Birthday { get; set; }
        public Bank BankData { get; set; }
        public Role Role { get; set; }
        public DateTime CurrentAdmissionDate { get; set; }
        public DateTime CurrentDemissionDate { get; set; }
        public List<AdmissionDemissionHistory> AdmissionDemissionHistories { get; set; }

        public Employee(long id, long sollId, string name, string matriculation, string pIS, string cPF, string status, DateTime birthday, Bank bankData, Role role, DateTime currentAdmissionDate, DateTime currentDemissionDate, List<AdmissionDemissionHistory> admissionDemissionHistories)
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
            Role = role;
            CurrentAdmissionDate = currentAdmissionDate;
            CurrentDemissionDate = currentDemissionDate;
            AdmissionDemissionHistories = admissionDemissionHistories;
        }

        public Employee(string name, string matriculation, string pIS, string cPF, DateTime birthday, Bank bankData, Role role, DateTime currentAdmissionDate)
        {
            Name = name;
            Matriculation = matriculation;
            PIS = pIS;
            CPF = cPF;
            Role = role;
            BankData = bankData;
            Birthday = birthday;
            CurrentAdmissionDate = currentAdmissionDate;
            AdmissionDemissionHistories = new List<AdmissionDemissionHistory>();
        }

        public Employee(string name, string matriculation, DateTime currentAdmDate)
        {
            Name = name;
            Matriculation = matriculation;
            CurrentAdmissionDate = currentAdmDate;
            AdmissionDemissionHistories = new List<AdmissionDemissionHistory>();
        }

        public Employee()
        {
            AdmissionDemissionHistories = new List<AdmissionDemissionHistory>();
        }

        public override bool Equals(Object obj)
        {
            Employee empObj = obj as Employee;
            if (empObj == null)
                return false;
            else
                return (empObj.CPF == this.CPF);
        }

        public override int GetHashCode()
        {
            return StringComparer.InvariantCultureIgnoreCase
                             .GetHashCode(this.CPF);
        }
    }

    class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return (x.CPF == y.CPF);
        }

        public int GetHashCode(Employee obj)
        {            
            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return StringComparer.InvariantCultureIgnoreCase
                             .GetHashCode(obj.CPF);
        }
    }

}
