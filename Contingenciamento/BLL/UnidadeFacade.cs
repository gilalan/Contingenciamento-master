using System.Collections.Generic;
using Contingenciamento.Entidades;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirUnidade(Unidade unidade)
        {
            this._unidadeDAO.Insert(unidade);
        }

        public void UpdateUnidade(int id, Unidade unidade)
        {
            this._unidadeDAO.Update<int>(id, unidade);
        }

        public Unidade GetUnidade(int id)
        {
            return this._unidadeDAO.Get<int>(id);
        }

        public Unidade GetUnidadeByKey(int idContrato, string id_soll)
        {
            return this._unidadeDAO.GetByKey<int, string>(idContrato, id_soll);
        }

        public List<Unidade> GetTopUnidade()
        {
            return this._unidadeDAO.GetTop();
        }

        public void DeleteUnidade(int id)
        {
            this._unidadeDAO.Delete<int>(id);
        }

        public void InserirUnidadeList(HashSet<Unidade> funcList)
        {
            this._unidadeDAO.BulkInsert(funcList);
        }
    }
}
