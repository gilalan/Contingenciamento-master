
using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class AdmDemHistoryDAO
    {
        private DAOHelper dal = new DAOHelper();

        public AdmissionDemissionHistory Get<K>(K id)
        {

            AdmissionDemissionHistory admissionDemissionHistory = new AdmissionDemissionHistory();
            NpgsqlDataReader reader = null;
            try
            {
                //string selectCMD = "SELECT adh.id as adh_id, adh.admission as adh_adm, adh.demission as adh_dem, rls.id as rls_id, rls.name as rls_name " +
                //    "FROM (adm_dem_history adh INNER JOIN roles rls ON (adh.role_id = rls.id)) WHERE id = " + id;
                string selectCMD = "SELECT * FROM adm_dem_history WHERE id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(selectCMD);

                if (reader.Read())
                {
                    admissionDemissionHistory.Id = Convert.ToInt32(reader["id"]);
                    admissionDemissionHistory.AdmissionDate = Convert.ToDateTime(reader["admission"]);
                    admissionDemissionHistory.DemissionDate = Convert.ToDateTime(reader["demission"]);
                    admissionDemissionHistory.Matriculation = reader["matriculation"].ToString();
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
            return admissionDemissionHistory;
        }

        public List<AdmissionDemissionHistory> GetTop()
        {
            List<AdmissionDemissionHistory> admissionDemissionHistories = new List<AdmissionDemissionHistory>();
            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT * FROM adm_dem_history";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    AdmissionDemissionHistory admissionDemissionHistory = new AdmissionDemissionHistory();
                    admissionDemissionHistory.Id = Convert.ToInt32(reader["id"]);
                    admissionDemissionHistory.AdmissionDate = Convert.ToDateTime(reader["admission"]);
                    admissionDemissionHistory.DemissionDate = Convert.ToDateTime(reader["demission"]);
                    admissionDemissionHistory.Matriculation = reader["matriculation"].ToString();
                    admissionDemissionHistories.Add(admissionDemissionHistory);
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
            return admissionDemissionHistories;
        }

        public void Insert(AdmissionDemissionHistory oAdmissionDemissionHistory)
        {
            int rowsAffected = -1;
            try
            {
                string insertCMD = "INSERT INTO adm_dem_history(admission,demission,role_id,employee_id,matriculation) " +
                    "VALUES (:admission,:demission,:role_id,:employee_id,:matriculation)";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("admission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));

                if (oAdmissionDemissionHistory.AdmissionDate == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oAdmissionDemissionHistory.AdmissionDate;

                if (oAdmissionDemissionHistory.DemissionDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = oAdmissionDemissionHistory.DemissionDate;

                if (oAdmissionDemissionHistory.Role == null)
                    cmd.Parameters[2].Value = DBNull.Value;
                else
                {
                    if (oAdmissionDemissionHistory.Role.Id <= 0)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                        cmd.Parameters[2].Value = oAdmissionDemissionHistory.Role.Id;
                }

                if (oAdmissionDemissionHistory.EmployeeId > 0)
                    cmd.Parameters[3].Value = oAdmissionDemissionHistory.EmployeeId;
                else
                    cmd.Parameters[3].Value = DBNull.Value;

                if (String.IsNullOrEmpty(oAdmissionDemissionHistory.Matriculation))
                    cmd.Parameters[4].Value = DBNull.Value;
                else
                    cmd.Parameters[4].Value = oAdmissionDemissionHistory.Matriculation;

                    dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<AdmissionDemissionHistory> admissionDemissionHistoryList)
        {
            try
            {
                string insertCMD = "INSERT INTO adm_dem_history(admission,demission,role_id,employee_id,matriculation) " +
                     "VALUES (:admission,:demission,:role_id,:employee_id,:matriculation)";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("admission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));
                dal.OpenConnection();

                foreach (var oAdmissionDemissionHistory in admissionDemissionHistoryList)
                {
                    if (oAdmissionDemissionHistory.AdmissionDate == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = oAdmissionDemissionHistory.AdmissionDate;

                    if (oAdmissionDemissionHistory.DemissionDate == null)
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = oAdmissionDemissionHistory.DemissionDate;

                    if (oAdmissionDemissionHistory.Role == null)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                    {
                        if (oAdmissionDemissionHistory.Role.Id <= 0)
                            cmd.Parameters[2].Value = DBNull.Value;
                        else
                            cmd.Parameters[2].Value = oAdmissionDemissionHistory.Role.Id;
                    }

                    if (oAdmissionDemissionHistory.EmployeeId > 0)
                        cmd.Parameters[3].Value = oAdmissionDemissionHistory.EmployeeId;
                    else
                        cmd.Parameters[3].Value = DBNull.Value;

                    if (String.IsNullOrEmpty(oAdmissionDemissionHistory.Matriculation))
                        cmd.Parameters[4].Value = DBNull.Value;
                    else
                        cmd.Parameters[4].Value = oAdmissionDemissionHistory.Matriculation;

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

        public void InsertAll (List<AdmissionDemissionHistory> admissionDemissionHistories, int employeeId)
        {
            try
            {
                string insertCMD = "INSERT INTO adm_dem_history(admission,demission,role_id,employee_id,matriculation) " +
                     "VALUES (:admission,:demission,:role_id,:employee_id,:matriculation)";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("admission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));
                dal.OpenConnection();

                foreach (var oAdmissionDemissionHistory in admissionDemissionHistories)
                {
                    if (oAdmissionDemissionHistory.AdmissionDate == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = oAdmissionDemissionHistory.AdmissionDate;

                    if (oAdmissionDemissionHistory.DemissionDate == null)
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = oAdmissionDemissionHistory.DemissionDate;

                    if (oAdmissionDemissionHistory.Role == null)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                    {
                        if (oAdmissionDemissionHistory.Role.Id <= 0)
                            cmd.Parameters[2].Value = DBNull.Value;
                        else
                            cmd.Parameters[2].Value = oAdmissionDemissionHistory.Role.Id;
                    }

                    if (employeeId > 0)
                        cmd.Parameters[3].Value = employeeId;
                    else
                        cmd.Parameters[3].Value = DBNull.Value;

                    if (String.IsNullOrEmpty(oAdmissionDemissionHistory.Matriculation))
                        cmd.Parameters[4].Value = DBNull.Value;
                    else
                        cmd.Parameters[4].Value = oAdmissionDemissionHistory.Matriculation;

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

        public void Update<K>(K id, AdmissionDemissionHistory oAdmissionDemissionHistory)
        {
            int rowsAffected = -1;
            try
            {
                string updateCMD = "UPDATE adm_dem_history SET \"admission\" = :admission, \"demission\" = :demission, " +
                "\"role_id\" = :role_id, \"employee_id\" = :employee_id, \"matriculation\" = :matriculation WHERE \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("admission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));

                if (oAdmissionDemissionHistory.AdmissionDate == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oAdmissionDemissionHistory.AdmissionDate;

                if (oAdmissionDemissionHistory.DemissionDate == null)
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = oAdmissionDemissionHistory.DemissionDate;

                if (oAdmissionDemissionHistory.Role == null)
                    cmd.Parameters[2].Value = DBNull.Value;
                else
                {
                    if (oAdmissionDemissionHistory.Role.Id <= 0)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                        cmd.Parameters[2].Value = oAdmissionDemissionHistory.Role.Id;
                }

                if (oAdmissionDemissionHistory.EmployeeId > 0)
                    cmd.Parameters[3].Value = oAdmissionDemissionHistory.EmployeeId;
                else
                    cmd.Parameters[3].Value = DBNull.Value;

                if (String.IsNullOrEmpty(oAdmissionDemissionHistory.Matriculation))
                    cmd.Parameters[4].Value = DBNull.Value;
                else
                    cmd.Parameters[4].Value = oAdmissionDemissionHistory.Matriculation;

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
                string deleteCMD = String.Format("DELETE FROM adm_dem_history WHERE id = '{0}'", id);

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
