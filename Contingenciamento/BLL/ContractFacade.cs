using Contingenciamento.Entidades;
using System.Collections.Generic;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public long InsertContract(Contract contract)
        {
            return this._contractDAO.Insert(contract);
        }

        public void UpdateContract(long id, Contract contract)
        {
            this._contractDAO.Update<long>(id, contract);
        }

        public Contract GetContract(long id)
        {
            return this._contractDAO.Get<long>(id);
        }

        public List<Contract> GetOnlyContracts()
        {
            return this._contractDAO.GetOnlyContracts();
        }

        public List<Contract> GetTopContract()
        {
            return this._contractDAO.GetTop();
        }

        public void DeleteContract(long id)
        {
            this._contractDAO.Delete<long>(id);
        }

        public int InsertContractList(HashSet<Contract> contracts)
        {
            return this._contractDAO.BulkInsert(contracts);
        }

        public List<ContingencyPast> ProcessContingencyContract(Contract contract, MonetaryFund monetaryFund)
        {
            List<EmployeeHistory> employeeHistories = this._employeeHistoryDAO.GetByContract(contract);
            List<ContingencyPast> contingencyPasts = new List<ContingencyPast>();
            ContingencyPast cp;
            foreach (EmployeeHistory eh in employeeHistories)
            {
                cp = new ContingencyPast();
                cp.EmployeeHistory = eh;
                cp.MonetaryFundName = monetaryFund.Name;
                foreach (ContingencyAliquot ca in contract.ContingencyAliquot)
                {
                    //essa parte tá horrorosa (calculando para cada Mês) 
                    if (monetaryFund.Name.ToUpper().Equals("SALÁRIO BASE"))
                    {
                        ca.CalculatedValue = (ca.Value/100) * eh.BaseSalary; 
                    }
                    else if (monetaryFund.Name.ToUpper().Equals("PROVENTOS TOTAIS"))
                    {
                        ca.CalculatedValue = (ca.Value / 100) * eh.TotalEarnings;
                    }
                    else
                    {
                        ca.CalculatedValue = (ca.Value / 100) * eh.NetSalary;
                    }

                    if (ca.ContingencyFund.Name.ToUpper() == "FÉRIAS")
                        ca.CalculatedValue = System.Convert.ToDouble(ca.CalculatedValue/3);

                    cp.ContingencyAliquots.Add(ca);
                }
                contingencyPasts.Add(cp);
            }
            return contingencyPasts;
        }
    }
}
