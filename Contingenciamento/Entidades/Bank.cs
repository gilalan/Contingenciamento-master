using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Bank
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string DV { get; set; }
        public double Balance { get; set; }

        public Bank(long id, string code, string name, string agency, string account, string dV, double balance)
        {
            Id = id;
            Code = code;
            Name = name;
            Agency = agency;
            Account = account;
            DV = dV;
            Balance = balance;
        }

        public Bank(long id, string name, string agency, string account, double balance)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Balance = balance;
        }

        public Bank (string name, string code, string agency, string account, string dv)
        {
            Name = name;
            Code = code;
            Agency = agency;
            Account = account;
            DV = dv;
            Balance = 0;
        }

        public Bank()
        {
            Name = "";
            Code = "";
            Agency = "";
            Account = "";
            DV = "";
            Balance = 0;
        }

        public void Update(Bank bankData)
        {
            this.Name = bankData.Name;
            this.Code = bankData.Code;
            this.Agency = bankData.Agency;
            this.Account = bankData.Account;
            this.DV = bankData.DV;
        }
    }

    class BankComparer : IEqualityComparer<Bank>
    {
        public bool Equals(Bank x, Bank y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return (x.Code + x.Agency + x.Account + x.DV).Equals(y.Code + y.Agency + y.Account + y.DV);
        }

        public int GetHashCode(Bank obj)
        {
            // Stores the result.
            int code = (obj.Code + obj.Agency + obj.Account + obj.DV).GetHashCode();

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return code;
        }
    }
}
