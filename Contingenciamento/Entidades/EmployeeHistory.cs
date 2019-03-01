using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class EmployeeHistory
    {
        public long Id { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        public Contract Contract { get; set; }
        public DateTime Epoch { get; set; }
        public double BaseSalary { get; set; }
        public double NetSalary { get; set; }
        public double TotalEarnings { get; set; }
        public bool InVacation { get; set; }
        public DateTime StartVacationTaken { get; set; }
        public DateTime EndVacationTaken { get; set; }
        public double HazardAdditional { get; set; }
        public double DangerousnessAdditional { get; set; }
        public double ThirteenthSalary { get; set; }
        public double ThirteenthProportionalSalary { get; set; }
        public double VacationPay { get; set; }
        public double VacationProportionalPay { get; set; }
        public double PenaltyRescission { get; set; }

        public EmployeeHistory(long id, Employee employee, Department department, Contract contract, DateTime epoch, double baseSalary, 
            double netSalary, double totalEarnings, bool inVacation, DateTime startVacationTaken, DateTime endVacationTaken, double hazardAdditional, 
            double dangerousnessAdditional, double thirteenthSalary, double thirteenthProportionalSalary, double vacationPay, 
            double vacationProportionalPay, double penaltyRescission)
        {
            Id = id;
            Employee = employee;
            Department = department;
            Contract = contract;
            Epoch = epoch;
            BaseSalary = baseSalary;
            NetSalary = netSalary;
            TotalEarnings = totalEarnings;
            InVacation = inVacation;
            StartVacationTaken = startVacationTaken;
            EndVacationTaken = endVacationTaken;
            HazardAdditional = hazardAdditional;
            DangerousnessAdditional = dangerousnessAdditional;
            ThirteenthSalary = thirteenthSalary;
            ThirteenthProportionalSalary = thirteenthProportionalSalary;
            VacationPay = vacationPay;
            VacationProportionalPay = vacationProportionalPay;
            PenaltyRescission = penaltyRescission;
        }

        public EmployeeHistory()
        {
            this.Employee = new Employee();
            this.Department = new Department();
        }
    }

    class EmployeeHistoryComparer : IEqualityComparer<EmployeeHistory>
    {
        public bool Equals(EmployeeHistory x, EmployeeHistory y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return ( (x.Employee.Id == y.Employee.Id) && (x.Epoch.Year == y.Epoch.Year && x.Epoch.Month == y.Epoch.Month) && (x.InVacation == y.InVacation) );
        }

        public int GetHashCode(EmployeeHistory obj)
        {
            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = obj.Epoch.ToUniversalTime() - origin;
            int totalSecs = Convert.ToInt32 (Math.Floor((diff.TotalSeconds)));

            return obj.Employee.Id ^ totalSecs ^ Convert.ToInt32(obj.InVacation);
        }
    }
}
