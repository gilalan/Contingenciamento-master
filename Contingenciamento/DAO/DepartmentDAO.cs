using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class DepartmentDAO
    {
        private DAOHelper dal = new DAOHelper();

        public Department Get<K>(K id)
        {
            Department department = new Department();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT * FROM departments WHERE id = " + id + " ORDER BY code";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    department.Id = Convert.ToInt64(reader["id"]);
                    department.Name = reader["name"].ToString();
                    department.Code = reader["code"].ToString();
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
            return department;
        }

        public Department GetByCode(string code)
        {
            Department department = null;
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "SELECT * FROM departments WHERE code = '" + code + "'";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    department = new Department();
                    department.Id = Convert.ToInt64(reader["id"]);
                    department.Name = reader["name"].ToString();
                    department.Code = reader["code"].ToString();
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
            return department;
        }

        public List<Department> GetTop()
        {
            List<Department> departments = new List<Department>();
            NpgsqlDataReader reader = null;
            try
            {
                //string query = "SELECT dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, " +
                //"ct.id as ct_id, ct.name as ct_name " +
                //"FROM (departments dep LEFT JOIN contracts ct ON (dep.contract_id = ct.id)) " +
                //"ORDER BY dep.id";
                string query = "SELECT dep.id as dep_id, dep.name as dep_name, dep.code as dep_code " +
                    "FROM departments dep ORDER BY dep.id";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Department department = new Department();
                    department.Id = Convert.ToInt64(reader["dep_id"]);
                    department.Name = reader["dep_name"].ToString();
                    department.Code = reader["dep_code"].ToString();
                    
                    departments.Add(department);
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
            return departments;
        }

        public long Insert(Department department)
        {
            //int rowsAffected = -1;
            object obj = null;
            long returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO departments (name, code) VALUES (:name, :code) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = department.Name;
                cmd.Parameters[1].Value = department.Code;

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

        public int BulkInsert(HashSet<Department> departmentList)
        {
            int count = 0;
            try
            {
                string cmdInsert = "INSERT INTO departments (name, code) VALUES (:name, :code) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));
                int rowsAffected = -1;

                dal.OpenConnection();
                foreach (var department in departmentList)
                {
                    cmd.Parameters[0].Value = department.Name;
                    cmd.Parameters[1].Value = department.Code;
                    
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

        public void Update<K>(K id, Department department)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE departments SET \"name\" = :name, \"code\" = :code"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("code", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = department.Name;
                cmd.Parameters[1].Value = department.Code;

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
                string cmdDelete = String.Format("DELETE FROM departments WHERE id = '{0}'", id);

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
