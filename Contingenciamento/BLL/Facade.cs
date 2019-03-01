using Contingenciamento.DAO;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        private EmployeeDAO _employeeDAO;
        private BankDAO _bankDAO;
        private RoleDAO _roleDAO;
        private DepartmentDAO _departmentDAO;
        private ContingencyFundDAO _contingencyFundDAO;
        private MonetaryFundDAO _monetaryFundDAO;
        private ExtraFundDAO _extraFundDAO;
        private ContractDAO _contractDAO;
        private EmployeeHistoryDAO _employeeHistoryDAO;

        public Facade()
        {
            _contingencyFundDAO = FactoryDAO.CreateContigencyFundDAO();
            _monetaryFundDAO = FactoryDAO.CreateMonetaryFundDAO();
            _extraFundDAO = FactoryDAO.CreateExtraFundDAO();
            _employeeDAO = FactoryDAO.CreateEmployeeDAO();
            _roleDAO = FactoryDAO.CreateRoleDAO();
            _bankDAO = FactoryDAO.CreateBankDAO();
            _departmentDAO = FactoryDAO.CreateDepartmentDAO();
            _contractDAO = FactoryDAO.CreateContractDAO();
            _employeeHistoryDAO = FactoryDAO.CreateEmployeeHistoryDAO();
        }
    }
}
