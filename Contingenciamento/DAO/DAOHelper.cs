using System;
using Npgsql;
using System.Windows.Forms;
using Contingenciamento.Exceptions;

namespace Contingenciamento.DAO
{
    public class DAOHelper
    {
        string server = Properties.Settings.Default.Server;
        string port = Properties.Settings.Default.Port;
        string database = Properties.Settings.Default.Database;
        string userId = Properties.Settings.Default.User;
        string userPassword = Properties.Settings.Default.Password;

        public NpgsqlConnection conexaoBD { get; set; }
        public string stringConexaoBD { get; set; }

        public DAOHelper()
        {
            this.stringConexaoBD = string.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};",
                                                                    server, port, database, userId, userPassword);
            this.conexaoBD = new NpgsqlConnection(this.stringConexaoBD);
        }

        public DAOHelper(string stringConexaoBD)
        {
            this.conexaoBD = new NpgsqlConnection(this.stringConexaoBD);
        }

        public static DAOHelper Create()
        {
            return new DAOHelper();
        }

        public static DAOHelper Create(string stringConexaoBD)
        {
            return new DAOHelper(stringConexaoBD);
        }

        public void OpenConnection()
        {
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
            }
            catch (PostgresException pgEx) 
            {
                if (pgEx.SqlState == "28P01")//Autenticação de senha falhou
                {
                    MessageBox.Show("Não foi possível autenticar-se junto ao banco de dados. Possivel causa: senha incorreta", "Erro de Autenticação",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                else
                {
                    MessageBox.Show(pgEx.Message, "Erro de Conexão do Banco de Dados",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro de Conexão",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        public void CloseConection()
        {
            this.conexaoBD.Close();
        }

        public NpgsqlDataReader ExecuteDataReader(string sql)
        {
            NpgsqlDataReader dr = null;
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
                NpgsqlCommand cmd = new NpgsqlCommand(sql, this.conexaoBD);
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (PostgresException ngEx)
            {
                if (ngEx.SqlState == "23505")//item duplicado
                {
                    if (ngEx.ConstraintName.Equals("unq_code_dept"))
                    {
                        throw new ItemAlreadyExists("O código de departamento passado já existe na base de dados.");
                    }
                    return dr;
                }
                else
                    throw ngEx;
            }
        }

        public NpgsqlDataReader ExecuteDataReader(NpgsqlCommand cmd)
        {
            NpgsqlDataReader dr = null;
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
                cmd.Connection = this.conexaoBD;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (PostgresException ngEx)
            {
                if (ngEx.SqlState == "23505")//item duplicado
                {
                    if (ngEx.ConstraintName.Equals("unq_code_dept"))
                    {
                        throw new ItemAlreadyExists("O código de departamento passado já existe na base de dados.");
                    }
                    return dr;
                }
                else
                    throw ngEx;
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            int rowsAffected = 0;
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
                NpgsqlCommand cmd = new NpgsqlCommand(sql, this.conexaoBD);
                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (PostgresException ngEx)
            {
                if (ngEx.SqlState == "23505")//item duplicado
                {
                    if (ngEx.ConstraintName.Equals("unq_code_dept"))
                    {
                        throw new ItemAlreadyExists("O código de departamento passado já existe na base de dados.");
                    }
                }
                if (ngEx.SqlState == "22P02")
                {
                    return rowsAffected;
                }
                else       
                    throw ngEx;
            }
            
        }

        public int ExecuteNonQuery(NpgsqlCommand cmd)
        {
            int rowsAffected = 0;
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
                cmd.Connection = this.conexaoBD;
                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (PostgresException pEx)
            {
                if (pEx.SqlState == "23505")//item duplicado
                {
                    if (pEx.ConstraintName.Equals("unq_code_dept"))
                    {
                        throw new ItemAlreadyExists("O código de departamento passado já existe na base de dados.");
                    }
                }
                else
                    throw pEx;
            }            
            return rowsAffected;
        }

        public object ExecuteScalar(NpgsqlCommand cmd)
        {
            object objReturned = null;
            try
            {
                if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
                {
                    this.conexaoBD.Open();
                }
                cmd.Connection = this.conexaoBD;
                objReturned = cmd.ExecuteScalar();
                return objReturned;
            }
            catch (PostgresException pEx)
            {
                if (pEx.SqlState == "23505")//item duplicado
                {                  
                    if (pEx.ConstraintName.Equals("unq_code_dept"))
                    {
                        throw new ItemAlreadyExists("O código de departamento passado já existe na base de dados.");
                    }
                    if (pEx.ConstraintName.Equals("unq_multiple_emp_epoch_vacation"))
                    {
                        return objReturned;
                    }
                }
                else
                    throw pEx;
            }
            return objReturned;
        }
    }
}
