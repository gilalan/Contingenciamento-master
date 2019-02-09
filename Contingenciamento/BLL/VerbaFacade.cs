using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirVerba(Verba verba)
        {
            this._verbaDAO.Insert(verba);
        }

        public void UpdateVerba(int id, Verba verba)
        {
            this._verbaDAO.Update<int>(id, verba);
        }

        public Verba GetVerba(int id)
        {
            return this._verbaDAO.Get<int>(id);
        }

        public List<Verba> GetTopVerba()
        {
            return this._verbaDAO.GetTop();
        }

        public void DeleteVerba(int id)
        {
            this._verbaDAO.Delete<int>(id);
        }

        public void InserirVerbaList(HashSet<Verba> funcList)
        {
            this._verbaDAO.BulkInsert(funcList);
        }
    }
}
