using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class RoleDAO : IDataAccessObject<Role>
    {
        private DAOHelper dal = new DAOHelper();

        public Role Get<K>(K id)
        {
            Role role = new Role();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSelect = "Select * from roles Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    role.Id = Convert.ToInt32(reader["id"]);
                    role.Name = reader["name"].ToString();
                    role.CBOCode = reader["cbo"].ToString();
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
            return role;
        }

        public List<Role> GetTop()
        {
            List<Role> roles = new List<Role>();
            NpgsqlDataReader reader = null;
            try
            {
                string query = "select * from roles";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Role role = new Role();
                    role.Id = Convert.ToInt32(reader["id"]);
                    role.Name = reader["name"].ToString();
                    role.CBOCode = reader["cbo"].ToString();

                    roles.Add(role);
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
            return roles;
        }

        public void Insert(Role role)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInsert = "INSERT INTO roles(name, cbo) VALUES (:name, :cbo)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cbo", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = role.Name;
                if (role.CBOCode == null)
                    cmd.Parameters[1].Value = DBNull.Value;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<Role> roleList)
        {
            try
            {
                string cmdInsert = "INSERT INTO roles (name, cbo) VALUES (:name, :cbo)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cbo", NpgsqlTypes.NpgsqlDbType.Text));

                dal.OpenConnection();
                foreach (var role in roleList)
                {
                    cmd.Parameters[0].Value = role.Name;
                    if (role.CBOCode == null)
                        cmd.Parameters[1].Value = DBNull.Value;

                    dal.ExecuteNonQuery(cmd);
                }

            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void Update<K>(K id, Role role)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE roles set \"name\" = :name, \"cbo\" = :cbo"
                    + " WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("cbo", NpgsqlTypes.NpgsqlDbType.Text));

                cmd.Parameters[0].Value = role.Name;
                cmd.Parameters[1].Value = role.CBOCode;

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
                string cmdDelete = String.Format("Delete From roles Where id = '{0}'", id);

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
