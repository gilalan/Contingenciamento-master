using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContingencyAliquotDAO
    {
        private DAOHelper dal = new DAOHelper();
    
        //Não utilizado ainda...
        public ContingencyAliquot Get<K>(K id)
        {
            ContingencyAliquot contingencyAliquot = new ContingencyAliquot();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT * FROM contingency_aliquot WHERE id = " + id + " ORDER BY code";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    //contingencyAliquot.Id = Convert.ToInt64(reader["id"]);
                    //contingencyAliquot.Name = reader["name"].ToString();
                    //contingencyAliquot.Code = reader["code"].ToString();
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
            return contingencyAliquot;
        }

        public List<ContingencyAliquot> GetTop()
        {
            List<ContingencyAliquot> contingencyAliquots = new List<ContingencyAliquot>();
            NpgsqlDataReader reader = null;
            try
            {
                //string query = "SELECT dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, ct.id as ct_id, ct.name as ct_name " +
                //    "FROM (contingencyAliquots dep INNER JOIN contracts ct ON (dep.contract_id = ct.id)) " +
                //    "ORDER BY dep.id";
                //dal.OpenConnection();
                //reader = dal.ExecuteDataReader(query);

                //while (reader.Read())
                //{
                //    ContingencyAliquot contingencyAliquot = new ContingencyAliquot();
                //    contingencyAliquot.Id = Convert.ToInt64(reader["dep_id"]);
                //    contingencyAliquot.Name = reader["dep_name"].ToString();
                //    contingencyAliquot.Name = reader["dep_code"].ToString();
                //    contingencyAliquot.Contract = new Contract(Convert.ToInt64(reader["ct_id"]),
                //        reader["ct_name"].ToString());

                //    contingencyAliquots.Add(contingencyAliquot);
                //}
                //reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return contingencyAliquots;
        }

        public long Insert(ContingencyAliquot contingencyAliquot, long contId)
        {
            //int rowsAffected = -1;
            object obj = null;
            long returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO contingency_aliquot (start_date, end_date, value, contract_id, contingency_fund_id) " +
                    "VALUES (:startDate, :endDate, :value, :contractId, :contingencyFundId) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("startDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("endDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("value", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("contingencyFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                if (contingencyAliquot.StartDate == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = contingencyAliquot.StartDate;

                if (contingencyAliquot.EndDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = contingencyAliquot.EndDate;

                cmd.Parameters[2].Value = contingencyAliquot.Value;
                cmd.Parameters[3].Value = contId;

                if (contingencyAliquot.ContingencyFund == null)
                    cmd.Parameters[4].Value = DBNull.Value;
                else
                    cmd.Parameters[4].Value = contingencyAliquot.ContingencyFund.Id;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null)
                {
                    returnedId = (long)obj;
                }
            }
            finally
            {
                this.dal.CloseConection();
            }
            return returnedId;
        }

        public int BulkInsert(HashSet<ContingencyAliquot> contingencyAliquotList, long contId)
        {
            int count = 0;
            try
            {
                string cmdInsert = "INSERT INTO contingency_aliquot (start_date, end_date, value, contract_id, contingency_fund_id) " +
                    "VALUES (:startDate, :endDate, :value, :contractId, :contingencyFundId) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("startDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("endDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("value", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("contingencyFundId", NpgsqlTypes.NpgsqlDbType.Bigint));
                int rowsAffected = -1;

                dal.OpenConnection();
                foreach (var contingencyAliquot in contingencyAliquotList)
                {
                    if (contingencyAliquot.StartDate == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = contingencyAliquot.StartDate;

                    if (contingencyAliquot.EndDate == null)
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = contingencyAliquot.EndDate;

                    cmd.Parameters[2].Value = contingencyAliquot.Value;
                    cmd.Parameters[3].Value = contId;

                    if (contingencyAliquot.ContingencyFund == null)
                        cmd.Parameters[4].Value = DBNull.Value;
                    else
                        cmd.Parameters[4].Value = contingencyAliquot.ContingencyFund.Id;

                    rowsAffected = dal.ExecuteNonQuery(cmd);
                    if (rowsAffected > 0)
                        count++;
                }
            }
            finally
            {
                this.dal.CloseConection();
            }
            return count;
        }

        public void Update<K>(K id, ContingencyAliquot contingencyAliquot, long contId)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE contingency_aliquot SET \"start_date\" = :startDate, \"end_date\" = :endDate, \"contract_id\" = :contractId, " +
                    "\"value\" = :value, \"contingency_fund_id\" = :contingencyFundId "
                    + "WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("startDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("endDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("value", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("contingencyFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                if (contingencyAliquot.StartDate == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = contingencyAliquot.StartDate;

                if (contingencyAliquot.EndDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = contingencyAliquot.EndDate;

                cmd.Parameters[2].Value = contingencyAliquot.Value;
                cmd.Parameters[3].Value = contId;

                if (contingencyAliquot.ContingencyFund == null)
                    cmd.Parameters[4].Value = DBNull.Value;
                else
                    cmd.Parameters[4].Value = contingencyAliquot.ContingencyFund.Id;

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
                string cmdDelete = String.Format("DELETE FROM contingency_aliquot WHERE id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdDelete);

            }
            finally
            {
                this.dal.CloseConection();
            }
        }
    }
}
