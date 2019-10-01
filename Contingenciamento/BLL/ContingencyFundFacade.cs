using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public int InsertContigencyFund(ContingencyFund contingencyFund)
        {
            return this._contingencyFundDAO.Insert(contingencyFund);
        }

        public void UpdateContigencyFund(int id, ContingencyFund contingencyFund)
        {
            this._contingencyFundDAO.Update<int>(id, contingencyFund);
        }

        public ContingencyFund GetContigencyFund(int id)
        {
            return this._contingencyFundDAO.Get<int>(id);
        }

        public List<ContingencyFund> GetTopContigencyFund()
        {
            return this._contingencyFundDAO.GetTop();
        }

        public void DeleteContigencyFund(int id)
        {
            this._contingencyFundDAO.Delete<int>(id);
        }

        public void InsertContigencyFundList(HashSet<ContingencyFund> contFundList)
        {
            this._contingencyFundDAO.BulkInsert(contFundList);
        }        
    }
}
