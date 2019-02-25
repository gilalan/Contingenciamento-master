using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class MonetaryFundDAO //: IDataAccessObject<MonetaryFund>
    {
        private DAOHelper dal = new DAOHelper();

        public MonetaryFund Get<K>(K id)
        {
            MonetaryFund monetaryFund = new MonetaryFund();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT * FROM monetary_funds WHERE id = " + id + " ORDER BY id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    monetaryFund.Id = Convert.ToInt32(reader["id"]);
                    monetaryFund.Name = reader["name"].ToString();
                    monetaryFund.Primal = Convert.ToBoolean(reader["primal"]);
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
            return monetaryFund;
        }

        public List<MonetaryFund> GetTop()
        {
            List<MonetaryFund> monetaryFunds = new List<MonetaryFund>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT * FROM monetary_funds ORDER BY id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    MonetaryFund monetaryFund = new MonetaryFund();
                    monetaryFund.Id = Convert.ToInt32(reader["id"]);
                    monetaryFund.Name = reader["name"].ToString();
                    monetaryFund.Primal = Convert.ToBoolean(reader["primal"]);

                    monetaryFunds.Add(monetaryFund);
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
            return monetaryFunds;
        }

        public int Insert(MonetaryFund monetaryFund)
        {
            //int rowsAffected = -1;
            object obj = null;
            int idReturned = -1;
            try
            {
                string cmdInsert = "INSERT INTO monetary_funds(name, primal) VALUES (:name, :primal) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("primal", NpgsqlTypes.NpgsqlDbType.Boolean));

                cmd.Parameters[0].Value = monetaryFund.Name;
                cmd.Parameters[1].Value = monetaryFund.Primal;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null)
                {
                    idReturned = (int)obj;
                }
            }
            finally
            {
                this.dal.CloseConection();
            }

            return idReturned;
        }

        public void BulkInsert(HashSet<MonetaryFund> monetaryFundList)
        {
            try
            {
                string cmdInsert = "INSERT INTO monetary_funds(name, primal) VALUES (:name, :primal)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("primal", NpgsqlTypes.NpgsqlDbType.Boolean));

                dal.OpenConnection();
                foreach (var monetaryFund in monetaryFundList)
                {
                    cmd.Parameters[0].Value = monetaryFund.Name;
                    cmd.Parameters[1].Value = monetaryFund.Primal;
                    dal.ExecuteNonQuery(cmd);
                }

            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, MonetaryFund monetaryFund)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE monetary_funds set \"name\" = :name, \"primal\" = :primal"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("primal", NpgsqlTypes.NpgsqlDbType.Boolean));

                cmd.Parameters[0].Value = monetaryFund.Name;
                cmd.Parameters[1].Value = monetaryFund.Primal;

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
                string cmdDeletar = String.Format("Delete From monetary_funds Where id = '{0}'", id);

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
