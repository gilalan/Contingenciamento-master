using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public double Balance { get; set; }

        public Bank(int id, string name, string agency, string account, double balance)
        {
            Id = id;
            Name = name;
            Agency = agency;
            Account = account;
            Balance = balance;
        }


    }
}
