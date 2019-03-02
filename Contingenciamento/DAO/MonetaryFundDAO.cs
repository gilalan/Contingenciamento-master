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
            HashSet<MonetaryFund> hashMonetaryFunds = new HashSet<MonetaryFund>(new MonetaryFundComparer());
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, ef.name as ef_name, ef.id as ef_id " +
                    "FROM monetary_funds mf LEFT JOIN " +
                    "extra_funds ef ON mf.id = ef.monetary_funds_id ORDER BY mf.id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                ExtraFund extraFund = new ExtraFund();
                while (reader.Read())
                {
                    extraFund = null;
                    monetaryFund = new MonetaryFund();
                    monetaryFund.Id = Convert.ToInt64(reader["mf_id"]);
                    monetaryFund.Name = reader["mf_name"].ToString();
                    monetaryFund.Primal = Convert.ToBoolean(reader["mf_primal"]);

                    if (reader["ef_id"] != DBNull.Value && reader["ef_name"] != DBNull.Value)
                    {
                        extraFund = new ExtraFund();
                        extraFund.Id = Convert.ToInt64(reader["ef_id"]);
                        extraFund.Name = reader["ef_name"].ToString();
                        monetaryFund.ExtraFunds.Add(extraFund);
                    }

                    if (!hashMonetaryFunds.Add(monetaryFund))
                    {
                        foreach (var item in hashMonetaryFunds)
                        {
                            if (item.Id == monetaryFund.Id)
                            {
                                if (extraFund != null)
                                    item.ExtraFunds.Add(extraFund);
                                break;
                            }
                        }
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
            return monetaryFund;
        }

        public List<MonetaryFund> GetTop()
        {
            HashSet<MonetaryFund> hashMonetaryFunds = new HashSet<MonetaryFund>(new MonetaryFundComparer());
            //List<MonetaryFund> monetaryFunds = hashMonetaryFunds.ToList();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, ef.name as ef_name, ef.id as ef_id " +
                    "FROM monetary_funds mf LEFT JOIN " +
                    "extra_funds ef ON mf.id = ef.monetary_funds_id ORDER BY mf.id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);
                MonetaryFund monetaryFund;
                ExtraFund extraFund;
                while (reader.Read())
                {
                    extraFund = null;
                    monetaryFund = new MonetaryFund();
                    monetaryFund.Id = Convert.ToInt64(reader["mf_id"]);
                    monetaryFund.Name = reader["mf_name"].ToString();
                    monetaryFund.Primal = Convert.ToBoolean(reader["mf_primal"]);
                    
                    if (reader["ef_id"] != DBNull.Value && reader["ef_name"] != DBNull.Value)
                    {
                        extraFund = new ExtraFund();
                        extraFund.Id = Convert.ToInt64(reader["ef_id"]);
                        extraFund.Name = reader["ef_name"].ToString();
                        monetaryFund.ExtraFunds.Add(extraFund);
                    }

                    if (!hashMonetaryFunds.Add(monetaryFund))
                    {
                        foreach (var item in hashMonetaryFunds)
                        {
                            if (item.Id == monetaryFund.Id)
                            {
                                if (extraFund != null)
                                    item.ExtraFunds.Add(extraFund);
                                break;
                            }
                        }
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
            return new List<MonetaryFund>(hashMonetaryFunds);
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
