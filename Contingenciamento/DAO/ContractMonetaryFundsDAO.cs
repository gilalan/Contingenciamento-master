using Npgsql;
using System;

namespace Contingenciamento.DAO
{
    public class ContractMonetaryFundsDAO
    {
        private DAOHelper dal = new DAOHelper();

        public long Insert(long contId, long mfId)
        {
            //int rowsAffected = -1;
            object obj = null;
            long returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO contract_monetary_funds (contract_id, monetary_fund_id) " +
                    "VALUES (:contractId, :monetaryFundId) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = contId;
                cmd.Parameters[1].Value = mfId;

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

        public long Insert(long contId, long mfId, long efId)
        {
            //int rowsAffected = -1;
            object obj = null;
            long returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO contract_monetary_funds (contract_id, monetary_fund_id, extra_fund_id) " +
                    "VALUES (:contractId, :monetaryFundId, :extraFundId) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("extraFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = contId;
                cmd.Parameters[1].Value = mfId;
                cmd.Parameters[2].Value = efId;

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

        public void Update<K>(K id, long mfId, long contId)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE contract_monetary_funds SET \"contract_id\" = :contractId, " +
                    "\"monetary_fund_id\" = :monetaryFundId "
                    + "WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("contractId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetaryFundId", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = contId;
                cmd.Parameters[1].Value = mfId;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }
    }
}
