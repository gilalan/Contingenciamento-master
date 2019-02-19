using Contingenciamento.DAO;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        private FuncionarioDAO _funcionarioDAO;
        private ClienteDAO _clienteDAO;
        private ContratoDAO _contratoDAO;
        private UnidadeDAO _unidadeDAO;
        private HistoricoFuncionarioDAO _historicoFuncionarioDAO;
        private VerbaDAO _verbaDAO;
        private ContratoAliquotaDAO _contratoAliquotaDAO;
        private EmployeeDAO _employeeDAO;
        private BankDAO _bankDAO;
        private RoleDAO _roleDAO;
        private ContingencyFundDAO _contingencyFundDAO;
        private MonetaryFundDAO _monetaryFundDAO;
        private ExtraFundDAO _extraFundDAO;

        public Facade()
        {
            _funcionarioDAO = FactoryDAO.CreateFuncionarioDAO();
            _clienteDAO = FactoryDAO.CreateClienteDAO();
            _contratoDAO = FactoryDAO.CreateContratoDAO();
            _unidadeDAO = FactoryDAO.CreateUnidadeDAO();
            _historicoFuncionarioDAO = FactoryDAO.CreateHistoricoFuncionarioDAO();
            _verbaDAO = FactoryDAO.CreateVerbaDAO();
            _contratoAliquotaDAO = FactoryDAO.CreateContratoAliquotaDAO();
            _contingencyFundDAO = FactoryDAO.CreateContigencyFundDAO();
            _monetaryFundDAO = FactoryDAO.CreateMonetaryFundDAO();
            _extraFundDAO = FactoryDAO.CreateExtraFundDAO();
            _employeeDAO = FactoryDAO.CreateEmployeeDAO();
            _roleDAO = FactoryDAO.CreateRoleDAO();
            _bankDAO = FactoryDAO.CreateBankDAO();
        }
    }
}
