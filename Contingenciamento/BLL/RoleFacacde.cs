using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InsertRole(Role role)
        {
            this._roleDAO.Insert(role);
        }

        public void UpdateRole(int id, Role role)
        {
            this._roleDAO.Update<int>(id, role);
        }

        public Role GetRole(int id)
        {
            return this._roleDAO.Get<int>(id);
        }

        public List<Role> GetTopRole()
        {
            return this._roleDAO.GetTop();
        }

        public void DeleteRole(int id)
        {
            this._roleDAO.Delete<int>(id);
        }

        public void InsertRoleList(HashSet<Role> roles)
        {
            this._roleDAO.BulkInsert(roles);
        }
    }
}
