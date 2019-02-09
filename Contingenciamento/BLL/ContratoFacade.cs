using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirContrato(Contrato contrato)
        {
            this._contratoDAO.Insert(contrato);
        }

        public void UpdateContrato(int id, Contrato contrato)
        {
            this._contratoDAO.Update<int>(id, contrato);
        }

        public Contrato GetContrato(int id)
        {
            return this._contratoDAO.Get<int>(id);
        }
        
        public Contrato GetContratoByIDSOLL(int clientId, string idSoll)
        {
            return this._contratoDAO.GetBySollId<int, string>(clientId, idSoll);
        }

        public List<Contrato> GetTopContrato()
        {
            return this._contratoDAO.GetTop();
        }

        public void DeleteContrato(int id)
        {
            this._contratoDAO.Delete<int>(id);
        }

        public void InserirContratoList(HashSet<Contrato> funcList)
        {
            this._contratoDAO.BulkInsert(funcList);
        }
    }
}
