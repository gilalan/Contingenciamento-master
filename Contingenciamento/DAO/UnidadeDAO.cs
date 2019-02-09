using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class UnidadeDAO : IAcessoDadosObject<Unidade>
    {
        private DAOHelper dal = new DAOHelper();

        public Unidade Get<K>(K id)
        {
            string cmdSeleciona = "SELECT und.id as und_id, und.nome as und_name, "
                + "und.id_soll as und_id_soll, cont.nome as cont_name, "
                + "cont.id_soll as cont_id_soll, cli.nome as cli_name, "
                + "cli.id_soll as cli_id_soll "
                + "FROM (unidades und INNER JOIN contrato cont ON "
                + "(und.id_contrato = cont.id)) "
                + "INNER JOIN cliente cli ON (cont.id_cliente = cli.id) "
                + "WHERE und.id = "+id+" ORDER BY cli.id_soll, cont.id_soll, und.id_soll";
            Unidade unidade = new Unidade();
            NpgsqlDataReader reader = null;
            try
            {
                //string cmdSeleciona = "Select * from unidades Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    Cliente cli= new Cliente(reader["cli_name"].ToString(), reader["cli_id_soll"].ToString());
                    Contrato contr = new Contrato(reader["cont_name"].ToString(), reader["cont_id_soll"].ToString(), cli);
                    unidade.Id = Convert.ToInt32(reader["und_id"]);
                    unidade.Name = reader["und_name"].ToString();
                    unidade.CodigoSOLL = reader["und_id_soll"].ToString();
                    unidade.Contrato = contr;
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
            return unidade;
        }

        public Unidade GetByKey<T1, T2>(T1 idContrato, T2 id_soll)
        {
            string cmdSeleciona = "SELECT und.id as und_id, und.nome as und_name, "
                + "und.id_soll as und_id_soll, cont.id as cont_id, cont.nome as cont_name, "
                + "cont.id_soll as cont_id_soll, cont.inicio as cont_inicio, cont.termino as cont_termino, "
                + "cli.id as cli_id, cli.nome as cli_name, cli.id_soll as cli_id_soll "
                + "FROM (unidades und INNER JOIN contrato cont ON "
                + "(und.id_contrato = cont.id)) "
                + "INNER JOIN cliente cli ON (cont.id_cliente = cli.id) "
                + "WHERE und.id_contrato = "+idContrato+" AND und.id_soll = '"+id_soll+"' " 
                + "ORDER BY cli.id_soll, cont.id_soll, und.id_soll";
            Unidade unidade = new Unidade();
            NpgsqlDataReader reader = null;
            try
            {
                //string cmdSeleciona = "Select * from unidades Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]), 
                        reader["cli_name"].ToString(), reader["cli_id_soll"].ToString());
                    Contrato contr = new Contrato(Convert.ToInt32(reader["cont_id"]), cli,  
                        reader["cont_name"].ToString(), reader["cont_id_soll"].ToString(),
                        Convert.ToDateTime(reader["cont_inicio"]), Convert.ToDateTime(reader["cont_termino"]));
                    unidade.Id = Convert.ToInt32(reader["und_id"]);
                    unidade.Name = reader["und_name"].ToString();
                    unidade.CodigoSOLL = reader["und_id_soll"].ToString();
                    unidade.Contrato = contr;
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
            return unidade;
        }

        public List<Unidade> GetTop()
        {
            List<Unidade> unidades = new List<Unidade>();
            string cmdAll = "SELECT und.id as und_id, und.nome as und_name, "
                + "und.id_soll as und_id_soll, cont.nome as cont_name, "
                + "cont.id_soll as cont_id_soll, cli.nome as cli_name, "
                + "cli.id_soll as cli_id_soll "
                + "FROM (unidades und INNER JOIN contrato cont ON "
                + "(und.id_contrato = cont.id)) "
                + "INNER JOIN cliente cli ON (cont.id_cliente = cli.id) "
                + "ORDER BY cli.id_soll, cont.id_soll, und.id_soll";

            NpgsqlDataReader reader = null;
            try
            {
                //string query = "select * from unidade";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdAll);

                while (reader.Read())
                {
                    Unidade unidade = new Unidade();
                    Cliente cli = new Cliente(reader["cli_name"].ToString(), reader["cli_id_soll"].ToString());
                    Contrato contr = new Contrato(reader["cont_name"].ToString(), reader["cont_id_soll"].ToString(), cli);
                    unidade.Id = Convert.ToInt32(reader["und_id"]);
                    unidade.Name = reader["und_name"].ToString();
                    unidade.CodigoSOLL = reader["und_id_soll"].ToString();
                    unidade.Contrato = contr;
                    unidades.Add(unidade);
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
            return unidades;
        }

        public void Insert(Unidade unidade)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = String.Format("Insert into unidades(nome,id_soll,id_contrato) " +
                    "values('{0}','{1}','{2}')",
                    unidade.Name, unidade.CodigoSOLL, unidade.Contrato.Id);
                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdInserir);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<Unidade> unidadeList)
        {
            string cmdInserir;
            dal.OpenConnection();
            foreach (var unidade in unidadeList)
            {
                cmdInserir = String.Format("Insert into unidades(nome,id_soll,id_contrato) " +
                    "values('{0}','{1}','{2}')",
                    unidade.Name, unidade.CodigoSOLL, unidade.Contrato.Id);
                dal.ExecuteNonQuery(cmdInserir);
            }
        }

        public void Update<K>(K id, Unidade objUnidade)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Update unidades set \"nome\" = :name, \"id_soll\" = :idSoll, \"id_contrato\" = :idContrato," +
                " where \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idSoll", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = objUnidade.Name;
                cmd.Parameters[1].Value = objUnidade.CodigoSOLL;
                cmd.Parameters[2].Value = objUnidade.Contrato.Id;

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
                string cmdDeletar = String.Format("DELETE From unidades Where id = '{0}'", id);

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
