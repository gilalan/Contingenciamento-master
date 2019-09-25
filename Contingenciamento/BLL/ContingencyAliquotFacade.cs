using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public long InsertContingencyAliquot(ContingencyAliquot contingencyAliquot)
        {
            return this._contingencyAliquotDAO.Insert(contingencyAliquot);
        }

        public void UpdateContingencyAliquot(long id, ContingencyAliquot contingencyAliquot)
        {
            this._contingencyAliquotDAO.Update<long>(id, contingencyAliquot);
        }

        public ContingencyAliquot GetContingencyAliquot(long id)
        {
            return this._contingencyAliquotDAO.Get<long>(id);
        }

        public List<ContingencyAliquot> GetContingencyAliquotsByContract(Contract ct)
        {
            return this._contingencyAliquotDAO.GetByContract(ct);
        }

        public List<ContingencyAliquot> GetTopContingencyAliquot()
        {
            return this._contingencyAliquotDAO.GetTop();
        }

        public void DeleteContingencyAliquot(int id)
        {
            this._contingencyAliquotDAO.Delete<int>(id);
        }

        public void InsertContingencyAliquotList(HashSet<ContingencyAliquot> contFundList)
        {
            this._contingencyAliquotDAO.BulkInsert(contFundList);
        }
    }
}
