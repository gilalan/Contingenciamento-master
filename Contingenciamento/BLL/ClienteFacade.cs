using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirCliente(Cliente cliente)
        {
            this._clienteDAO.Insert(cliente);
        }

        public void UpdateCliente(int id, Cliente cliente)
        {
            this._clienteDAO.Update<int>(id, cliente);
        }

        public Cliente GetCliente(int id)
        {
            return this._clienteDAO.Get<int>(id);
        }

        public Cliente GetClienteByIDSOLL(string idSoll)
        {
            return this._clienteDAO.GetBySollId<string>(idSoll);
        }

        public List<Cliente> GetTopCliente()
        {
            return this._clienteDAO.GetTop();
        }

        public void DeleteCliente(int id)
        {
            this._clienteDAO.Delete<int>(id);
        }

        public void InserirClienteList(HashSet<Cliente> funcList)
        {
            this._clienteDAO.BulkInsert(funcList);
        }
    }
}
