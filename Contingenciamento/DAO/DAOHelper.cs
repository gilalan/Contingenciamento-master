using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

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
            if (this.conexaoBD.State == System.Data.ConnectionState.Closed)
            {
                this.conexaoBD.Open();
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
                    return rowsAffected;
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
                    if (pEx.TableName.Equals("contrato_aliquotas"))
                    {
                        pEx.MessageText = "Item já existente na tabela, favor modificar os atributos de Cliente, Contrato, Verba ou Ano.";
                        throw pEx;
                    }
                    return rowsAffected;
                }
                else
                    throw pEx;
            }            
        }
    }
}
