using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContratoDAO : IAcessoDadosObject<Contrato>
    {
        private DAOHelper dal = new DAOHelper();

        public Contrato Get<K>(K id)
        {

            string cmdSeleciona = "SELECT cont.id as cont_id, cont.nome as cont_name, "
                + "cont.codigo as cont_codigo, cont.id_cliente as cont_id_cliente, "
                + "cont.inicio as cont_inicio, cont.termino as cont_termino, "
                + "cli.nome as cli_nome, cli.id_soll as cli_id_soll "
                + "FROM contrato cont INNER JOIN cliente cli ON "
                + "cont.id_cliente = cli.id WHERE cont.codigo = " + id;

            Contrato contrato = new Contrato();
            NpgsqlDataReader reader = null;
            try
            {
                //string cmdSeleciona = "SELECT * from contrato Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    contrato.Id = Convert.ToInt32(reader["cont_id"]);
                    contrato.Name = reader["cont_name"].ToString();
                    contrato.Inicio = Convert.ToDateTime(reader["cont_inicio"]);
                    contrato.Termino = Convert.ToDateTime(reader["cont_termino"]);
                    contrato.CodigoSOLL = reader["cont_codigo"].ToString();
                    contrato.Cliente = new Cliente(Convert.ToInt32(reader["cont_id_cliente"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());
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
            return contrato;
        }

        public Contrato GetBySollId<T1, T2>(T1 clientId, T2 sollId)
        {

            string cmdSeleciona = "SELECT cont.id as cont_id, cont.nome as cont_name, "
                + "cont.codigo as cont_codigo, cont.id_cliente as cont_id_cliente, "
                + "cont.inicio as cont_inicio, cont.termino as cont_termino, "
                + "cli.nome as cli_nome, cli.id_soll as cli_id_soll "
                + "FROM contrato cont INNER JOIN cliente cli ON "
                + "cont.id_cliente = cli.id WHERE cont.id_cliente = :idCliente AND cont.codigo = :sollId";

            Contrato contrato = new Contrato();
            NpgsqlCommand cmd = new NpgsqlCommand(cmdSeleciona);

            cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters.Add(new NpgsqlParameter("sollId", NpgsqlTypes.NpgsqlDbType.Text));
            
            cmd.Parameters[0].Value = clientId;
            cmd.Parameters[1].Value = sollId;
            
            NpgsqlDataReader reader = null;
            try
            {
                //string cmdSeleciona = "SELECT * from contrato Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                if (reader.Read())
                {
                    contrato.Id = Convert.ToInt32(reader["cont_id"]);
                    contrato.Name = reader["cont_name"].ToString();
                    contrato.Inicio = Convert.ToDateTime(reader["cont_inicio"]);
                    contrato.Termino = Convert.ToDateTime(reader["cont_termino"]);
                    contrato.CodigoSOLL = reader["cont_codigo"].ToString();
                    contrato.Cliente = new Cliente(Convert.ToInt32(reader["cont_id_cliente"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());
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
            return contrato;
        }

        public List<Contrato> GetTop()
        {
            string cmdAll = "SELECT cont.id as cont_id, cont.nome as cont_name, "
                + "cont.codigo as cont_codigo, cont.id_cliente as cont_id_cliente, "
                + "cont.inicio as cont_inicio, cont.termino as cont_termino, "
                + "cli.nome as cli_nome, cli.id_soll as cli_id_soll "
                + "FROM contrato cont INNER JOIN cliente cli ON "
                + "cont.id_cliente = cli.id";

            List<Contrato> contratos = new List<Contrato>();

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from contrato";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdAll);

                while (reader.Read())
                {
                    Contrato contrato = new Contrato();
                    contrato.Id = Convert.ToInt32(reader["cont_id"]);
                    contrato.Name = reader["cont_name"].ToString();
                    contrato.Inicio = Convert.ToDateTime(reader["cont_inicio"]);
                    contrato.Termino = Convert.ToDateTime(reader["cont_termino"]);
                    contrato.CodigoSOLL = reader["cont_codigo"].ToString();
                    contrato.Cliente = new Cliente(Convert.ToInt32(reader["cont_id_cliente"]),
                        reader["cli_nome"].ToString(), reader["cli_id_soll"].ToString());

                    contratos.Add(contrato);
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
            return contratos;
        }

        public void Insert(Contrato contrato)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = String.Format("Insert into contrato(nome,codigo,id_soll,id_cliente,inicio,termino) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}')",
                    contrato.Name, contrato.CodigoSOLL, contrato.CodigoSOLL, contrato.Cliente.Id, contrato.Inicio, contrato.Termino);
                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdInserir);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<Contrato> contratoList)
        {
            string cmdInserir;
            dal.OpenConnection();
            foreach (var contrato in contratoList)
            {
                cmdInserir = String.Format("Insert into contrato(nome,codigo,id_soll,id_cliente,inicio,termino) " +
                    "values('{0}','{1}','{2}','{3}','{4}','{5}')",
                    contrato.Name, contrato.CodigoSOLL, contrato.CodigoSOLL, contrato.Cliente.Id, contrato.Inicio, contrato.Termino);
                dal.ExecuteNonQuery(cmdInserir);
            }
        }

        public void Update<K>(K id, Contrato objContrato)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Update contrato set \"nome\" = :name, \"id_soll\" = :idSoll, " +
                    "\"codigo\" = :codigo, \"id_cliente\" = :idCliente, \"inicio\" = :inicio, \"termino\" = :termino " +
                    "where \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idSoll", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("codigo", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("inicio", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("termino", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters[0].Value = objContrato.Name;
                cmd.Parameters[1].Value = objContrato.CodigoSOLL;
                cmd.Parameters[2].Value = objContrato.CodigoSOLL;
                cmd.Parameters[3].Value = objContrato.Cliente.Id;
                cmd.Parameters[4].Value = objContrato.Inicio;
                cmd.Parameters[5].Value = objContrato.Termino;

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
                string cmdDeletar = String.Format("Delete From contrato Where id = '{0}'", id);

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
