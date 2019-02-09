using System;
using System.Collections.Generic;
using Npgsql;
using Contingenciamento.Entidades;


namespace Contingenciamento.DAO
{
    public class FuncionarioDAO : IAcessoDadosObject<Funcionario>
    {
        private DAOHelper dal = new DAOHelper();
        public Funcionario Get<K>(K id)
        {

            Funcionario funcionario = new Funcionario();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSeleciona = "Select * from funcionario Where id = " + id;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    funcionario.Id = Convert.ToInt32(reader["id"]);
                    funcionario.IdSoll = Convert.ToInt32(reader["id_soll"]);
                    funcionario.Name = reader["nome"].ToString();
                    funcionario.Matriculation = reader["matricula"].ToString();
                    funcionario.DataAdmissao = Convert.ToDateTime(reader["data_admissao"]);
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
            return funcionario;
        }

        public Funcionario GetByMatricula<K>(K matricula)
        {

            Funcionario funcionario = new Funcionario();
            NpgsqlDataReader reader = null;
            try
            {
                string cmdSeleciona = "Select * from funcionario Where matricula = '"+matricula+"'";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    funcionario.Id = Convert.ToInt32(reader["id"]);
                    funcionario.IdSoll = Convert.ToInt32(reader["id_soll"]);
                    funcionario.Name = reader["nome"].ToString();
                    funcionario.Matriculation = reader["matricula"].ToString();
                    funcionario.DataAdmissao = Convert.ToDateTime(reader["data_admissao"]);
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
            return funcionario;
        }

        public List<Funcionario> GetTop()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "select * from funcionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Id = Convert.ToInt32(reader["id"]);
                    funcionario.IdSoll = Convert.ToInt32(reader["id_soll"]);
                    funcionario.Name = reader["nome"].ToString();
                    funcionario.Matriculation = reader["matricula"].ToString();
                    funcionario.DataAdmissao= Convert.ToDateTime(reader["data_admissao"]);
                    funcionarios.Add(funcionario);
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
            return funcionarios;
        }

        public void Insert(Funcionario oFuncionario)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = String.Format("Insert Into funcionario(nome,id_soll,matricula,data_admissao,data_rescisao) values('{0}','{1}','{2}','{3}','{4}')", 
                    oFuncionario.Name, oFuncionario.IdSoll, oFuncionario.Matriculation, oFuncionario.DataAdmissao, oFuncionario.DataRescisao);
                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdInserir);
            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public void BulkInsert(HashSet<Funcionario> funcList)
        {
            string cmdInserir;
            dal.OpenConnection();
            foreach (var func in funcList)
            {
                cmdInserir = String.Format("Insert Into funcionario(nome,id_soll,matricula,data_admissao,data_rescisao) values('{0}','{1}','{2}','{3}','{4}')",
                    func.Name, func.IdSoll, func.Matriculation, func.DataAdmissao, func.DataRescisao);
                dal.ExecuteNonQuery(cmdInserir);
            }
        }

        public void Update<K>(K id, Funcionario oFuncionario)
        {
            int rowsAffected = -1;
            try
            {                
                //string cmdInserir = String.Format("Insert Into funcionarios(nome,id_soll,matricula,data_admissao) values('{0}','{1}','{2}', '{3}')",
                //    oFuncionario.Name, oFuncionario.IdSoll, oFuncionario.Matriculation, oFuncionario.DataAdmissao);

                NpgsqlCommand cmd = new NpgsqlCommand("Update funcionario set \"nome\" = :name, \"id_soll\" = :idSoll, \"matricula\" = :matricula," +
                "\"data_admissao\" = :dataAdmissao where \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("idSoll", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("matricula", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("dataAdmissao", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters[0].Value = oFuncionario.Name;
                cmd.Parameters[1].Value = oFuncionario.IdSoll;
                cmd.Parameters[2].Value = oFuncionario.Matriculation;
                cmd.Parameters[3].Value = oFuncionario.DataAdmissao;

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
                string cmdDeletar = String.Format("Delete From funcionario Where id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdDeletar);

            }
            finally
            {
                this.dal.CloseConection();
            }

            //return rowsAffected;
        }

        public System.Windows.Forms.AutoCompleteStringCollection GetNomesFuncionarios()
        {
            System.Windows.Forms.AutoCompleteStringCollection myCollection = new System.Windows.Forms.AutoCompleteStringCollection();

            NpgsqlDataReader reader = null;
            try
            {
                string query = "select nome, matricula from funcionario";
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(query);

                while (reader.Read())
                {                    
                    myCollection.Add(reader["nome"].ToString() + "(" + reader["matricula"].ToString() + ")");
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
