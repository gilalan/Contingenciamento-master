using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public long InsertContract(Contract contract)
        {
            return this._contractDAO.Insert(contract);
        }

        public void UpdateContract(long id, Contract contract)
        {
            this._contractDAO.Update<long>(id, contract);
        }

        public Contract GetContract(long id)
        {
            return this._contractDAO.Get<long>(id);
        }

        public List<Contract> GetTopContract()
        {
            return this._contractDAO.GetTop();
        }

        public void DeleteContract(long id)
        {
            this._contractDAO.Delete<long>(id);
        }

        public int InsertContractList(HashSet<Contract> contracts)
        {
            return this._contractDAO.BulkInsert(contracts);
        }
    }
}
