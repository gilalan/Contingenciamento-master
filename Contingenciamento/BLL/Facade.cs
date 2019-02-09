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

        public Facade()
        {
            _funcionarioDAO = FactoryDAO.CreateFuncionarioDAO();
            _clienteDAO = FactoryDAO.CreateClienteDAO();
            _contratoDAO = FactoryDAO.CreateContratoDAO();
            _unidadeDAO = FactoryDAO.CreateUnidadeDAO();
            _historicoFuncionarioDAO = FactoryDAO.CreateHistoricoFuncionarioDAO();
            _verbaDAO = FactoryDAO.CreateVerbaDAO();
            _contratoAliquotaDAO = FactoryDAO.CreateContratoAliquotaDAO();
        }
    }
}
