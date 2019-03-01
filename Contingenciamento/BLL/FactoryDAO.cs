using Contingenciamento.DAO;

namespace Contingenciamento.BLL
{
    public class FactoryDAO
    {
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

        public static EmployeeHistoryDAO CreateEmployeeHistoryDAO()
        {
            return new EmployeeHistoryDAO();
        }
    }
}
