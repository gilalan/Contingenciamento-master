using Contingenciamento.Entidades;
using System.Collections.Generic;


namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InsertExtraFund(ExtraFund extraFund)
        {
            this._extraFundDAO.Insert(extraFund);
        }

        public void UpdateExtraFund(int id, ExtraFund extraFund)
        {
            this._extraFundDAO.Update<int>(id, extraFund);
        }

        public ExtraFund GetExtraFund(int id)
        {
            return this._extraFundDAO.Get<int>(id);
        }

        public List<ExtraFund> GetTopExtraFund()
        {
            return this._extraFundDAO.GetTop();
        }

        public void DeleteExtraFund(int id)
        {
            this._extraFundDAO.Delete<int>(id);
        }

        public void InsertExtraFundList(HashSet<ExtraFund> contFundList)
        {
            this._extraFundDAO.BulkInsert(contFundList);
        }
    }
}
