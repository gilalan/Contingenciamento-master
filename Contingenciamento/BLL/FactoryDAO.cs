using Contingenciamento.DAO;

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

    }
}
