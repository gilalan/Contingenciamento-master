using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContractDAO
    {
        private DAOHelper dal = new DAOHelper();
        //private DepartmentDAO departmentDAO = new DepartmentDAO();
        private ContractMonetaryFundsDAO contractMonetaryFundsDAO = new ContractMonetaryFundsDAO();
        private ContingencyAliquotDAO contingencyAliquotDAO = new ContingencyAliquotDAO();

        public Contract Get<K>(K id)
        {
            Contract contract = null;
            //List<Department> departments = new List<Department>();
            HashSet<MonetaryFund> monetaryFunds = new HashSet<MonetaryFund>(new MonetaryFundComparer());
            List<ContingencyAliquot> contingencyAliquots = new List<ContingencyAliquot>();

            NpgsqlDataReader reader = null;
            try
            {
                NpgsqlCommand cmd;               

                string selectMonetaryFundsCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                "c.description as c_description, c.balance as c_balance " +
                "cmf.id as cmf_id, cmf.contract_id as cmf_contract_id, cmf.monetary_fund_id as cmf_monetary_fund_id, " +
                "mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, " +
                "ef.id as ef_id, ef.name as ef_name " +
                "FROM (contracts c INNER JOIN contract_monetary_funds cmf ON " +
                "(c.id = cmf.contract_id)) " +
                "INNER JOIN monetary_funds mf ON (cmf.monetary_fund_id = mf.id) " +
                "LEFT JOIN extra_funds ef ON (cmf.extra_fund_id = ef.id) " +
                "WHERE c.id = :passedId ORDER BY c.id";

                cmd = new NpgsqlCommand(selectMonetaryFundsCMD);

                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = id;

                reader = dal.ExecuteDataReader(cmd);
                MonetaryFund monetaryFund;
                ExtraFund extraFund;
                long currentMFId = 0;
                while (reader.Read())
                {
                    if (contract == null)
                    {
                        contract = new Contract();
                        contract.Id = Convert.ToInt64(reader["c_id"]);
                        contract.Name = reader["c_name"].ToString();
                        contract.Description = reader["c_description"].ToString();
                        contract.Balance = Convert.ToDouble(reader["c_balance"]);
                        if (reader["start_date"] is DBNull)
                            contract.StartDate = DateTime.MinValue;
                        else
                            contract.StartDate = Convert.ToDateTime(reader["start_date"]);

                        if (reader["end_date"] is DBNull)
                            contract.EndDate = DateTime.MinValue;
                        else
                            contract.EndDate = Convert.ToDateTime(reader["end_date"]);
                    }
                    currentMFId = Convert.ToInt64(reader["mf_id"]);

                    if (reader["ef_id"] is DBNull && reader["ef_name"] is DBNull)
                    {
                        monetaryFund = new MonetaryFund(Convert.ToInt64(reader["mf_id"]), reader["mf_name"].ToString());
                        monetaryFunds.Add(monetaryFund);
                    }
                    else
                    {
                        extraFund = new ExtraFund(Convert.ToInt64(reader["ef_id"]), reader["ef_name"].ToString());
                        monetaryFund = new MonetaryFund(Convert.ToInt64(reader["mf_id"]), reader["mf_name"].ToString());
                        if (monetaryFunds.Add(monetaryFund))
                        {
                            monetaryFund.ExtraFunds.Add(extraFund);
                        }
                        else
                        {
                            foreach (MonetaryFund mf in monetaryFunds)
                            {
                                if (mf.Id == currentMFId)
                                {
                                    mf.ExtraFunds.Add(extraFund);
                                }
                            }
                        }
                    }
                }
                reader.Close();
                if (contract != null)
                {
                    contract.MonetaryFunds = new List<MonetaryFund>(monetaryFunds);
                }

                string selectContAliquotCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                "ca.id as ca_id, ca.start_date as ca_start_date, ca.end_date as ca_end_date, ca.value as ca_value, " +
                "cf.id as cf_id, cf.name as cf_name FROM (contracts c INNER JOIN contingency_aliquot ca ON " +
                "(c.id = ca.contract_id)) " +
                "LEFT JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id) " +
                "WHERE c.id = :passedId ORDER BY c.id";

                cmd.CommandText = selectContAliquotCMD;

                reader = dal.ExecuteDataReader(cmd);
                ContingencyAliquot contingencyAliquot;
                ContingencyFund contingencyFund;
                while (reader.Read())
                {
                    if (contract == null)
                    {
                        contract = new Contract();
                        contract.Id = Convert.ToInt64(reader["c_id"]);
                        contract.Name = reader["c_name"].ToString();
                        contract.StartDate = Convert.ToDateTime(reader["c_start_date"]);
                        contract.EndDate = Convert.ToDateTime(reader["c_end_date"]);
                    }
                    contingencyFund = new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString());
                    contingencyAliquot = new ContingencyAliquot(Convert.ToInt64(reader["ca_id"]), Convert.ToDouble(reader["ca_value"]),
                        Convert.ToDateTime(reader["ca_start_date"]), Convert.ToDateTime(reader["ca_end_date"]), contingencyFund);

                    contingencyAliquots.Add(contingencyAliquot);
                }
                if (contract != null)
                {
                    contract.ContingencyAliquot = contingencyAliquots;
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

        public List<Contract> GetOnlyContracts()
        {
            List<Contract> contracts = new List<Contract>();

            NpgsqlDataReader reader = null;
            try
            {
                NpgsqlCommand cmd;

                string selectCMD = "SELECT * FROM contracts";

                cmd = new NpgsqlCommand(selectCMD);

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);
                Contract contract;
                while (reader.Read())
                {
                    contract = new Contract();
                    contract.Id = Convert.ToInt64(reader["id"]);
                    contract.Name = reader["name"].ToString();
                    contract.Description = reader["description"].ToString();
                    contract.Balance = Convert.ToDouble(reader["balance"]);
                    if (reader["start_date"] is DBNull)
                        contract.StartDate = DateTime.MinValue;
                    else
                        contract.StartDate = Convert.ToDateTime(reader["start_date"]);

                    if (reader["end_date"] is DBNull)
                        contract.EndDate = DateTime.MinValue;
                    else
                        contract.EndDate = Convert.ToDateTime(reader["end_date"]);
                    contracts.Add(contract);
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
        //            contract.Id = Convert.ToInt64(reader["id"]);
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
            Contract contract = null;
            //List<Department> departments = new List<Department>();
            HashSet<MonetaryFund> monetaryFunds = new HashSet<MonetaryFund>(new MonetaryFundComparer());
            List<ContingencyAliquot> contingencyAliquots = new List<ContingencyAliquot>();

            NpgsqlDataReader reader = null;
            try
            {
                NpgsqlCommand cmd;

                string selectCMD = "SELECT * FROM contracts";

                cmd = new NpgsqlCommand(selectCMD);

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);
                while (reader.Read())
                {
                    contract = new Contract();
                    contract.Id = Convert.ToInt64(reader["id"]);
                    contract.Name = reader["name"].ToString();
                    contract.Description = reader["description"].ToString();
                    contract.Balance = Convert.ToDouble(reader["balance"]);

                    if (reader["start_date"] is DBNull)
                        contract.StartDate = DateTime.MinValue;
                    else
                        contract.StartDate = Convert.ToDateTime(reader["start_date"]);

                    if (reader["end_date"] is DBNull)
                        contract.EndDate = DateTime.MinValue;
                    else
                        contract.EndDate = Convert.ToDateTime(reader["end_date"]);

                    contracts.Add(contract);
                }
                reader.Close();

                //Department department;
                MonetaryFund monetaryFund;
                ExtraFund extraFund;
                ContingencyAliquot contingencyAliquot;
                ContingencyFund contingencyFund;

                string selectMonetaryFundsCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                    "cmf.id as cmf_id, cmf.contract_id as cmf_contract_id, cmf.monetary_fund_id as cmf_monetary_fund_id, " +
                    "mf.id as mf_id, mf.name as mf_name, mf.primal as mf_primal, " +
                    "ef.id as ef_id, ef.name as ef_name " +
                    "FROM (contracts c INNER JOIN contract_monetary_funds cmf ON " +
                    "(c.id = cmf.contract_id)) " +
                    "INNER JOIN monetary_funds mf ON (cmf.monetary_fund_id = mf.id) " +
                    "LEFT JOIN extra_funds ef ON (cmf.extra_fund_id = ef.id) " +
                    "WHERE c.id = :passedId ORDER BY c.id";

                string selectContAliquotCMD = "SELECT c.id as c_id, c.name as c_name, c.start_date as c_start_date, c.end_date as c_end_date, " +
                    "ca.id as ca_id, ca.start_date as ca_start_date, ca.end_date as ca_end_date, ca.value as ca_value, " +
                    "cf.id as cf_id, cf.name as cf_name FROM (contracts c INNER JOIN contingency_aliquot ca ON " +
                    "(c.id = ca.contract_id)) " +
                    "LEFT JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id) " +
                    "WHERE c.id = :passedId ORDER BY c.id";

                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));

                foreach (Contract ct in contracts)
                {
                    //Consultar as verbas monetárias do contrato
                    cmd.CommandText = selectMonetaryFundsCMD;
                    cmd.Parameters[0].Value = ct.Id;
                    monetaryFunds = new HashSet<MonetaryFund>(new MonetaryFundComparer());
                    contingencyAliquots = new List<ContingencyAliquot>();

                    reader = dal.ExecuteDataReader(cmd);
                    
                    long currentMFId = 0;
                    while (reader.Read())
                    {                        
                        currentMFId = Convert.ToInt64(reader["mf_id"]);

                        if (reader["ef_id"] is DBNull && reader["ef_name"] is DBNull)
                        {
                            monetaryFund = new MonetaryFund(Convert.ToInt64(reader["mf_id"]), reader["mf_name"].ToString());
                            monetaryFunds.Add(monetaryFund);
                        }
                        else
                        {
                            extraFund = new ExtraFund(Convert.ToInt64(reader["ef_id"]), reader["ef_name"].ToString());
                            monetaryFund = new MonetaryFund(Convert.ToInt64(reader["mf_id"]), reader["mf_name"].ToString());
                            if (monetaryFunds.Add(monetaryFund))
                            {
                                monetaryFund.ExtraFunds.Add(extraFund);
                            }
                            else
                            {
                                foreach (MonetaryFund mf in monetaryFunds)
                                {
                                    if (mf.Id == currentMFId)
                                    {
                                        mf.ExtraFunds.Add(extraFund);
                                    }
                                }
                            }
                        }
                    }
                    reader.Close();
                    ct.MonetaryFunds = new List<MonetaryFund>(monetaryFunds);

                    //Consultar as alíquotas do contrato
                    cmd.CommandText = selectContAliquotCMD;

                    reader = dal.ExecuteDataReader(cmd);
                    while (reader.Read())
                    {
                        contingencyFund = new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString());
                        contingencyAliquot = new ContingencyAliquot(Convert.ToInt64(reader["ca_id"]), Convert.ToDouble(reader["ca_value"]),
                            Convert.ToDateTime(reader["ca_start_date"]), Convert.ToDateTime(reader["ca_end_date"]), contingencyFund);

                        contingencyAliquots.Add(contingencyAliquot);
                    }
                    reader.Close();
                    ct.ContingencyAliquot = contingencyAliquots;
                }
                
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
                string insertCMD = "INSERT INTO contracts(name,start_date,end_date,description,balance) " +
                    "VALUES (:name,:start_date,:end_date,:description,:balance) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("description", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("balance", NpgsqlTypes.NpgsqlDbType.Double));

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

                if (String.IsNullOrEmpty(oContract.Description))
                    cmd.Parameters[3].Value = DBNull.Value;
                else
                    cmd.Parameters[3].Value = oContract.Description;
                
                cmd.Parameters[4].Value = oContract.Balance;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null) //salvar em tabelas extras outras informações relacionadas (contingency_aliquot e monetary_funds)
                {
                    idReturned = (long)obj;
                    //Departments relacionados
                    //foreach (Department dep in oContract.Departments)
                    //{
                    //    dep.Contract = new Contract(idReturned);
                    //    departmentDAO.Update(dep.Id, dep);
                    //}
                    //Inserir na tabela intermediária de Verbas de Contingência com as Alíquotas
                    foreach (ContingencyAliquot contAliq in oContract.ContingencyAliquot)
                    {
                        contAliq.Contract = new Contract(idReturned);
                        contingencyAliquotDAO.Insert(contAliq);
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
                "\"end_date\" = :end_date, \"description\" = :description, \"balance\" = :balance WHERE \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("start_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("description", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("balance", NpgsqlTypes.NpgsqlDbType.Double));

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

                if (String.IsNullOrEmpty(oContract.Description))
                    cmd.Parameters[3].Value = DBNull.Value;
                else
                    cmd.Parameters[3].Value = oContract.Description;

                cmd.Parameters[4].Value = oContract.Balance;

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
