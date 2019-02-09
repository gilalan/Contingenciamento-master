using System;
using System.Collections.Generic;
using Npgsql;
using Contingenciamento.Entidades;

namespace Contingenciamento.DAO 
{
    public class ClienteDAO : IAcessoDadosObject<Cliente>
    {
        private DAOHelper dal = new DAOHelper();

        public Cliente Get<K>(K id)
        {
            Cliente cliente = new Cliente();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSeleciona = "Select * from cliente Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    cliente.Id = Convert.ToInt32(reader["id"]);
                    cliente.Name = reader["nome"].ToString();
                    cliente.Cnpj = reader["cnpj"].ToString();
                    cliente.CodigoSOLL = reader["id_soll"].ToString();
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
            return cliente;
        }

        public Cliente GetBySollId<K>(K idSoll)
        {
            Cliente cliente = new Cliente();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSeleciona = "Select * from cliente Where id_soll = '"+idSoll+"'";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    cliente.Id = Convert.ToInt32(reader["id"]);
                    cliente.Name = reader["nome"].ToString();
                    cliente.Cnpj = reader["cnpj"].ToString();
                    cliente.CodigoSOLL = reader["id_soll"].ToString();
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
            return cliente;
        }

        public List<Cliente> GetTop()
        {
            List<Cliente> clientes = new List<Cliente>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "select * from cliente";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = Convert.ToInt32(reader["id"]);
                    cliente.CodigoSOLL = reader["id_soll"].ToString();
                    cliente.Name = reader["nome"].ToString();
                    cliente.Cnpj = reader["cnpj"].ToString();
                    clientes.Add(cliente);
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
            return clientes;
        }

        public void Insert(Cliente cliente)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = String.Format("Insert Into cliente(nome,id_soll,cnpj) " +
                    "values('{0}','{1}','{2}')",
                    cliente.Name, cliente.CodigoSOLL, cliente.Cnpj);
                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdInserir);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<Cliente> clienteList)
        {
            string cmdInserir;
            dal.OpenConnection();
            foreach (var cliente in clienteList)
            {
                cmdInserir = String.Format("Insert Into cliente(nome,id_soll,cnpj) " +
                    "values('{0}','{1}','{2}')",
                    cliente.Name, cliente.CodigoSOLL, cliente.Cnpj);
                dal.ExecuteNonQuery(cmdInserir);
            }
        }

        public void Update<K>(K id, Cliente objCliente)
        {
            int rowsAffected = -1;
            try
            {               
                NpgsqlCommand cmd = new NpgsqlCommand("Update cliente set \"nome\" = :name, \"id_soll\" = :idSoll, \"cnpj\" = :cnpj," +
                " where \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idSoll", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cnpj", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[0].Value = objCliente.Name;
                cmd.Parameters[1].Value = objCliente.CodigoSOLL;
                cmd.Parameters[2].Value = objCliente.Cnpj;

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
                string cmdDeletar = String.Format("Delete From cliente Where id = '{0}'", id);

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
