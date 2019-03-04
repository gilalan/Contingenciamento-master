using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public List<long> InsertContingencyPast(ContingencyPast contingencyPast)
        {
            return this._contingencyPastDAO.Insert(contingencyPast);
        }

        public int UpdateContingencyPast(int id, ContingencyPast contingencyPast)
        {
            return this._contingencyPastDAO.Update<int>(id, contingencyPast);
        }

        public ContingencyPast GetContingencyPast(int id)
        {
            return this._contingencyPastDAO.Get<int>(id);
        }

        public List<ContingencyPast> GetTopContingencyPast()
        {
            return this._contingencyPastDAO.GetTop();
        }

        public int DeleteContingencyPast(int id)
        {
            return this._contingencyPastDAO.Delete<int>(id);
        }

        public int InsertContingencyPastList(List<ContingencyPast> contingencyPasts)
        {
            return this._contingencyPastDAO.BulkInsert(contingencyPasts);
        }
    }
}
