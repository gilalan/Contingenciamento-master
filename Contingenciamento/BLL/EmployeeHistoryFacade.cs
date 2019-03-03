using Contingenciamento.Entidades;
using System;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public long InsertEmployeeHistory(EmployeeHistory employeeHistory)
        {
            return this._employeeHistoryDAO.Insert(employeeHistory);
        }

        public void UpdateEmployeeHistory(int id, EmployeeHistory employeeHistory)
        {
            this._employeeHistoryDAO.Update<int>(id, employeeHistory);
        }

        public EmployeeHistory GetEmployeeHistory(int id)
        {
            return this._employeeHistoryDAO.Get<int>(id);
        }

        public EmployeeHistory GetEmployeeHistoryByMatriculation(string matriculation)
        {
            return this._employeeHistoryDAO.GetByEmployeeMatriculation(matriculation);
        }

        public List<EmployeeHistory> GetHistoryFromContract(Contract ct)
        {
            return this._employeeHistoryDAO.GetByContract(ct);
        }

        public long GetEmployeesCountByContract(Contract ct)
        {
            return this._employeeHistoryDAO.GetEmployeesCountByContract(ct);
        }    

        public List<EmployeeHistory> GetTopEmployeeHistory()
        {
            return this._employeeHistoryDAO.GetTop();
        }

        public void DeleteEmployeeHistory(int id)
        {
            this._employeeHistoryDAO.Delete<int>(id);
        }

        public int InsertEmployeeHistoryList(HashSet<EmployeeHistory> employeeHistorys)
        {
            return this._employeeHistoryDAO.BulkInsert(employeeHistorys);
        }
    }
}
