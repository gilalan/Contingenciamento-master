using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class BankDAO
    {
        private DAOHelper dal = new DAOHelper();
        public Bank Get<K>(K id)
        {

            Bank bank = new Bank();
            NpgsqlDataReader reader = null;
            try
            {
                string SELECTCMD = "SELECT * FROM bank_data WHERE id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(SELECTCMD);

                if (reader.Read())
                {
                    bank.Id = Convert.ToInt64(reader["id"]);
                    bank.Name = reader["name"].ToString();
                    bank.Code = reader["code"].ToString();
                    bank.Agency = reader["agency"].ToString();
                    bank.Account = reader["account"].ToString();
                    bank.DV = reader["dv"].ToString();
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
            return bank;
        }

        public List<Bank> GetTop()
        {
            List<Bank> banks = new List<Bank>();
            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT * FROM bank_data";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Bank bank = new Bank();
                    bank.Id = Convert.ToInt64(reader["id"]);
                    bank.Name = reader["name"].ToString();
                    bank.Code = reader["code"].ToString();
                    bank.Agency = reader["agency"].ToString();
                    bank.Account = reader["account"].ToString();
                    bank.DV = reader["dv"].ToString();
                    banks.Add(bank);
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
            return banks;
        }

        public void Insert(Bank oBank)
        {
            int rowsAffected = -1;
            try
            {
                string insertCMD = "INSERT INTO bank_data(name,code,agency,account,dv,employee_id) " +
                    "VALUES (:name,:code,:agency,:account,:dv,:employee_id)";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("agency", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("account", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("dv", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Bigint));

                cmd.Parameters[0].Value = oBank.Name;
                cmd.Parameters[1].Value = oBank.Code;
                cmd.Parameters[2].Value = oBank.Agency;
                cmd.Parameters[3].Value = oBank.Account;
                cmd.Parameters[4].Value = oBank.DV;
                cmd.Parameters[5].Value = oBank.EmployeeId;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public void BulkInsert(HashSet<Bank> bankList)
        {
            try
            {
                string insertCMD = "INSERT INTO bank_data(name,code,agency,account,dv,employee_id) " +
                    "VALUES (:name,:code,:agency,:account,:dv,:employee_id)";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("agency", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("account", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("dv", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                dal.OpenConnection();

                foreach (var oBank in bankList)
                {
                    cmd.Parameters[0].Value = oBank.Name;
                    cmd.Parameters[1].Value = oBank.Code;
                    cmd.Parameters[2].Value = oBank.Agency;
                    cmd.Parameters[3].Value = oBank.Account;
                    cmd.Parameters[4].Value = oBank.DV;
                    cmd.Parameters[5].Value = oBank.EmployeeId;
                    dal.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, Bank oBank)
        {
            int rowsAffected = -1;
            try
            {
                string updateCMD = "Update bank_data set \"name\" = :name, \"code\" = :code, \"agency\" = :agency," +
                "\"account\" = :account, \"dv\" = :dv where \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("agency", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("account", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("dv", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = oBank.Name;
                cmd.Parameters[1].Value = oBank.Code;
                cmd.Parameters[2].Value = oBank.Agency;
                cmd.Parameters[3].Value = oBank.Account;
                cmd.Parameters[4].Value = oBank.DV;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public void Delete<K>(K id)
        {
            int rowsAffected = -1;
            try
            {
                string deleteCMD = String.Format("DELETE FROM bank_data WHERE id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(deleteCMD);

            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }
    }
}
