﻿using Contingenciamento.DAO;

namespace Contingenciamento.BLL
{
    public class FactoryDAO
    {
        public static FuncionarioDAO CreateFuncionarioDAO()
        {
            return new FuncionarioDAO();
        }

        public static ClienteDAO CreateClienteDAO()
        {
            return new ClienteDAO();
        }

        public static ContratoDAO CreateContratoDAO()
        {
            return new ContratoDAO();
        }

        public static UnidadeDAO CreateUnidadeDAO()
        {
            return new UnidadeDAO();
        }

        public static HistoricoFuncionarioDAO CreateHistoricoFuncionarioDAO()
        {
            return new HistoricoFuncionarioDAO();
        }

        public static VerbaDAO CreateVerbaDAO()
        {
            return new VerbaDAO();
        }

        public static ContratoAliquotaDAO CreateContratoAliquotaDAO()
        {
            return new ContratoAliquotaDAO();
        }

        public static ContingencyFundDAO CreateContigencyFundDAO()
        {
            return new ContingencyFundDAO();
        }

        public static MonetaryFundDAO CreateMonetaryFundDAO()
        {
            return new MonetaryFundDAO();
        }

        public static ExtraFundDAO CreateExtraFundDAO()
        {
            return new ExtraFundDAO();
        }

        public static EmployeeDAO CreateEmployeeDAO()
        {
            return new EmployeeDAO();
        }

        public static RoleDAO CreateRoleDAO()
        {
            return new RoleDAO();
        }

        public static BankDAO CreateBankDAO()
        {
            return new BankDAO();
        }

        public static DepartmentDAO CreateDepartmentDAO()
        {
            return new DepartmentDAO();
        }

        public static ContractDAO CreateContractDAO()
        {
            return new ContractDAO();
        }

    }
}
