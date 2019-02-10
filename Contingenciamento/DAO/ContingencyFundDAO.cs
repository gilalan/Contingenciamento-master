﻿using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.DAO
{
    public class ContingencyFundDAO : IDataAccessObject<ContingencyFund>
    {
        private DAOHelper dal = new DAOHelper();

        public ContingencyFund Get<K>(K id)
        {
            ContingencyFund contingencyFund = new ContingencyFund();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "Select * from contingency_funds Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    contingencyFund.Id = Convert.ToInt32(reader["id"]);
                    contingencyFund.Name = reader["name"].ToString();
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
            return contingencyFund;
        }

        public List<ContingencyFund> GetTop()
        {
            List<ContingencyFund> contingencyFunds = new List<ContingencyFund>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "select * from contingency_funds";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    ContingencyFund contingencyFund = new ContingencyFund();
                    contingencyFund.Id = Convert.ToInt32(reader["id"]);
                    contingencyFund.Name = reader["name"].ToString();
                    contingencyFunds.Add(contingencyFund);
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
            return contingencyFunds;
        }

        public void Insert(ContingencyFund contingencyFund)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInsert = "INSERT INTO contingency_funds(name) VALUES (:name)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = contingencyFund.Name;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<ContingencyFund> contingencyFundList)
        {
            try
            {
                string cmdInsert = "INSERT INTO contingency_funds(name) VALUES (:name)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));

                dal.OpenConnection();
                foreach (var contingencyFund in contingencyFundList)
                {
                    cmd.Parameters[0].Value = contingencyFund.Name;
                    dal.ExecuteNonQuery(cmd);
                }

            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, ContingencyFund contingencyFund)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE contingency_funds set \"name\" = :name"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = contingencyFund.Name;

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
                string cmdDeletar = String.Format("Delete From contingency_funds Where id = '{0}'", id);

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
