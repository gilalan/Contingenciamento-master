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
                string selectCMD = "SELECT ca.id as ca_id, ca.value as ca_value, " +                    
                    "cf.id as cf_id, cf.name as cf_name, ctt.id as ctt_id, ctt.name as ctt_name " +
                    "FROM (contingency_aliquot ca INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id)) " +
                    "INNER JOIN contracts ctt ON (ca.contract_id = ctt.id) " +
                    "WHERE ca.id = :passedId ORDER BY ca.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = id;

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                if (reader.Read())
                {
                    contingencyAliquot.Id = Convert.ToInt64(reader["ca_id"]);
                    contingencyAliquot.Value = Convert.ToDouble(reader["ca_value"]);
                    Contract contract = new Contract(Convert.ToInt64(reader["ctt_id"]), reader["ctt_name"].ToString());
                    contingencyAliquot.Contract = contract;
                    ContingencyFund contingencyFund = new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString());
                    contingencyAliquot.ContingencyFund = contingencyFund;
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

        public List<ContingencyAliquot> GetByContract(Contract ct)
        {
            List<ContingencyAliquot> contingencyAliquots = new List<ContingencyAliquot>();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT ca.id as ca_id, ca.value as ca_value, " +
                    "cf.id as cf_id, cf.name as cf_name, ctt.id as ctt_id, ctt.name as ctt_name " +
                    "FROM (contingency_aliquot ca INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id)) " +
                    "INNER JOIN contracts ctt ON (ca.contract_id = ctt.id) " +
                    "WHERE ca.contract_id = :ctID ORDER BY ca.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                cmd.Parameters.Add(new NpgsqlParameter("ctID", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = ct.Id;

                Contract contract;
                ContingencyFund contingencyFund;
                ContingencyAliquot contingencyAliquot;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    contingencyAliquot = new ContingencyAliquot();
                    contingencyAliquot.Id = Convert.ToInt64(reader["ca_id"]);
                    contingencyAliquot.Value = Convert.ToDouble(reader["ca_value"]);
                    contract = new Contract(Convert.ToInt64(reader["ctt_id"]), reader["ctt_name"].ToString());
                    contingencyAliquot.Contract = contract;
                    contingencyFund = new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString());
                    contingencyAliquot.ContingencyFund = contingencyFund;

                    contingencyAliquots.Add(contingencyAliquot);
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
            return contingencyAliquots;
        }

        public List<ContingencyAliquot> GetTop()
        {
            List<ContingencyAliquot> contingencyAliquots = new List<ContingencyAliquot>();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT ca.id as ca_id, ca.value as ca_value, " +
                    "cf.id as cf_id, cf.name as cf_name, ctt.id as ctt_id, ctt.name as ctt_name " +
                    "FROM (contingency_aliquot ca INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id)) " +
                    "INNER JOIN contracts ctt ON (ca.contract_id = ctt.id) " +
                    "ORDER BY ca.id";

                Contract contract;
                ContingencyFund contingencyFund;
                ContingencyAliquot contingencyAliquot;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(selectCMD);

                while (reader.Read())
                {
                    contingencyAliquot = new ContingencyAliquot();
                    contingencyAliquot.Id = Convert.ToInt64(reader["ca_id"]);
                    contingencyAliquot.Value = Convert.ToDouble(reader["ca_value"]);
                    contract = new Contract(Convert.ToInt64(reader["ctt_id"]), reader["ctt_name"].ToString());
                    contingencyAliquot.Contract = contract;
                    contingencyFund = new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString());
                    contingencyAliquot.ContingencyFund = contingencyFund;

                    contingencyAliquots.Add(contingencyAliquot);
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
            return contingencyAliquots;
        }

        public long Insert(ContingencyAliquot contingencyAliquot)
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

                if (contingencyAliquot.Contract == null)
                    cmd.Parameters[3].Value = DBNull.Value;
                else
                    cmd.Parameters[3].Value = contingencyAliquot.Contract.Id;

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

        public int BulkInsert(HashSet<ContingencyAliquot> contingencyAliquotList)
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

                    if (contingencyAliquot.Contract == null)
                        cmd.Parameters[3].Value = DBNull.Value;
                    else
                        cmd.Parameters[3].Value = contingencyAliquot.Contract.Id;

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

        public void Update<K>(K id, ContingencyAliquot contingencyAliquot)
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

                if (contingencyAliquot.Contract == null)
                    cmd.Parameters[3].Value = DBNull.Value;
                else
                    cmd.Parameters[3].Value = contingencyAliquot.Contract.Id;

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
