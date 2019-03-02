using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class EmployeeDAO 
    {
        private DAOHelper dal = new DAOHelper();
        private BankDAO bankDao = new BankDAO();
        private AdmDemHistoryDAO admDemHistDAO = new AdmDemHistoryDAO();

        public Employee Get<K>(K id)
        {

            Employee employee = new Employee();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT * FROM employees WHERE id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(selectCMD);

                if (reader.Read())
                {
                    employee.Id = Convert.ToInt64(reader["id"]);
                    employee.Name = reader["name"].ToString();
                    employee.Matriculation = reader["matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["demission_date"]);
                    employee.PIS = reader["pis"].ToString();
                    employee.CPF = reader["cpf"].ToString();
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
            return employee;
        }

        public Employee GetByMatricula<K>(K matricula)
        {

            Employee employee = new Employee();
            NpgsqlDataReader reader = null;
            try
            {
                string SelectCMD = "SELECT * FROM employees WHERE matricula = '" + matricula + "'";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(SelectCMD);

                if (reader.Read())
                {
                    employee.Id = Convert.ToInt64(reader["id"]);
                    employee.Name = reader["name"].ToString();
                    employee.Matriculation = reader["matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["demission_date"]);
                    employee.PIS = reader["pis"].ToString();
                    employee.CPF = reader["cpf"].ToString();

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
            return employee;
        }

        public List<Employee> GetTop()
        {
            List<Employee> employees = new List<Employee>();
            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT * FROM employees";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt64(reader["id"]);
                    employee.Name = reader["name"].ToString();
                    employee.Matriculation = reader["matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["demission_date"]);
                    employee.PIS = reader["pis"].ToString();
                    employee.CPF = reader["cpf"].ToString();
                    employees.Add(employee);
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
            return employees;
        }

        public long Insert(Employee oEmployee)
        {
            //int rowsAffected = -1;
            object obj = null;
            long idReturned = -1;
            try
            {
                string insertCMD = "INSERT INTO employees(name,matriculation,admission_date,demission_date,birthday,pis,cpf,role_id) " +
                    "VALUES (:name,:matriculation,:admission_date,:demission_date,:birthday,:pis,:cpf,:role_id) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("admission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("birthday", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("pis", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cpf", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Bigint));

                if (String.IsNullOrEmpty(oEmployee.Name))
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oEmployee.Name;

                if (String.IsNullOrEmpty(oEmployee.Matriculation)) 
                    cmd.Parameters[1].Value = DBNull.Value;
                else
                    cmd.Parameters[1].Value = oEmployee.Matriculation;

                if (oEmployee.CurrentAdmissionDate == null)
                    cmd.Parameters[2].Value = DBNull.Value;
                else
                    cmd.Parameters[2].Value = oEmployee.CurrentAdmissionDate;

                if (oEmployee.CurrentDemissionDate == null)
                    cmd.Parameters[3].Value = DBNull.Value;
                else
                    cmd.Parameters[3].Value = oEmployee.CurrentDemissionDate;

                if (oEmployee.Birthday == null)
                    cmd.Parameters[4].Value = DBNull.Value;
                else
                    cmd.Parameters[4].Value = oEmployee.Birthday;

                if (String.IsNullOrEmpty(oEmployee.PIS))
                    cmd.Parameters[5].Value = DBNull.Value;
                else
                    cmd.Parameters[5].Value = oEmployee.PIS;

                if (String.IsNullOrEmpty(oEmployee.CPF))
                    cmd.Parameters[6].Value = DBNull.Value;
                else
                    cmd.Parameters[6].Value = oEmployee.CPF;

                if (oEmployee.Role == null)
                    cmd.Parameters[7].Value = DBNull.Value;
                else
                {
                    if(oEmployee.Role.Id <= 0)
                        cmd.Parameters[7].Value = DBNull.Value;
                    else
                        cmd.Parameters[7].Value = oEmployee.Role.Id;
                }

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null) //salvar em tabelas extras outras informações do usuário
                {
                    idReturned = (long) obj;
                    //Informações bancárias
                    if (oEmployee.BankData != null)
                    {
                        oEmployee.BankData.EmployeeId = idReturned;
                        bankDao.Insert(oEmployee.BankData);
                    }
                    //Histórico de admissão/demissão/cargo
                    if(oEmployee.AdmissionDemissionHistories.Count > 0)
                        admDemHistDAO.InsertAll(oEmployee.AdmissionDemissionHistories, idReturned);
                }
            }
            finally
            {
                this.dal.CloseConection();
            }

            return idReturned;
        }

        public void BulkInsert(HashSet<Employee> employeeList)
        {
            try
            {
                object obj = null;
                long idReturned = -1;
                string insertCMD = "INSERT INTO employees(name,matriculation,admission_date,demission_date,birthday,pis,cpf,role_id) " +
                    "VALUES (:name,:matriculation,:admission_date,:demission_date,:birthday,:pis,:cpf,:role_id) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("admission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("birthday", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("pis", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cpf", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("role_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                dal.OpenConnection();

                foreach (var oEmployee in employeeList)
                {
                    idReturned = -1;
                    if (String.IsNullOrEmpty(oEmployee.Name))
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = oEmployee.Name;

                    if (String.IsNullOrEmpty(oEmployee.Matriculation))
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = oEmployee.Matriculation;

                    if (oEmployee.CurrentAdmissionDate == null)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                        cmd.Parameters[2].Value = oEmployee.CurrentAdmissionDate;

                    if (oEmployee.CurrentDemissionDate == null)
                        cmd.Parameters[3].Value = DBNull.Value;
                    else
                        cmd.Parameters[3].Value = oEmployee.CurrentDemissionDate;

                    if (oEmployee.Birthday == null)
                        cmd.Parameters[4].Value = DBNull.Value;
                    else
                        cmd.Parameters[4].Value = oEmployee.Birthday;

                    if (String.IsNullOrEmpty(oEmployee.PIS))
                        cmd.Parameters[5].Value = DBNull.Value;
                    else
                        cmd.Parameters[5].Value = oEmployee.PIS;

                    if (String.IsNullOrEmpty(oEmployee.CPF))
                        cmd.Parameters[6].Value = DBNull.Value;
                    else
                        cmd.Parameters[6].Value = oEmployee.CPF;

                    if (oEmployee.Role == null)
                        cmd.Parameters[7].Value = DBNull.Value;
                    else
                    {
                        if (oEmployee.Role.Id <= 0)
                            cmd.Parameters[7].Value = DBNull.Value;
                        else
                            cmd.Parameters[7].Value = oEmployee.Role.Id;
                    }

                    //usando o ID para salvar na tabela de banks
                    obj = dal.ExecuteScalar(cmd);
                    if (obj != null)
                    {
                        idReturned = (long)obj;
                        if (oEmployee.BankData != null)
                        {
                            oEmployee.BankData.EmployeeId = idReturned;
                            bankDao.Insert(oEmployee.BankData);
                        }
                        //Histórico de admissão/demissão/cargo
                        if (oEmployee.AdmissionDemissionHistories.Count > 0)
                            admDemHistDAO.InsertAll(oEmployee.AdmissionDemissionHistories, idReturned);
                    }
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

        public void Update<K>(K id, Employee oEmployee)
        {
            int rowsAffected = -1;
            try
            {
                string updateCMD = "Update employees set \"name\" = :name, \"matriculation\" = :matriculation, \"admission_date\" = :admission_date," +
                "\"demission_date\" = :demission_date, \"birthday\" = :birthday, \"pis\" = :pis, \"cpf\" = :cpf where \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("matriculation", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("admission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("demission_date", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("birthday", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("pis", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cpf", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = oEmployee.Name;
                cmd.Parameters[1].Value = oEmployee.Matriculation;
                cmd.Parameters[2].Value = oEmployee.CurrentAdmissionDate;
                cmd.Parameters[3].Value = oEmployee.CurrentDemissionDate;
                cmd.Parameters[4].Value = oEmployee.Birthday;
                cmd.Parameters[5].Value = oEmployee.PIS;
                cmd.Parameters[6].Value = oEmployee.CPF;

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
                string deleteCMD = String.Format("Delete From employees Where id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(deleteCMD);

            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public System.Windows.Forms.AutoCompleteStringCollection GetEmployeesNames()
        {
            System.Windows.Forms.AutoCompleteStringCollection myCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "SELECT name, matriculation from employees";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    myCollection.Add(reader["name"].ToString() + "(" + reader["matriculation"].ToString() + ")");
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
