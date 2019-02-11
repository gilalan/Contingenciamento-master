using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.DAO
{
    public class ExtraFundDAO : IDataAccessObject<ExtraFund>
    {
        private DAOHelper dal = new DAOHelper();

        public ExtraFund Get<K>(K id)
        {
            ExtraFund extraFund = new ExtraFund();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "Select * from extra_funds Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    extraFund.Id = Convert.ToInt32(reader["id"]);
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
                string query = "select * from extra_funds";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    ExtraFund extraFund = new ExtraFund();
                    extraFund.Id = Convert.ToInt32(reader["id"]);
                    extraFund.Name = reader["name"].ToString();

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

        public void Insert(ExtraFund extraFund)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInsert = "INSERT INTO extra_funds(name, monetary_funds_id) VALUES (:name, :monetaryFundId)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Integer));

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

        public void BulkInsert(HashSet<ExtraFund> extraFundList)
        {
            try
            {
                string cmdInsert = "INSERT INTO extra_funds(name, monetary_funds_id) VALUES (:name, :monetaryFundId)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Integer));

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
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Integer));

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
