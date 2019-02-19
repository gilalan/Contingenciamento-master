using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InsertBank(Bank bank)
        {
            this._bankDAO.Insert(bank);
        }

        public void UpdateBank(int id, Bank bank)
        {
            this._bankDAO.Update<int>(id, bank);
        }

        public Bank GetBank(int id)
        {
            return this._bankDAO.Get<int>(id);
        }

        public List<Bank> GetTopBank()
        {
            return this._bankDAO.GetTop();
        }

        public void DeleteBank(int id)
        {
            this._bankDAO.Delete<int>(id);
        }

        public void InsertBankList(HashSet<Bank> banks)
        {
            this._bankDAO.BulkInsert(banks);
        }
    }
}
