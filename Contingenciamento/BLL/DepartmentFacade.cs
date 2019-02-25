using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public long InsertDepartment(Department department)
        {
            return this._departmentDAO.Insert(department);
        }

        public void UpdateDepartment(int id, Department department)
        {
            this._departmentDAO.Update<int>(id, department);
        }

        public Department GetDepartment(int id)
        {
            return this._departmentDAO.Get<int>(id);
        }

        public Department GetDepartmentByCode(string code)
        {
            return this._departmentDAO.GetByCode(code);
        }

        public List<Department> GetTopDepartment()
        {
            return this._departmentDAO.GetTop();
        }

        public void DeleteDepartment(int id)
        {
            this._departmentDAO.Delete<int>(id);
        }

        public int InsertDepartmentList(HashSet<Department> departments)
        {
            return this._departmentDAO.BulkInsert(departments);
        }
    }
}
