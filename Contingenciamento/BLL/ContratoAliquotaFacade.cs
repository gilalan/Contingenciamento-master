using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirContratoAliquota(ContratoAliquota contratoAliquota)
        {
            try
            {
                this._contratoAliquotaDAO.Insert(contratoAliquota);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateContratoAliquota(int id, ContratoAliquota contratoAliquota)
        {
            this._contratoAliquotaDAO.Update<int>(id, contratoAliquota);
        }

        public ContratoAliquota GetContratoAliquota(int id)
        {
            return this._contratoAliquotaDAO.Get<int>(id);
        }

        public List<ContratoAliquota> GetTopContratoAliquota()
        {
            return this._contratoAliquotaDAO.GetTop();
        }

        public void DeleteContratoAliquota(int id)
        {
            this._contratoAliquotaDAO.Delete<int>(id);
        }

        public void InserirContratoAliquotaList(HashSet<ContratoAliquota> funcList)
        {
            this._contratoAliquotaDAO.BulkInsert(funcList);
        }
    }
}
