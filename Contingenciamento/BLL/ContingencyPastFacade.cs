using Contingenciamento.Entidades;
using System;
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

        public List<ContingencyPast> GetContingencyPastsByContract(Contract contract)
        {
            HashSet<ContingencyPast> cps = this._contingencyPastDAO.GetByContract(contract);
            return new List<ContingencyPast>(cps);
        }

        public int DeleteContingencyPast(int id)
        {
            return this._contingencyPastDAO.Delete<int>(id);
        }

        public int InsertContingencyPastList(List<ContingencyPast> contingencyPasts)
        {
            return this._contingencyPastDAO.BulkInsert(contingencyPasts);
        }

        public int DeleteContingencyByContractAndDateRange(Contract ct, DateTime start, DateTime end)
        {
            return this._contingencyPastDAO.DeleteContingencyByContractAndDateRange(ct, start, end);
        }

        public int DeleteContingencyByContract(Contract ct)
        {
            return this._contingencyPastDAO.DeleteContingencyByContract(ct);
        }

        public HashSet<ContingencyPast> GetContingencyPastsByEmployeeHistoryList(List<EmployeeHistory> employeeHistories, ContingencyFund cf)
        {
            HashSet<ContingencyPast> hsContingencyPasts = new HashSet<ContingencyPast>();
            HashSet<ContingencyPast> allContingencyPasts = this._contingencyPastDAO.GetContingencyPastsByEmployeeHistoryList(employeeHistories, cf);
            DateTime dtEpoch;
            int value1;
            int value2;
            foreach (ContingencyPast cp in allContingencyPasts)
            {
                dtEpoch = cp.EmployeeHistory.Epoch;
                foreach (EmployeeHistory eh in employeeHistories)
                {
                    if (cp.EmployeeHistory.Employee.Id == eh.Employee.Id)
                    {
                        value1 = DateTime.Compare(dtEpoch, eh.StartVacationTaken);
                        value2 = DateTime.Compare(dtEpoch, eh.EndVacationTaken);
                        if (value1 >= 0 && value2 <= 0)
                        {
                            hsContingencyPasts.Add(cp);
                        }
                    }
                }
            }
            return hsContingencyPasts;
        }
    }
}
