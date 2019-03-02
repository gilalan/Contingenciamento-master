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
    public partial class FrmInsertHistoryEmployee : Form
    {
        Facade _facade = new Facade();
        DataSet result;
        Contract contract;

        HashSet<EmployeeHistory> employeeHistories;

        //Lista com entidades recuperadas do banco de dados
        List<Department> allDepartments;
        List<Role> allRoles;
        List<Employee> allEmployees;
        List<Contract> allContracts;
        List<EmployeeHistory> allEmployeeHistory;

        //Novas entidades a serem cadastradas
        HashSet<Department> newDepartments;
        HashSet<Employee> newEmployees;


        public FrmInsertHistoryEmployee()
        {
            InitializeComponent();
        }

        private void FrmInsertHistoryEmployee_Load(object sender, EventArgs e)
        {
            allDepartments = _facade.GetTopDepartment();
            allRoles = _facade.GetTopRole();
            allEmployees = _facade.GetTopEmployee();
            allContracts = _facade.GetOnlyContracts();
            _FillContractsCB(allContracts);

            if (allContracts.Count == 0)
            {
                MessageBox.Show("Atenção: a base de dados não possui registros de Contratos. Você precisa cadastrar o Contrato que receberá a planilha de Histórico",
                    "Nenhum contrato cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _EnableAllButons(false);
            }

            if (allRoles.Count == 0)
            {
                MessageBox.Show("Atenção: a base de dados não possui registros de cargos dos funcionários. O primeiro passo " +
                    "para o cadastro das entidades relacionadas ao Funcionário é o cadastro dos Cargos/Funções que eles ocupam.",
                    "Tabela de Cargos dos Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void _FillContractsCB(List<Contract> contracts)
        {
            var source = new BindingSource();
            //monetaryFunds.Insert(0, new MonetaryFund());
            source.DataSource = contracts;
            this.cbContracts.DataSource = source;
            this.cbContracts.DisplayMember = "Name";
            this.cbContracts.ValueMember = "Id";
        }

        //Import worksheet
        private void btnImportWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
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
                                if (dataGridView1.DataSource != null)
                                    dataGridView1.DataSource = null;
                                else
                                    dataGridView1.Rows.Clear();
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
            finally
            {
                this.txtOutput.Text = "";
                //this.txtPlanilha.Text = "";
            }
        }

        //Processar os dados da planilha e prepará-los nas classes para salvar na BD posteriormente
        private void btnProcess_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (this.result.Tables.Count > 0)
                {
                    if (cboSheet.SelectedIndex == -1)
                    {
                        MessageBox.Show("Antes de processar, escolha uma planilha na caixa de seleção de planilhas.", "Selecione uma Planilha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        this.employeeHistories = new HashSet<EmployeeHistory>(new EmployeeHistoryComparer());
                        List<DataRow> invalidLinesSet = new List<DataRow>();
                        List<DataRow> preDatesLinesSet = new List<DataRow>();
                        EmployeeHistory employeeHistory;
                        Employee employee;
                        Department department;
                        DataTable worksheet = this.result.Tables[cboSheet.SelectedIndex];
                        int lines = worksheet.Rows.Count;
                        string empName, empMatriculation, depCode, depName;
                        DateTime empAdmDate, empDemDate;
                        int mes;
                        int ano;
                        this.pbProcess.Maximum = lines;

                        for (var i = 0; i < lines; i++)
                        {
                            employeeHistory = new EmployeeHistory();
                            employee = new Employee();
                            department = new Department();
                            empMatriculation = empName = depCode = depName = "";
                            empAdmDate = empDemDate = DateTime.MinValue;

                            if (_CheckValidLine(worksheet.Rows[i]))
                            {
                                //só aceita registros a partir de 6/2014
                                if (_CheckTimeRule(worksheet.Rows[i][8], worksheet.Rows[i][9]))
                                {
                                    if (!String.IsNullOrEmpty(worksheet.Rows[i][1].ToString()))
                                    {
                                        empMatriculation = _FormatMatriculation(worksheet.Rows[i][1].ToString());
                                    }

                                    if (!String.IsNullOrEmpty(worksheet.Rows[i][2].ToString()))
                                    {
                                        empName = worksheet.Rows[i][2].ToString();
                                    }

                                    if (!(worksheet.Rows[i][3] is DBNull))
                                    {
                                        empAdmDate = (DateTime)worksheet.Rows[i][3];
                                        //employeeHistory.Employee.CurrentAdmissionDate = (DateTime)worksheet.Rows[i][3];
                                    }

                                    if (!(worksheet.Rows[i][4] is DBNull))
                                    {
                                        empDemDate = (DateTime)worksheet.Rows[i][4];
                                        //employeeHistory.Employee.CurrentDemissionDate = (DateTime)worksheet.Rows[i][4];
                                    }

                                    if (!String.IsNullOrEmpty(worksheet.Rows[i][5].ToString()))
                                    {
                                        depCode = _FormatDeptCode(worksheet.Rows[i][5].ToString());
                                    }
                                    if (!String.IsNullOrEmpty(worksheet.Rows[i][6].ToString()))
                                    {
                                        depName = worksheet.Rows[i][6].ToString();
                                    }

                                    employeeHistory.BaseSalary = (double)worksheet.Rows[i][7];
                                    mes = Convert.ToInt32(worksheet.Rows[i][8]);
                                    ano = Convert.ToInt32(worksheet.Rows[i][9]);
                                    employeeHistory.Epoch = new DateTime(ano, mes, 1);
                                    employeeHistory.InVacation = worksheet.Rows[i][10].ToString().ToUpper() == "S" ? true : false;

                                    if (!(worksheet.Rows[i][11] is DBNull))
                                    {
                                        employeeHistory.StartVacationTaken = (DateTime)worksheet.Rows[i][11];
                                    }

                                    if (!(worksheet.Rows[i][12] is DBNull))
                                    {
                                        employeeHistory.EndVacationTaken = (DateTime)worksheet.Rows[i][12];
                                    }

                                    employeeHistory.TotalEarnings = (double)worksheet.Rows[i][13];
                                    employeeHistory.NetSalary = (double)worksheet.Rows[i][14];
                                    employeeHistory.HazardAdditional = (double)worksheet.Rows[i][15];
                                    employeeHistory.DangerousnessAdditional = (double)worksheet.Rows[i][16];
                                    employeeHistory.ThirteenthSalary = (double)worksheet.Rows[i][17];
                                    employeeHistory.ThirteenthProportionalSalary = (double)worksheet.Rows[i][18];
                                    employeeHistory.VacationPay = (double)worksheet.Rows[i][19];
                                    employeeHistory.VacationProportionalPay = (double)worksheet.Rows[i][20];
                                    employeeHistory.PenaltyRescission = (double)worksheet.Rows[i][21];
                                    employeeHistory.Contract = this.contract;
                                    employeeHistory.Processed = false;

                                    //Caso não encontre o Employee na base de dados, insere ele no banco com as informações limitadas
                                    employeeHistory.Employee = _GetEmployeeByMatriculation(empMatriculation);
                                    if (employeeHistory.Employee == null)
                                    {
                                        employee = new Employee(empName, empMatriculation, empAdmDate);
                                        employee.AdmissionDemissionHistories.Add(new AdmissionDemissionHistory(empAdmDate, empMatriculation));
                                        employee.Id = _facade.InsertEmployee(employee);
                                        if (employee.Id > 0)
                                        {
                                            allEmployees.Add(employee);
                                        }
                                        employeeHistory.Employee = employee;
                                    }

                                    employeeHistory.Department = _GetDeptByCode(depCode);
                                    if (employeeHistory.Department == null)
                                    {
                                        department = new Department(depCode, depName);
                                        department.Id = _facade.InsertDepartment(department);
                                        if (department.Id > 0)
                                        {
                                            allDepartments.Add(department);
                                        }
                                        employeeHistory.Department = department;
                                        //invalidLinesSet.Add(worksheet.Rows[i]);
                                        //continue;
                                    }

                                    this.employeeHistories.Add(employeeHistory);
                                }
                                else
                                {
                                    preDatesLinesSet.Add(worksheet.Rows[i]);
                                }
                            }
                            else
                            {
                                invalidLinesSet.Add(worksheet.Rows[i]);
                            }

                            this.pbProcess.Increment(1);
                        }

                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.AppendLine("Dados de informação do HISTÓRICO de FUNCIONÁRIOS processados com sucesso!");
                        strBuilder.Append("Quantidade de Histórico de Funcionário carregada na memória: ");
                        strBuilder.AppendLine("" + this.employeeHistories.Count);
                        strBuilder.Append("Quantidade de Linhas inválidas por registros nulos: ");
                        strBuilder.AppendLine("" + invalidLinesSet.Count);
                        strBuilder.Append("Quantidade de Linhas não carregadas por conta de Data anterior à 06/2014: ");
                        strBuilder.AppendLine("" + preDatesLinesSet.Count);
                        strBuilder.AppendLine("Clique no botão Salvar para inserir na base de dados e aguarde a conclusão da tarefa.");
                        this.txtOutput.Text = strBuilder.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo carregado não possui nenhuma planilha de trabalho.", "Leitura de Arquivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("Erro no Processamento: " + ex.Message, "Erro no Processamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //Salvar as informacoes na base de dados
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //desabilita os botões enquanto a tarefa é executada.
                _EnableAllButons(false);
                bgWorkerDatabase.RunWorkerAsync();

                //define a progressBar para Marquee
                pbSave.Style = ProgressBarStyle.Marquee;
                pbSave.MarqueeAnimationSpeed = 7;

                //informa que a tarefa esta sendo executada.
                this.txtOutput.Text = "Salvando na base de dados, essa tarefa pode demorar alguns minutos, aguarde...";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {

            }
        }

        private void cbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.contract = this.cbContracts.SelectedItem as Contract;
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboSheet.SelectedIndex >= result.Tables.Count))
                dataGridView1.DataSource = result.Tables[cboSheet.SelectedIndex];
            else
                MessageBox.Show("Planilha não existente.", "Erro de Seleção de Planilha", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        

        private bool _CheckValidLine (DataRow line)
        {
            if ((line[1] is DBNull) && (line[2] is DBNull) && (line[7] is DBNull)
                && (line[8] is DBNull) && (line[9] is DBNull) && (line[13] is DBNull))
            {
                return false;
            }
            return true;
        }

        private bool _CheckTimeRule(object mes, object ano)
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

        //A matricula tem tamanho 6 sempre
        private string _FormatMatriculation(string matriculation)
        {
            int diff = 6 - matriculation.Length;
            for (int i = 0; i < diff; i++)
            {
                matriculation = String.Concat("0", matriculation);
            }
            return matriculation;
        }

        private Employee _GetEmployeeByMatriculation(string matriculation)
        {            
            Employee returnedEmployee = null;
            foreach (Employee emp in allEmployees)
            {
                if (emp.Matriculation.Equals(matriculation))
                {
                    returnedEmployee = emp;
                    break;
                }
            }
            return returnedEmployee;
        }

        //Serão aceitos codigos de departamento com tamanho 12 para baixo.
        private string _FormatDeptCode(string deptCode)
        {
            //Tratamento do Codigo de Departamento
            if (deptCode.Length % 3 == 2)
            {
                deptCode = String.Concat("0", deptCode);
            }
            else if (deptCode.Length % 3 == 1)
            {
                deptCode = String.Concat("00", deptCode);
            }

            return deptCode;
        }

        private Department _GetDeptByCode(string deptCode)
        {
            Department retDep = null;
            foreach (Department dept in allDepartments)
            {
                if (dept.Code.Equals(deptCode))
                {
                    retDep = dept;
                    break;
                }
            }
            return retDep;
        }

        private void _EnableAllButons(bool flag)
        {
            this.btnImportWorksheet.Enabled = flag;
            this.btnProcess.Enabled = flag;
            this.btnSave.Enabled = flag;
        }

        private void bgWorkerDatabase_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int rowsAffected = _facade.InsertEmployeeHistoryList(employeeHistories);
            MessageBox.Show("A base de dados foi modificada em " + rowsAffected + " registros.", "Resultado da Tarefa", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            allEmployeeHistory = _facade.GetTopEmployeeHistory();
        }

        private void bgWorkerDatabase_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //informa que a tarefa foi concluida com sucesso.
            this.txtOutput.Text = "Tarefa Concluida com sucesso, consultar base de dados para maiores detalhes!";

            //Carrega todo progressbar.
            pbSave.MarqueeAnimationSpeed = 0;
            pbSave.Style = ProgressBarStyle.Blocks;
            pbSave.Value = 100;
            //habilita os botões.
            _EnableAllButons(true);
        }   
        
    }
}
