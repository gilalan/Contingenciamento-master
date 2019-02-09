using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class VerbaDAO : IAcessoDadosObject<Verba>
    {
        private DAOHelper dal = new DAOHelper();

        public Verba Get<K>(K id)
        {
            Verba verba = new Verba();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSeleciona = "Select * from verbas Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    verba.Id = Convert.ToInt32(reader["id"]);
                    verba.Nome = reader["nome"].ToString();
                    verba.Codigo = Convert.ToInt32(reader["codigo"]);
                    verba.Primaria = Convert.ToBoolean(reader["primaria"]);
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
            return verba;
        }

        public List<Verba> GetTop()
        {
            List<Verba> verbas = new List<Verba>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "select * from verbas";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Verba verba = new Verba();
                    verba.Id = Convert.ToInt32(reader["id"]);
                    verba.Nome = reader["nome"].ToString();
                    verba.Codigo = Convert.ToInt32(reader["codigo"]);
                    verba.Primaria = Convert.ToBoolean(reader["primaria"].ToString());
                    verbas.Add(verba);
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
            return verbas;
        }

        public void Insert(Verba verba)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = "INSERT INTO verbas(nome, codigo, primaria) VALUES (:nome, :codigo, :primaria)";                    

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("nome", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("codigo", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("primaria", NpgsqlTypes.NpgsqlDbType.Boolean));
                
                cmd.Parameters[0].Value = verba.Nome;
                cmd.Parameters[1].Value = verba.Codigo;
                cmd.Parameters[2].Value = verba.Primaria;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<Verba> verbaList)
        {
            try
            {
                string cmdInserir = "INSERT INTO verbas(nome, codigo, primaria) VALUES (:nome, :codigo, :primaria)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("nome", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("codigo", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("primaria", NpgsqlTypes.NpgsqlDbType.Boolean));

                dal.OpenConnection();
                foreach (var verba in verbaList)
                {
                    cmd.Parameters[0].Value = verba.Nome;
                    cmd.Parameters[1].Value = verba.Codigo;
                    cmd.Parameters[2].Value = verba.Primaria;
                    dal.ExecuteNonQuery(cmd);
                }

            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, Verba verba)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE verbas set \"nome\" = :nome, \"codigo\" = :codigo, \"primaria\" = :primaria,"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("nome", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("codigo", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("primaria", NpgsqlTypes.NpgsqlDbType.Boolean));

                cmd.Parameters[0].Value = verba.Nome;
                cmd.Parameters[1].Value = verba.Codigo;
                cmd.Parameters[2].Value = verba.Primaria;

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
                string cmdDeletar = String.Format("Delete From verbas Where id = '{0}'", id);

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
