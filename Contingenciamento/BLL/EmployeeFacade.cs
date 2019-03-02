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
        public long InsertEmployee(Employee employee)
        {
            return this._employeeDAO.Insert(employee);
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            this._employeeDAO.Update<int>(id, employee);
        }

        public Employee GetEmployee(int id)
        {
            return this._employeeDAO.Get<int>(id);
        }

        public List<Employee> GetTopEmployee()
        {
            return this._employeeDAO.GetTop();
        }

        public void DeleteEmployee(int id)
        {
            this._employeeDAO.Delete<int>(id);
        }

        public void InsertEmployeeList(HashSet<Employee> employees)
        {
            this._employeeDAO.BulkInsert(employees);
        }
    }
}
