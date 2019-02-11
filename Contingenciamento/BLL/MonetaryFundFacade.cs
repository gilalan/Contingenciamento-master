using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InsertMonetaryFund(MonetaryFund monetaryFund)
        {
            this._monetaryFundDAO.Insert(monetaryFund);
        }

        public void UpdateMonetaryFund(int id, MonetaryFund monetaryFund)
        {
            this._monetaryFundDAO.Update<int>(id, monetaryFund);
        }

        public MonetaryFund GetMonetaryFund(int id)
        {
            return this._monetaryFundDAO.Get<int>(id);
        }

        public List<MonetaryFund> GetTopMonetaryFund()
        {
            return this._monetaryFundDAO.GetTop();
        }

        public void DeleteMonetaryFund(int id)
        {
            this._monetaryFundDAO.Delete<int>(id);
        }

        public void InsertMonetaryFundList(HashSet<MonetaryFund> contFundList)
        {
            this._monetaryFundDAO.BulkInsert(contFundList);
        }
    }
}
