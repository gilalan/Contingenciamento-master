using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ExtraFundDAO //: IDataAccessObject<ExtraFund>
    {
        private DAOHelper dal = new DAOHelper();

        public ExtraFund Get<K>(K id)
        {
            ExtraFund extraFund = new ExtraFund();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT ef.id as ef_id, ef.name as ef_name, mf.id as mf_id, mf.name as mf_name " +
                    "FROM (extra_funds ef INNER JOIN monetary_funds mf ON (ef.monetary_funds_id = mf.id)) " +
                    "WHERE ef.id = :passedId ORDER BY ef.id";
                //string cmdSelect = "SELECT * FROM extra_funds WHERE id = " + id;

                NpgsqlCommand cmd = new NpgsqlCommand(cmdSelect);
                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = id;

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                if (reader.Read())
                {
                    extraFund.Id = Convert.ToInt64(reader["id"]);
                    extraFund.Name = reader["name"].ToString();
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
            return extraFund;
        }

        public List<ExtraFund> GetTop()
        {
            List<ExtraFund> extraFunds = new List<ExtraFund>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT ef.id as ef_id, ef.name as ef_name, mf.id as mf_id, mf.name as mf_name " +
                    "FROM (extra_funds ef INNER JOIN monetary_funds mf ON (ef.monetary_funds_id = mf.id)) " +
                    "ORDER BY ef.id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    ExtraFund extraFund = new ExtraFund();
                    extraFund.Id = Convert.ToInt64(reader["ef_id"]);
                    extraFund.Name = reader["ef_name"].ToString();
                    extraFund.MonetaryFund = new MonetaryFund(Convert.ToInt64(reader["mf_id"]),
                        reader["mf_name"].ToString(), true);

                    extraFunds.Add(extraFund);
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
            return extraFunds;
        }

        public int Insert(ExtraFund extraFund)
        {
            //int rowsAffected = -1;
            object obj = null;
            int returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO extra_funds(name, monetary_funds_id) VALUES (:name, :monetaryFundId) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = extraFund.Name;

                if (extraFund.MonetaryFund == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = extraFund.MonetaryFund.Id;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null)
                {
                    returnedId = (int)obj;
                }
            }
            finally
            {
                this.dal.CloseConection();
            }
            return returnedId;
        }

        public void BulkInsert(HashSet<ExtraFund> extraFundList)
        {
            try
            {
                string cmdInsert = "INSERT INTO extra_funds(name, monetary_funds_id) VALUES (:name, :monetaryFundId)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                dal.OpenConnection();
                foreach (var extraFund in extraFundList)
                {
                    cmd.Parameters[0].Value = extraFund.Name;
                    cmd.Parameters[1].Value = extraFund.MonetaryFund.Id;
                    dal.ExecuteNonQuery(cmd);
                }

            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, ExtraFund extraFund)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE extra_funds set \"name\" = :name, \"monetary_funds_id\" = :monetaryFundId"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = extraFund.Name;
                cmd.Parameters[1].Value = extraFund.MonetaryFund.Id;

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
                string cmdDeletar = String.Format("Delete From extra_funds Where id = '{0}'", id);

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
