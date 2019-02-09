using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using ExcelDataReader;

namespace Contingenciamento
{
    public partial class FrmCadastros : Form
    {
        Facade _facade = new Facade();
        DataSet result;

        public FrmCadastros()
        {
            InitializeComponent();
            this.btnSave.BackColor = Color.FromArgb(0, 149, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt = new DateTime(2018, 5, 20);
                //Funcionario func = new Funcionario(5505, "Bianca Maria", "1022", dt);
                //_funcionarioFacade.InserirFuncionario(func);
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook 97-2003|*.xls|Excel Workbook|*.xlsx", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        using (var fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            txtPlanilha.Text = ofd.FileName;
                            using (var reader = ExcelReaderFactory.CreateReader(fs))
                            {

                                result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                });
                                cboSheet.Items.Clear();
                                foreach (DataTable dt in this.result.Tables)
                                {
                                    this.cboSheet.Items.Add(dt.TableName);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte problema: " + ex.Message.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HashSet<Funcionario> funcList = new HashSet<Funcionario>(new FuncionarioComparer());
            HashSet<Cliente> cliList = new HashSet<Cliente>(new ClienteComparer());
            HashSet<Contrato> contrList = new HashSet<Contrato>(new ContratoComparer());
            HashSet<Unidade> unidList = new HashSet<Unidade>(new UnidadeComparer());
            //HashSet<HistoricoFuncionario> hFuncList = new HashSet<HistoricoFuncionario>(new HistoricoFuncionarioComparer());
            List<HistoricoFuncionario> hFuncList = new List<HistoricoFuncionario>();
            Funcionario func;
            Cliente cli;
            Contrato contr;
            Unidade unid;
            HistoricoFuncionario hFunc;
            //Relativo a informações da Leitura
            int qtdeHistoricoFuncs = 0;
            int linhasRepetidasDecimoSalario = 0;
            int linhasAntesMigracao = 0;

            foreach (DataTable dt in this.result.Tables)
            {
                this.cboSheet.Items.Add(dt.TableName);
                qtdeHistoricoFuncs += dt.Rows.Count;

                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    //só aceita registros a partir de 6/2014
                    if (checkTimeRule(dt.Rows[i][7], dt.Rows[i][8]))
                    {
                        func = new Funcionario();
                        cli = new Cliente();
                        contr = new Contrato();
                        unid = new Unidade(); //passa o numero da linha atual para controle posterior
                        hFunc = new HistoricoFuncionario(func, cli, contr, unid);
                        func.Matriculation = dt.Rows[i][0].ToString();
                        func.Name = dt.Rows[i][1].ToString();
                        
                        if (!(dt.Rows[i][2] is DBNull))
                        {
                            func.DataAdmissao = (DateTime)dt.Rows[i][2];
                        }
                        if (!(dt.Rows[i][3] is DBNull))
                        {
                            func.DataRescisao = (DateTime)dt.Rows[i][3];
                        }
                        //Tratamento do Còdigo de Departamento
                        string strCodDepto = dt.Rows[i][4].ToString();
                        if (strCodDepto.Length % 3 == 2)
                        {
                            strCodDepto = String.Concat("0", strCodDepto);
                        }
                        else if (strCodDepto.Length % 3 == 1)
                        {
                            strCodDepto = String.Concat("00", strCodDepto);
                        }

                        unid.CodigoDepartamento = strCodDepto; //para posterior confronto e inclusao da unidade no Historico

                        if (strCodDepto.Length == 3)//CLI
                        {
                            cli.CodigoSOLL = strCodDepto.Substring(0, 3);
                            cli.Name = dt.Rows[i][5].ToString();

                        }
                        else if (strCodDepto.Length == 6)//CONTR
                        {
                            cli.CodigoSOLL = strCodDepto.Substring(0, 3);
                            contr.CodigoSOLL = strCodDepto.Substring(3, 3);
                            cli.Name = dt.Rows[i][5].ToString();
                            contr.Name = dt.Rows[i][5].ToString();
                            contr.Cliente = cli;

                        }
                        else//UNID
                        {
                            cli.CodigoSOLL = strCodDepto.Substring(0, 3);
                            contr.CodigoSOLL = strCodDepto.Substring(3, 3);
                            unid.CodigoSOLL = strCodDepto.Substring(6, 3);
                            cli.Name = dt.Rows[i][5].ToString();
                            contr.Name = dt.Rows[i][5].ToString();
                            unid.Name = dt.Rows[i][5].ToString();
                            contr.Cliente = cli;
                            unid.Contrato = contr;
                        }

                        hFunc.CodigoDeptoSOLL = strCodDepto;
                        hFunc.NomeDeptoSOLL = dt.Rows[i][5].ToString();
                        //hFunc.SalarioBase = getValidDouble((double)dt.Rows[i][6]);
                        //hFunc.DecimoSalario = getValidDouble((double)dt.Rows[i][15]);
                        hFunc.SalarioBase = (double)dt.Rows[i][6];
                        //hFunc.SalarioLiquido = (double)dt.Rows[i][7]; MUDOU
                        int mes = Convert.ToInt32(dt.Rows[i][7]);
                        int ano = Convert.ToInt32(dt.Rows[i][8]);
                        hFunc.Data = new DateTime(ano, mes, 1);
                        hFunc.EmFerias = dt.Rows[i][9].ToString().ToUpper() == "S" ? true : false;

                        if (!(dt.Rows[i][10] is DBNull))
                        {
                            hFunc.InicioAquisicaoFerias = (DateTime)dt.Rows[i][10];
                        }

                        if (!(dt.Rows[i][11] is DBNull))
                        {
                            hFunc.FimAquisicaoFerias = (DateTime)dt.Rows[i][11];
                        }

                        hFunc.TotalProventos = (double)dt.Rows[i][12];
                        hFunc.SalarioLiquido = (double)dt.Rows[i][13];
                        hFunc.AdicInsalubridade = (double)dt.Rows[i][14];
                        hFunc.AdicPericulosidade = (double)dt.Rows[i][15];
                        hFunc.DecimoSalario = (double)dt.Rows[i][16];
                        hFunc.DecimoSalarioProporcional = (double)dt.Rows[i][17];
                        hFunc.ValorFerias = (double)dt.Rows[i][18];
                        hFunc.FeriasProporcional = (double)dt.Rows[i][19];
                        hFunc.MultaRescisoria = (double)dt.Rows[i][20];

                        if (!funcList.Contains(func))
                            funcList.Add(func);
                        else
                        {
                            if (func.DataRescisao != null)
                            {
                                //Se contiver o elemento e a dataRescisao vier nos dados, vamos add nos attrs
                                bool finded = false;
                                foreach (var f in funcList)
                                {
                                    if (f.Equals(func))
                                    {
                                        finded = true;
                                        f.copyInfo(func);
                                    }
                                }
                                if (!finded)
                                {
                                    funcList.Add(func);
                                }
                            }
                        }

                        if (!cliList.Contains(cli))
                            cliList.Add(cli);

                        if (contr.Cliente != null) //Não teve contrato associado
                        {
                            if (!contrList.Contains(contr))
                                contrList.Add(contr);
                        }

                        if (unid.Contrato != null) //Não teve Unidade associada
                        {
                            if (!unidList.Contains(unid))
                                unidList.Add(unid);
                        }

                        if (hFuncList.Contains(hFunc))
                        {
                            //Se contiver o elemento, vasculhar os eventos e alterar o objeto.
                            bool finded = false;
                            foreach (var histFunc in hFuncList)
                            {
                                if (histFunc.Equals(hFunc))
                                {
                                    finded = true;
                                    histFunc.copyWorkerFinancialEvents(hFunc);
                                    linhasRepetidasDecimoSalario++;
                                }
                            }
                            if (!finded)
                            {
                                hFuncList.Add(hFunc);
                            }
                        }
                        else
                        {
                            hFuncList.Add(hFunc);
                        }
                    }
                    else
                    {
                        linhasAntesMigracao++;
                    }
                }
            }
            
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Dados carregados com sucesso: ");
            strBuilder.Append("Quantidade de Linhas de Histórico: ");
            strBuilder.Append(qtdeHistoricoFuncs);
            strBuilder.AppendLine();
            strBuilder.Append("Quantidade de Linhas Repetidas por 13o salário: ");
            strBuilder.Append(linhasRepetidasDecimoSalario);
            strBuilder.AppendLine();
            strBuilder.Append("Quantidade de Linhas Antes da Migração RH3: ");
            strBuilder.Append(linhasAntesMigracao);
            strBuilder.AppendLine();
            strBuilder.Append("Quantidade de Linhas de Histórico Salvas na Base de Dados: ");
            strBuilder.Append(qtdeHistoricoFuncs - linhasRepetidasDecimoSalario - linhasAntesMigracao);

            try
            {
                _facade.InserirFuncionarioList(funcList);
                Funcionario tempFuncionario;
                foreach (var funcionario in funcList)
                {
                    tempFuncionario = _facade.GetFuncionarioByMatricula(funcionario.Matriculation);
                    funcionario.Id = tempFuncionario.Id;
                    foreach (var histFunc in hFuncList)
                    {
                        if (histFunc.Funcionario.Matriculation.Equals(funcionario.Matriculation))
                        {
                            histFunc.Funcionario.Id = funcionario.Id;
                        }
                    }
                }
                _facade.InserirClienteList(cliList); //o ideal seria pegar cada ID gerado e colocar no objeto Cliente da CliList passada por parametro
                //atualizar a lista de clientes com o ID gerado no banco
                //por algum motivo os Client que foram lidos pelo Excel e os Client da CliList não estão
                //sendo referenciados automaticamente para o mesmo espaço de memória, o que causa inconsistência na hora de atualizar
                //o histFunc...
                Cliente findedClient = null;
                foreach (var client in cliList)
                {
                    findedClient = _facade.GetClienteByIDSOLL(client.CodigoSOLL);
                    if (findedClient != null)
                    {
                        client.copyInfo(findedClient);
                    }
                    foreach (var histFunc in hFuncList)
                    {
                        if (histFunc.Cliente.CodigoSOLL.Equals(client.CodigoSOLL))
                        {
                            histFunc.Cliente.copyInfo(client);
                        }
                    }
                }
                //Tem que pegar de volta os que foram salvos no banco para representar o ID deles aqui e salvar
                //na tabela do Contrato e do HistoricoFuncionario.
                _facade.InserirContratoList(contrList);
                Contrato findedContrato = null;
                foreach (var contrato in contrList)
                {
                    findedContrato = _facade.GetContratoByIDSOLL(contrato.Cliente.Id, contrato.CodigoSOLL);
                    if (findedContrato != null)
                    {
                        contrato.copyInfo(findedContrato);
                    }
                    foreach (var histFunc in hFuncList)
                    {
                        if (histFunc.Contrato.Equals(contrato))
                        {
                            histFunc.Contrato.copyInfo(contrato);
                        }
                    }
                }
                _facade.InserirUnidadeList(unidList);
                Unidade findedUnidade = null;
                foreach (var unidade in unidList)
                {
                    findedUnidade = _facade.GetUnidadeByKey(unidade.Contrato.Id, unidade.CodigoSOLL);
                    if (findedUnidade != null)
                    {
                        unidade.copyInfo(findedUnidade);
                    }
                    foreach (var histFunc in hFuncList)
                    {
                        if (histFunc.Unidade.Equals(unidade))
                        {
                            histFunc.Unidade.copyInfo(unidade);
                        }
                    }
                }
                /*Unidade tempUnid;
                foreach (var unidade in unidList)
                {
                    tempUnid = _facade.GetUnidadeByKey(unidade.Contrato.Id, unidade.CodigoSOLL);
                    unidade.Id = tempUnid.Id;
                    unidade.Name = tempUnid.Name;
                    unidade.CodigoSOLL = tempUnid.CodigoSOLL;
                    foreach (var histFunc in hFuncList)
                    {
                        if (histFunc.Unidade.CodigoDepartamento.Equals(unidade.CodigoDepartamento))
                        {
                            histFunc.Unidade = unidade;
                        }
                    }
                }*/
                _facade.InserirHistoricoFuncionarioList(hFuncList);
                DialogResult dr = MessageBox.Show(strBuilder.ToString(), "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //atualizar
            /*Funcionario novoFunc = new Funcionario(2202, "Juliano Lopes", "0002", new DateTime(2018, 5, 28));
            _funcionarioFacade.UpdateFuncionario(1, novoFunc);
            buscar();
            
            //Remover
            _funcionarioFacade.DeleteFuncionario(1);
            buscar();
            */
        }

        private bool checkTimeRule(object mes, object ano)
        {
            double dAno = (double)ano;
            double dMes = (double)mes;
            bool flag = false;

            if (dAno > 2014)
                flag = true;
            else if (dAno == 2014)
                if (dMes >= 6)
                    flag = true;

            return flag;
        }

        private double getValidDouble(double fromValue)
        {
            string value = fromValue.ToString();
            return double.Parse(value.Replace(",", "."));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void buscar()
        {
            List<Funcionario> funcs = _facade.GetTopFuncionario();
            var source = new BindingSource();
            source.DataSource = funcs;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[2].HeaderText = "Nome";
            dataGridView1.Columns[3].HeaderText = "Matrícula";
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboSheet.SelectedIndex >= result.Tables.Count))
                dataGridView1.DataSource = result.Tables[cboSheet.SelectedIndex];
            else
                MessageBox.Show("Planilha não existente.", "Erro de Seleção de Planilha", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
