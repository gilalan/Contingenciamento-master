using Contingenciamento.Entidades;
using System;
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
            List<EmployeeHistory> employeeHistories = this._employeeHistoryDAO.GetByContract(contract, false);
            List<ContingencyPast> contingencyPasts = new List<ContingencyPast>();
            ContingencyPast cp;
            ContingencyAliquot caToAdd;
            foreach (EmployeeHistory eh in employeeHistories)
            {
                cp = new ContingencyPast();
                cp.EmployeeHistory = eh;
                cp.MonetaryFundName = monetaryFund.Name;
                foreach (ContingencyAliquot ca in contract.ContingencyAliquot)
                {
                    caToAdd = new ContingencyAliquot();
                    caToAdd.Id = ca.Id;
                    caToAdd.ContingencyFund = new ContingencyFund(ca.ContingencyFund.Id, ca.ContingencyFund.Name);
                    caToAdd.Value = ca.Value;
                    //essa parte tá horrorosa (calculando para cada Mês) 
                    if (monetaryFund.Name.ToUpper().Equals("SALÁRIO BASE"))
                    {                                               
                        caToAdd.CalculatedValue = Math.Round((ca.Value / 100) * eh.BaseSalary, 2);
                    }
                    else if (monetaryFund.Name.ToUpper().Equals("PROVENTOS TOTAIS"))
                    {
                        caToAdd.CalculatedValue = Math.Round((ca.Value / 100) * eh.TotalEarnings, 2);
                    }
                    else
                    {
                        caToAdd.CalculatedValue = Math.Round((ca.Value / 100) * eh.NetSalary, 2);
                    }

                    //if (ca.ContingencyFund.Name.ToUpper() == "FÉRIAS")
                    //    caToAdd.CalculatedValue = Math.Round(System.Convert.ToDouble(ca.CalculatedValue/3), 2);

                    cp.ContingencyAliquots.Add(caToAdd);
                }
                contingencyPasts.Add(cp);
            }
            return contingencyPasts;
        }
    }
}
