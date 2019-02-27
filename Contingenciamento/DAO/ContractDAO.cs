using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContractDAO
    {
        private DAOHelper dal = new DAOHelper();
        private DepartmentDAO departmentDAO = new DepartmentDAO();
        private ContractMonetaryFundsDAO contractMonetaryFundsDAO = new ContractMonetaryFundsDAO();
        private ContingencyAliquotDAO contingencyAliquotDAO = new ContingencyAliquotDAO();

        public Contract Get<K>(K id)
        {
            Contract contract = new Contract();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                    "cmf.id as cmf_id, cmf.contract_id as cmf_contract_id, cmf.monetary_fund_id as cmf_monetary_fund_id, " +
                    "mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, " +
                    "ef.id as ef_id, ef.name as ef_name, " +
                    "ca.id as ca_id, ca.start_date as ca_start_date, ca.end_date as ca_end_date, ca.value as ca_value, ca.contingency_fund_id as ca_contingency_fund_id, " +
                    "cf.id as cf_id, cf.name as cf_name FROM (contracts c INNER JOIN contract_monetary_funds cmf ON " +
                    "(c.id = cmf.contract_id)) " +
                    "INNER JOIN monetary_funds mf ON (cmf.monetary_fund_id = mf.id) " +
                    "LEFT JOIN extra_funds ef ON (mf.id = ef.monetary_funds_id) " +
                    "INNER JOIN contingency_aliquot ca ON (c.id = ca.contract_id) " +
                    "INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id) " +
                    "WHERE id = :passedId ORDER BY c.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = id;

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);
                if (reader.Read())
                {
                    //contract.Id = Convert.ToInt32(reader["id"]);
                    //contract.Name = reader["name"].ToString();
                    //contract.StartDate = Convert.ToDateTime(reader["start_date"]);
                    //contract.EndDate = Convert.ToDateTime(reader["end_date"]);
                    //contract.PIS = reader["pis"].ToString();
                    //contract.CPF = reader["cpf"].ToString();
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
            return contract;
        }

        //public Contract GetByName<K>(K name)
        //{

        //    Contract contract = new Contract();
        //    NpgsqlDataReader reader = null;
        //    try
        //    {
        //        string SELECTCMD = "SELECT * FROM contracts WHERE matricula = '" + name + "'";
        //        dal.OpenConnection();
        //        reader = dal.ExecuteDataReader(SELECTCMD);

        //        if (reader.Read())
        //        {
        //            contract.Id = Convert.ToInt32(reader["id"]);
        //            contract.Name = reader["name"].ToString();
        //            contract.Matriculation = reader["matriculation"].ToString();
        //            contract.Birthday = Convert.ToDateTime(reader["birthday"]);
        //            contract.CurrentStartDate = Convert.ToDateTime(reader["start_date"]);
        //            contract.CurrentEndDate = Convert.ToDateTime(reader["end_date"]);
        //            contract.PIS = reader["pis"].ToString();
        //            contract.CPF = reader["cpf"].ToString();

        //        }
        //        reader.Close();
        //    }

        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //        }
        //        this.dal.CloseConection();
        //    }
        //    return contract;
        //}

        public List<Contract> GetTop()
        {
            List<Contract> contracts = new List<Contract>();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                    "cmf.id as cmf_id, cmf.contract_id as cmf_contract_id, cmf.monetary_fund_id as cmf_monetary_fund_id, " +
                    "mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, " +
                    "ef.id as ef_id, ef.name as ef_name, " +
                    "ca.id as ca_id, ca.start_date as ca_start_date, ca.end_date as ca_end_date, ca.value as ca_value, ca.contingency_fund_id as ca_contingency_fund_id, " +
                    "cf.id as cf_id, cf.name as cf_name FROM (contracts c INNER JOIN contract_monetary_funds cmf ON " +
                    "(c.id = cmf.contract_id)) " +
                    "INNER JOIN monetary_funds mf ON (cmf.monetary_fund_id = mf.id) " +
                    "LEFT JOIN extra_funds ef ON (mf.id = ef.monetary_funds_id) " +
                    "INNER JOIN contingency_aliquot ca ON (c.id = ca.contract_id) " +
                    "INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id) " +
                    "ORDER BY c.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                while (reader.Read())
                {
                    //Contract contract = new Contract();
                    //contract.Id = Convert.ToInt32(reader["id"]);
                    //contract.Name = reader["name"].ToString();
                    //contract.Matriculation = reader["matriculation"].ToString();
                    //contract.Birthday = Convert.ToDateTime(reader["birthday"]);
                    //contract.CurrentStartDate = Convert.ToDateTime(reader["start_date"]);
                    //contract.CurrentEndDate = Convert.ToDateTime(reader["end_date"]);
                    //contract.PIS = reader["pis"].ToString();
                    //contract.CPF = reader["cpf"].ToString();
                    //contracts.Add(contract);
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
            return contracts;
        }

        public long Insert(Contract oContract)
        {
            //int rowsAffected = -1;
            object obj = null;
            long idReturned = -1;
            try
            {
                string insertCMD = "INSERT INTO contracts(name,start_date,end_date) " +
                    "VALUES (:name,:start_date,:end_date) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.Date));

                if (String.IsNullOrEmpty(oContract.Name))
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oContract.Name;

                if (oContract.StartDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = oContract.StartDate;

                if (oContract.EndDate == null)
                    cmd.Parameters[2].Value = DBNull.Value;
                else
                    cmd.Parameters[2].Value = oContract.EndDate;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null) //salvar em tabelas extras outras informações relacionadas (contingency_aliquot e monetary_funds)
                {
                    idReturned = (long)obj;
                    //Departments relacionados
                    foreach (Department dep in oContract.Departments)
                    {
                        dep.Contract = new Contract(idReturned);
                        departmentDAO.Update(dep.Id, dep);
                    }
                    //Inserir na tabela intermediária de Verbas de Contingência com as Alíquotas
                    foreach (ContingencyAliquot contAliq in oContract.ContingencyAliquot)
                    {
                        contingencyAliquotDAO.Insert(contAliq, idReturned);
                    }
                    //Inserir na tabela intermediária de Verbas Monetárias com Contratos
                    foreach (MonetaryFund mf in oContract.MonetaryFunds)
                    {
                        if (mf.ExtraFunds.Count > 0)
                        {
                            foreach (ExtraFund ef in mf.ExtraFunds)
                            {
                                contractMonetaryFundsDAO.Insert(idReturned, mf.Id, ef.Id);
                            }
                        }
                        else
                        {
                            contractMonetaryFundsDAO.Insert(idReturned, mf.Id);
                        }
                    }
                }
            }
            finally
            {
                this.dal.CloseConection();
            }

            return idReturned;
        }

        public int BulkInsert(HashSet<Contract> contractList)
        {
            int rowsAffected = -1;
            try
            {
                //a fazer
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.dal.CloseConection();
            }
            return rowsAffected;
        }

        public void Update<K>(K id, Contract oContract)
        {
            int rowsAffected = -1;
            try
            {
                string updateCMD = "Update contracts set \"name\" = :name, \"start_date\" = :start_date," +
                "\"end_date\" = :end_date WHERE \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.Date));

                if (String.IsNullOrEmpty(oContract.Name))
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oContract.Name;

                if (oContract.StartDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = oContract.StartDate;

                if (oContract.EndDate == null)
                    cmd.Parameters[2].Value = DBNull.Value;
                else
                    cmd.Parameters[2].Value = oContract.EndDate;

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
                string deleteCMD = String.Format("DELETE FROM contracts WHERE id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(deleteCMD);

            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public System.Windows.Forms.AutoCompleteStringCollection GetContractsNames()
        {
            System.Windows.Forms.AutoCompleteStringCollection myCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT name, id FROM contracts";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    myCollection.Add(reader["name"].ToString() + "(" + reader["id"].ToString() + ")");
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
            return myCollection;
        }
    }
}
