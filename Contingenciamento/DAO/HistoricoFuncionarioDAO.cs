using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class HistoricoFuncionarioDAO : IAcessoDadosHFObject<HistoricoFuncionario>
    {
        private DAOHelper dal = new DAOHelper();

        public HistoricoFuncionario Get<K>(K id)
        {
            string cmdSeleciona = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "WHERE hist_func.id_funcionario = "+id+" ORDER BY hist_func.id DESC";

            HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
            NpgsqlDataReader reader = null;
            try
            {
                //string cmdSeleciona = "Select * from historicoFuncionario Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = new Contrato(reader["cont_nome"].ToString(), reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if(reader["und_id"] != null)
                    {
                        unidade = new Unidade(reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }
                        
                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Cliente = cli;
                    historicoFuncionario.Contrato = contr;
                    if (unidade != null)
                    {
                        historicoFuncionario.Unidade = unidade;
                    }
                }
                reader.Close();
            }

            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionario;
        }

        
        public List<HistoricoFuncionario> GetHistoricoByDatas(DateTime inicio, DateTime fim)
        {
            string cmdSeleciona = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "WHERE hist_func.data BETWEEN :inicioDate "
                + "AND :fimDate ORDER BY hist_func.id_contrato, hist_func.data ASC";

            List<HistoricoFuncionario> historicoFuncionarios = new List<HistoricoFuncionario>();
            NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona);

            cmd.Parameters.Add(new NpgsqlParameter("inicioDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters.Add(new NpgsqlParameter("fimDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters[0].Value = inicio;
            cmd.Parameters[1].Value = fim;

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from historicoFuncionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = null;
                    if (!(reader["cont_id"] is DBNull) && !(reader["cont_nome"] is DBNull) && !(reader["cont_id_soll"] is DBNull))
                        contr = new Contrato(Convert.ToInt32(reader["cont_id"]), reader["cont_nome"].ToString(),
                            reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if (contr != null && !(reader["und_id"] is DBNull))
                    {
                        unidade = new Unidade(Convert.ToInt32(reader["und_id"]),
                            reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }

                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Cliente = cli;
                    historicoFuncionario.Contrato = contr;
                    historicoFuncionario.Funcionario = func;
                    if (unidade != null)
                    {
                        historicoFuncionario.Unidade = unidade;
                    }
                    historicoFuncionarios.Add(historicoFuncionario);
                }
                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionarios;
        }

        public List<HistoricoFuncionario> GetHistoricoByFuncAndDatas(int funcId, DateTime inicio, DateTime fim)
        {
            string cmdSeleciona = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "WHERE hist_func.id_funcionario = :funcID AND (hist_func.data BETWEEN :inicioDate "
                + "AND :fimDate) ORDER BY hist_func.id_cliente, hist_func.id_contrato, hist_func.data ASC";

            List<HistoricoFuncionario> historicoFuncionarios = new List<HistoricoFuncionario>();
            NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona);

            cmd.Parameters.Add(new NpgsqlParameter("funcID", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters.Add(new NpgsqlParameter("inicioDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters.Add(new NpgsqlParameter("fimDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters[0].Value = funcId;
            cmd.Parameters[1].Value = inicio;
            cmd.Parameters[2].Value = fim;

            NpgsqlDataReader reader = null;
            try
            {
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = null;
                    if (!(reader["cont_id"] is DBNull) && !(reader["cont_nome"] is DBNull) && !(reader["cont_id_soll"] is DBNull))
                        contr = new Contrato(Convert.ToInt32(reader["cont_id"]), reader["cont_nome"].ToString(), 
                            reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if (contr != null && !(reader["und_id"] is DBNull))
                    {
                        unidade = new Unidade(Convert.ToInt32(reader["und_id"]), 
                            reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }
                    
                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Funcionario = func;
                    historicoFuncionario.Cliente = cli;

                    if (contr != null)
                        historicoFuncionario.Contrato = contr;

                    if (unidade != null)
                        historicoFuncionario.Unidade = unidade;

                    historicoFuncionarios.Add(historicoFuncionario);
                }
                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionarios;
        }

        public List<HistoricoFuncionario> GetHistoricoByClienteAndDatas(int clienteId, DateTime inicio, DateTime fim)
        {
            string cmdSeleciona = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "WHERE hist_func.id_cliente = :clientID AND (hist_func.data BETWEEN :inicioDate "
                + "AND :fimDate) ORDER BY hist_func.id_contrato, hist_func.data ASC";

            List<HistoricoFuncionario> historicoFuncionarios = new List<HistoricoFuncionario>();
            NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona);

            cmd.Parameters.Add(new NpgsqlParameter("clientID", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters.Add(new NpgsqlParameter("inicioDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters.Add(new NpgsqlParameter("fimDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters[0].Value = clienteId;
            cmd.Parameters[1].Value = inicio;
            cmd.Parameters[2].Value = fim;

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from historicoFuncionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = null;
                    if (!(reader["cont_id"] is DBNull) && !(reader["cont_nome"] is DBNull) && !(reader["cont_id_soll"] is DBNull))
                        contr = new Contrato(Convert.ToInt32(reader["cont_id"]), reader["cont_nome"].ToString(),
                            reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if (contr != null && !(reader["und_id"] is DBNull))
                    {
                        unidade = new Unidade(Convert.ToInt32(reader["und_id"]),
                            reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }

                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Cliente = cli;
                    historicoFuncionario.Contrato = contr;
                    historicoFuncionario.Funcionario = func;
                    if (unidade != null)
                    {
                        historicoFuncionario.Unidade = unidade;
                    }
                    historicoFuncionarios.Add(historicoFuncionario);
                }
                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionarios;
        }

        public List<HistoricoFuncionario> GetHistoricoByContratoAndDatas(int clienteId, int contratoId, DateTime inicio, DateTime fim)
        {
            string cmdSeleciona = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "WHERE hist_func.id_cliente = :clientID AND hist_func.id_contrato = :contratoID AND (hist_func.data BETWEEN :inicioDate "
                + "AND :fimDate) ORDER BY hist_func.id_contrato, hist_func.data ASC";

            List<HistoricoFuncionario> historicoFuncionarios = new List<HistoricoFuncionario>();
            NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona);

            cmd.Parameters.Add(new NpgsqlParameter("clientID", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters.Add(new NpgsqlParameter("contratoID", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters.Add(new NpgsqlParameter("inicioDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters.Add(new NpgsqlParameter("fimDate", NpgsqlTypes.NpgsqlDbType.Date));
            cmd.Parameters[0].Value = clienteId;
            cmd.Parameters[1].Value = contratoId;
            cmd.Parameters[2].Value = inicio;
            cmd.Parameters[3].Value = fim;

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from historicoFuncionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = null;
                    if (!(reader["cont_id"] is DBNull) && !(reader["cont_nome"] is DBNull) && !(reader["cont_id_soll"] is DBNull))
                        contr = new Contrato(Convert.ToInt32(reader["cont_id"]), reader["cont_nome"].ToString(),
                            reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if (contr != null && !(reader["und_id"] is DBNull))
                    {
                        unidade = new Unidade(Convert.ToInt32(reader["und_id"]),
                            reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }

                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Cliente = cli;
                    historicoFuncionario.Contrato = contr;
                    historicoFuncionario.Funcionario = func;
                    if (unidade != null)
                    {
                        historicoFuncionario.Unidade = unidade;
                    }
                    historicoFuncionarios.Add(historicoFuncionario);
                }
                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionarios;
        }

        public List<HistoricoFuncionario> GetTop()
        {
            string cmdAll = "SELECT hist_func.id as hist_func_id, func.nome as func_name, "
                + "func.matricula as func_matricula, func.data_admissao as func_data_admissao, "
                + "func.data_rescisao as func_data_rescisao, hist_func.data as hist_func_data, "
                + "hist_func.salario as hist_func_salario, hist_func.codigo_depto as hist_func_dpto, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.id as cont_id, cont.nome as cont_nome, cont.id_soll as cont_id_soll, "
                + "und.id as und_id, und.nome as und_nome, und.id_soll as und_id_soll "
                + "FROM (historico_funcionario hist_func INNER JOIN funcionario func ON "
                + "(hist_func.id_funcionario = func.id)) "
                + "INNER JOIN cliente cli ON (hist_func.id_cliente = cli.id) "
                + "LEFT JOIN contrato cont ON (hist_func.id_contrato = cont.id) "
                + "LEFT JOIN unidades und ON (hist_func.id_unidade = und.id) "
                + "ORDER BY hist_func.id ASC";

            List<HistoricoFuncionario> historicoFuncionarios = new List<HistoricoFuncionario>();

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from historicoFuncionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdAll);

                while (reader.Read())
                {
                    HistoricoFuncionario historicoFuncionario = new HistoricoFuncionario();
                    Funcionario func = new Funcionario(reader["func_matricula"].ToString(), reader["func_name"].ToString(),
                         Convert.ToDateTime(reader["func_data_admissao"]), Convert.ToDateTime(reader["func_data_rescisao"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    Contrato contr = new Contrato(reader["cont_nome"].ToString(), reader["cont_id_soll"].ToString(), cli);

                    Unidade unidade = null;
                    if (reader["und_id"] != null)
                    {
                        unidade = new Unidade(reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                        unidade.Contrato = contr;
                    }

                    historicoFuncionario.Id = Convert.ToInt32(reader["hist_func_id"]);
                    historicoFuncionario.Data = Convert.ToDateTime(reader["hist_func_data"]);
                    historicoFuncionario.SalarioBase = Convert.ToDouble(reader["hist_func_salario"]);
                    historicoFuncionario.CodigoDeptoSOLL = reader["hist_func_dpto"].ToString();
                    historicoFuncionario.Cliente = cli;
                    historicoFuncionario.Contrato = contr;
                    historicoFuncionario.Funcionario = func;
                    if (unidade != null)
                    {
                        historicoFuncionario.Unidade = unidade;
                    }
                    historicoFuncionarios.Add(historicoFuncionario);
                }
                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return historicoFuncionarios;
        }

        public void Insert(HistoricoFuncionario objHistoricoFuncionario)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = "INSERT INTO historico_funcionario(id_funcionario, data, salario, "
                    + "liquido, codigo_depto, id_cliente, id_contrato, id_unidade, em_ferias, nome_depto, inicio_aquisicao, "
                    + "fim_aquisicao, adic_periculosidade, adic_insalubridade, decimo_salario, decimo_salario_prop, "
                    + "valor_ferias, ferias_proporcional, multa_rescisoria, total_proventos) VALUES "
                    + "(:idFuncionario, :data, :salario, :liquido, :codigoDepto, :idCliente, :idContrato, :idUnidade, :emFerias, "
                    + ":nomeDepto, :inicioAquisicao, :fimAquisicao, :adicPericulosidade, :adicInsalubridade, :decimoSalario, :decimoSalarioProp, "
                    + ":valorFerias, :feriasProporcional, :multaRescisoria, :totalProventos)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("idFuncionario", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("data", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("salario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("liquido", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("codigoDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idUnidade", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("emFerias", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("nomeDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("inicioAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("fimAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("adicPericulosidade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("adicInsalubridade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalarioProp", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("valorFerias", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("feriasProporcional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("multaRescisoria", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("totalProventos", NpgsqlTypes.NpgsqlDbType.Double));

                int index = 0;

                cmd.Parameters[index].Value = objHistoricoFuncionario.Funcionario.Id;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.Data;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.SalarioBase;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.SalarioLiquido;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.CodigoDeptoSOLL;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.Cliente.Id;

                if (objHistoricoFuncionario.Contrato.Cliente == null)
                    cmd.Parameters[++index].Value = DBNull.Value;
                else
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.Contrato.Id;

                if (objHistoricoFuncionario.Unidade.Contrato == null)
                    cmd.Parameters[++index].Value = DBNull.Value;
                else
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.Unidade.Id;

                cmd.Parameters[++index].Value = objHistoricoFuncionario.EmFerias;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.NomeDeptoSOLL;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.InicioAquisicaoFerias;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.FimAquisicaoFerias;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.AdicPericulosidade;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.AdicInsalubridade;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.DecimoSalario;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.DecimoSalarioProporcional;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.ValorFerias;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.FeriasProporcional;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.MultaRescisoria;
                cmd.Parameters[++index].Value = objHistoricoFuncionario.TotalProventos;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(List<HistoricoFuncionario> historicoFuncionarioList)
        {
            try
            {
                string cmdInserir = "INSERT INTO historico_funcionario(id_funcionario, data, salario, "
                    + "liquido, codigo_depto, id_cliente, id_contrato, id_unidade, em_ferias, nome_depto, inicio_aquisicao, "
                    + "fim_aquisicao, adic_periculosidade, adic_insalubridade, decimo_salario, decimo_salario_prop, "
                    + "valor_ferias, ferias_proporcional, multa_rescisoria, total_proventos) VALUES "
                    + "(:idFuncionario, :data, :salario, :liquido, :codigoDepto, :idCliente, :idContrato, :idUnidade, :emFerias, "
                    + ":nomeDepto, :inicioAquisicao, :fimAquisicao, :adicPericulosidade, :adicInsalubridade, :decimoSalario, :decimoSalarioProp, "
                    + ":valorFerias, :feriasProporcional, :multaRescisoria, :totalProventos)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("idFuncionario", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("data", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("salario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("liquido", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("codigoDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idUnidade", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("emFerias", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("nomeDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("inicioAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("fimAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("adicPericulosidade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("adicInsalubridade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalarioProp", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("valorFerias", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("feriasProporcional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("multaRescisoria", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("totalProventos", NpgsqlTypes.NpgsqlDbType.Double));

                dal.OpenConnection();
                foreach (var objHistoricoFuncionario in historicoFuncionarioList)
                {
                    int index = 0;
                    
                    cmd.Parameters[index].Value = objHistoricoFuncionario.Funcionario.Id;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.Data;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.SalarioBase;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.SalarioLiquido;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.CodigoDeptoSOLL;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.Cliente.Id;

                    if (objHistoricoFuncionario.Contrato.Cliente == null)
                        cmd.Parameters[++index].Value = DBNull.Value;
                    else
                        cmd.Parameters[++index].Value = objHistoricoFuncionario.Contrato.Id;

                    if (objHistoricoFuncionario.Unidade.Contrato == null)
                        cmd.Parameters[++index].Value = DBNull.Value;
                    else
                        cmd.Parameters[++index].Value = objHistoricoFuncionario.Unidade.Id;

                    cmd.Parameters[++index].Value = objHistoricoFuncionario.EmFerias;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.NomeDeptoSOLL;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.InicioAquisicaoFerias;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.FimAquisicaoFerias;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.AdicPericulosidade;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.AdicInsalubridade;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.DecimoSalario;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.DecimoSalarioProporcional;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.ValorFerias;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.FeriasProporcional;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.MultaRescisoria;
                    cmd.Parameters[++index].Value = objHistoricoFuncionario.TotalProventos;
                    dal.ExecuteNonQuery(cmd);
                }
            }
            finally
            {
                this.dal.CloseConection();
            }
            
        }

        public void Update<K>(K id, HistoricoFuncionario objHistoricoFuncionario)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Update historico_funcionario set \"id_funcionario\" = :idFuncionario, " +
                    "\"data\" = :data, \"salario\" = :salario, \"liquido\" = :liquido, \"codigo_depto\" = :codigoDepto, \"id_cliente\" = :idCliente, " +
                    "\"id_contrato\" = :idContrato, \"id_unidade\" = :idUnidade, \"em_ferias\" = :emFerias, \"nome_depto\" = :nomeDepto, " +
                    "\"inicio_aquisicao\" = :inicioAquisicao, \"fim_aquisicao\" = :fimAquisicao, \"adic_periculosidade\" = :adicPericulosidade, " +
                    "\"adic_insalubridade\" = :adicInsalubridade, \"decimo_salario\" = :decimoSalario, \"decimo_salario_prop\" = :decimoSalarioProp, " +
                    "\"valor_ferias\" = :valorFerias, \"ferias_proporcional\" = :feriasProporcional, \"multa_rescisoria\" = :multaRescisoria, \"total_proventos\" = :totalProventos " +
                    "where \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("idFuncionario", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("data", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("salario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("liquido", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("codigoDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idUnidade", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("emFerias", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("nomeDepto", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("inicioAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("fimAquisicao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("adicPericulosidade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("adicInsalubridade", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalario", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("decimoSalarioProp", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("valorFerias", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("feriasProporcional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("multaRescisoria", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("totalProventos", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters[0].Value = objHistoricoFuncionario.Funcionario.Id;
                cmd.Parameters[1].Value = objHistoricoFuncionario.Data;
                cmd.Parameters[2].Value = objHistoricoFuncionario.SalarioBase;
                cmd.Parameters[3].Value = objHistoricoFuncionario.SalarioLiquido;
                cmd.Parameters[4].Value = objHistoricoFuncionario.CodigoDeptoSOLL;
                cmd.Parameters[5].Value = objHistoricoFuncionario.Unidade.Contrato.Cliente.Id;
                cmd.Parameters[6].Value = objHistoricoFuncionario.Unidade.Contrato.Id;
                cmd.Parameters[7].Value = objHistoricoFuncionario.Unidade.Id;
                cmd.Parameters[8].Value = objHistoricoFuncionario.EmFerias;
                cmd.Parameters[9].Value = objHistoricoFuncionario.NomeDeptoSOLL;
                cmd.Parameters[10].Value = objHistoricoFuncionario.InicioAquisicaoFerias;
                cmd.Parameters[11].Value = objHistoricoFuncionario.FimAquisicaoFerias;
                cmd.Parameters[12].Value = objHistoricoFuncionario.AdicPericulosidade;
                cmd.Parameters[13].Value = objHistoricoFuncionario.AdicInsalubridade;
                cmd.Parameters[14].Value = objHistoricoFuncionario.DecimoSalario;
                cmd.Parameters[15].Value = objHistoricoFuncionario.DecimoSalarioProporcional;
                cmd.Parameters[16].Value = objHistoricoFuncionario.ValorFerias;
                cmd.Parameters[17].Value = objHistoricoFuncionario.FeriasProporcional;
                cmd.Parameters[18].Value = objHistoricoFuncionario.MultaRescisoria;
                cmd.Parameters[19].Value = objHistoricoFuncionario.TotalProventos;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }

        }

        public void Delete<K>(K id)
        {
            int rowsAffected = -1;
            try
            {
                string cmdDeletar = String.Format("Delete From historico_funcionario Where id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdDeletar);

            }
            finally
            {
                this.dal.CloseConection();
            }
        }
    }
}
