using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContratoAliquotaDAO : IAcessoDadosObject<ContratoAliquota>
    {
        private DAOHelper dal = new DAOHelper();

        public ContratoAliquota Get<K>(K id)
        {
            string cmdSeleciona = "SELECT cont_ali.id as cont_ali_id, cont.id as cont_id, "
                + "cont.nome as cont_name, cont.codigo as cont_codigo, "
                + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                + "cont.inicio as cont_inicio, cont.termino as cont_termino, "
                + "verb.id as verb_id, verb.nome as verb_nome, verb.codigo as verb_codigo, verb.primaria as verb_prim "
                + "cont_ali.aliquota as cont_ali_aliquota, cont_ali.ano as cont_ali_ano "
                + "FROM (contrato_aliquotas cont_ali LEFT JOIN contrato cont ON "
                + "(cont_ali.id_contrato = cont.id)) "
                + "INNER JOIN verbas verb ON (cont_ali.id_verba = verb.id) "
                + "INNER JOIN cliente cli ON (cont_ali.id_cliente = cli.id) "
                + "WHERE cont_ali.id = " + id + " ORDER BY cont_aliq.ano ASC";

            ContratoAliquota contratoAliquota = new ContratoAliquota();
            NpgsqlDataReader reader = null;
            try
            {
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                if (reader.Read())
                {
                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_id_soll"].ToString(), reader["cli_nome"].ToString());

                    Contrato contr = new Contrato(reader["cont_nome"].ToString(), reader["cont_id_soll"].ToString(), cli);

                    //Unidade unidade = null;
                    //if (reader["und_id"] != null)
                    //{
                    //    unidade = new Unidade(reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                    //    unidade.Contrato = contr;
                    //}

                    Verba verba = new Verba(Convert.ToInt32(reader["verb_id"]), Convert.ToInt32(reader["verb_codigo"]),
                        reader["verb_nome"].ToString(), Convert.ToBoolean(reader["verb_prim"]));

                    contratoAliquota.Id = Convert.ToInt32(reader["cont_ali_id"]);
                    contratoAliquota.Ano = Convert.ToInt32(reader["cont_ali_ano"]);
                    contratoAliquota.Aliquota = Convert.ToDouble(reader["cont_ali_aliquota"]);
                    contratoAliquota.Contrato = contr;
                    contratoAliquota.Verba = verba;

                    //if (unidade != null)
                    //{
                    //    contratoAliquota.Contrato.Unidade = unidade;
                    //}
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
            return contratoAliquota;
        }        

        public List<ContratoAliquota> GetTop()
        {
            string cmdSeleciona = "SELECT cont_ali.id as cont_ali_id, cont.id as cont_id, "
                 + "cont.nome as cont_nome, cont.codigo as cont_codigo, cont.id_soll as cont_id_soll, "
                 + "cli.id as cli_id, cli.nome as cli_nome, cli.id_soll as cli_id_soll, "
                 + "cont.inicio as cont_inicio, cont.termino as cont_termino, "
                 + "verb.id as verb_id, verb.nome as verb_nome, verb.codigo as verb_codigo, verb.primaria as verb_prim, "
                 + "cont_ali.aliquota as cont_ali_aliquota, cont_ali.ano as cont_ali_ano "
                 + "FROM (contrato_aliquotas cont_ali LEFT JOIN contrato cont ON "
                 + "(cont_ali.id_contrato = cont.id)) "
                 + "INNER JOIN verbas verb ON (cont_ali.id_verba = verb.id) "
                 + "INNER JOIN cliente cli ON (cont_ali.id_cliente = cli.id) "
                 + "ORDER BY cont_ali.ano ASC";

            List<ContratoAliquota> contratoAliquotas = new List<ContratoAliquota>();
            NpgsqlDataReader reader = null;

            try
            {
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSeleciona);

                while (reader.Read())
                {
                    ContratoAliquota contratoAliquota = new ContratoAliquota();

                    Verba verba = new Verba(Convert.ToInt32(reader["verb_id"]), Convert.ToInt32(reader["verb_codigo"]), 
                        reader["verb_nome"].ToString(), Convert.ToBoolean(reader["verb_prim"]));

                    Cliente cli = new Cliente(Convert.ToInt32(reader["cli_id"]),
                        reader["cli_id_soll"].ToString(), reader["cli_nome"].ToString());

                    Contrato contr = null;
                    if (!(reader["cont_id"] is DBNull) && !(reader["cont_nome"] is DBNull) && !(reader["cont_id_soll"] is DBNull))
                        contr = new Contrato(Convert.ToInt32(reader["cont_id"]), reader["cont_nome"].ToString(),
                            reader["cont_id_soll"].ToString(), cli);

                    //Unidade unidade = null;
                    //if (contr != null && !(reader["und_id"] is DBNull))
                    //{
                    //    unidade = new Unidade(Convert.ToInt32(reader["und_id"]),
                    //        reader["und_nome"].ToString(), reader["und_id_soll"].ToString());
                    //    unidade.Contrato = contr;
                    //}

                    contratoAliquota.Id = Convert.ToInt32(reader["cont_ali_id"]);
                    contratoAliquota.Ano = Convert.ToInt32(reader["cont_ali_ano"]);
                    contratoAliquota.Aliquota = Convert.ToDouble(reader["cont_ali_aliquota"]);
                    contratoAliquota.Cliente = cli;
                    contratoAliquota.Contrato = contr;
                    contratoAliquota.Verba = verba;

                    //if (unidade != null)
                    //{
                    //    contratoAliquota.Unidade = unidade;
                    //}
                    contratoAliquotas.Add(contratoAliquota);
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
            return contratoAliquotas;
        }

        public void Insert(ContratoAliquota objContratoAliquota)
        {
            int rowsAffected = -1;
            try
            {
                string cmdInserir = "INSERT INTO contrato_aliquotas(id_contrato, id_verba, aliquota, ano, id_cliente) "
                    + "VALUES (:idContrato, :idVerba, :aliquota, :ano, :idCliente)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idVerba", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("aliquota", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("ano", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));

                int index = 0;

                if (objContratoAliquota.Contrato == null)
                    cmd.Parameters[index].Value = DBNull.Value;
                else
                    cmd.Parameters[index].Value = objContratoAliquota.Contrato.Id;

                if (objContratoAliquota.Verba == null)
                    cmd.Parameters[++index].Value = DBNull.Value;
                else
                    cmd.Parameters[++index].Value = objContratoAliquota.Verba.Id;
                
                cmd.Parameters[++index].Value = objContratoAliquota.Aliquota;                
                cmd.Parameters[++index].Value = objContratoAliquota.Ano;

                if (objContratoAliquota.Cliente == null)
                    cmd.Parameters[++index].Value = DBNull.Value;
                else
                    cmd.Parameters[++index].Value = objContratoAliquota.Cliente.Id;

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
        }

        public void BulkInsert(HashSet<ContratoAliquota> contratoAliquotaList)
        {
            try
            {
                string cmdInserir = "INSERT INTO contrato_aliquotas(id_contrato, id_verba, aliquota, ano, id_cliente) "
                    + "VALUES (:idContrato, :idVerba, :aliquota, :ano, :idCliente)";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInserir);

                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idVerba", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("aliquota", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("ano", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));

                dal.OpenConnection();
                int index = 0;
                foreach (var objContratoAliquota in contratoAliquotaList)
                {
                    index = 0;

                    if (objContratoAliquota.Contrato == null)
                        cmd.Parameters[index].Value = DBNull.Value;
                    else
                        cmd.Parameters[index].Value = objContratoAliquota.Contrato.Id;

                    if (objContratoAliquota.Verba == null)
                        cmd.Parameters[++index].Value = DBNull.Value;
                    else
                        cmd.Parameters[++index].Value = objContratoAliquota.Verba.Id;

                    cmd.Parameters[++index].Value = objContratoAliquota.Aliquota;
                    cmd.Parameters[++index].Value = objContratoAliquota.Ano;

                    if (objContratoAliquota.Cliente == null)
                        cmd.Parameters[++index].Value = DBNull.Value;
                    else
                        cmd.Parameters[++index].Value = objContratoAliquota.Cliente.Id;

                    dal.ExecuteNonQuery(cmd);
                }
            }
            finally
            {
                this.dal.CloseConection();
            }

        }

        public void Update<K>(K id, ContratoAliquota objContratoAliquota)
        {
            int rowsAffected = -1;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE contrato_aliquotas SET \"id_contrato\" = :idContrato, " +
                    "\"id_verba\" = :idVerba, \"aliquota\" = :aliquota, \"ano\" = :ano, \"id_cliente\" = :idCliente " +
                    "WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("idContrato", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idVerba", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("aliquota", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("ano", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("idCliente", NpgsqlTypes.NpgsqlDbType.Integer));

                cmd.Parameters[0].Value = objContratoAliquota.Contrato.Id;
                cmd.Parameters[1].Value = objContratoAliquota.Verba.Id;
                cmd.Parameters[2].Value = objContratoAliquota.Aliquota;
                cmd.Parameters[3].Value = objContratoAliquota.Ano;
                cmd.Parameters[4].Value = objContratoAliquota.Cliente.Id;

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
                string cmdDeletar = String.Format("Delete From contrato_aliquotas Where id = '{0}'", id);

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
