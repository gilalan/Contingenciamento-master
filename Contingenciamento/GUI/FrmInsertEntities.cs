using Contingenciamento.BLL;
using Contingenciamento.Entidades;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Contingenciamento.GUI
{
    public partial class FrmInsertEntities : Form
    {
        private Facade _facade = new Facade();
        private DataSet result;
        private HashSet<Role> roles;
        private HashSet<Department> departments;
        private HashSet<Employee> employees;

        private List<Role> allRoles;
        private List<Department> allDepartments;
        private List<Employee> allEmployees;

        int count = 0;

        public FrmInsertEntities()
        {
            InitializeComponent();
        }

        private void FrmInsertEntities_Load(object sender, EventArgs e)
        {
            allRoles = _facade.GetTopRole();
            allDepartments = _facade.GetTopDepartment();
            allEmployees = _facade.GetTopEmployee();
            if (allRoles.Count == 0)
            {
                MessageBox.Show("Atenção: a base de dados não possui registros de cargos dos funcionários. O primeiro passo " +
                    "para o cadastro das entidades relacionadas ao Funcionário é o cadastro dos Cargos/Funções que eles ocupam.",
                    "Tabela de Cargos dos Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
                this.pbProcess.Value = 0;
                this.pbSave.Value = 0;
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboSheet.SelectedIndex >= result.Tables.Count))
                dataGridView1.DataSource = result.Tables[cboSheet.SelectedIndex];
            else
                MessageBox.Show("Planilha não existente.", "Erro de Seleção de Planilha", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.result != null && this.result.Tables.Count > 0)
            {
                if (cboSheet.SelectedIndex == -1)
                {
                    MessageBox.Show("Antes de processar, escolha uma planliha na caixa de seleção de planilhas.", "Selecione uma Planilha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataTable worksheet = this.result.Tables[cboSheet.SelectedIndex];
                    int lines = worksheet.Rows.Count;
                    this.pbProcess.Maximum = lines;

                    if (rbRoles.Checked)
                    {
                        this.roles = new HashSet<Role>(new RoleComparer());
                        for (var i = 0; i < lines; i++)
                        {
                            if (!(worksheet.Rows[i][0] is DBNull))
                            {
                                if (!String.IsNullOrEmpty(worksheet.Rows[i][0].ToString()))
                                    roles.Add(new Role(worksheet.Rows[i][0].ToString()));
                            }
                            this.pbProcess.Increment(1);
                        }
                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.AppendLine("Dados de informação dos cargos processados com sucesso!");
                        strBuilder.Append("Quantidade de Cargos carregados da planilha: ");
                        strBuilder.AppendLine("" + roles.Count);
                        strBuilder.AppendLine("Clique no botão Salvar para inserir na base de dados...");
                        this.txtOutput.Text = strBuilder.ToString();
                    }

                    else if (rbEmployeeInfo.Checked)
                    {
                        this.employees = new HashSet<Employee>(new EmployeeComparer());
                        Employee employee;
                        Bank bank;
                        for (var i = 0; i < lines; i++)
                        {
                            bank = new Bank();
                            employee = new Employee();

                            if (!(worksheet.Rows[i][0] is DBNull))
                            {
                                employee.Matriculation = worksheet.Rows[i][0].ToString();
                            }

                            if (!(worksheet.Rows[i][1] is DBNull))
                            {
                                employee.Name = worksheet.Rows[i][1].ToString();
                            }

                            if (!(worksheet.Rows[i][5] is DBNull))
                            {
                                employee.CurrentAdmissionDate = (DateTime)worksheet.Rows[i][5];
                            }

                            if (!(worksheet.Rows[i][7] is DBNull))
                            {
                                employee.Birthday = (DateTime)worksheet.Rows[i][7];
                            }

                            if (!(worksheet.Rows[i][8] is DBNull))
                            {
                                employee.PIS = worksheet.Rows[i][8].ToString();
                            }

                            if (!(worksheet.Rows[i][9] is DBNull))
                            {
                                employee.CPF = worksheet.Rows[i][9].ToString();
                            }

                            if (!(worksheet.Rows[i][2] is DBNull))
                            {
                                employee.Role = new Role(worksheet.Rows[i][2].ToString());
                            }

                            if (!(worksheet.Rows[i][10] is DBNull))
                            {
                                bank.Name = worksheet.Rows[i][10].ToString();
                            }

                            if (!(worksheet.Rows[i][11] is DBNull))
                            {
                                bank.Code = worksheet.Rows[i][11].ToString();
                            }

                            if (!(worksheet.Rows[i][12] is DBNull))
                            {
                                bank.Agency = worksheet.Rows[i][12].ToString();
                            }

                            if (!(worksheet.Rows[i][13] is DBNull))
                            {
                                bank.Account = worksheet.Rows[i][13].ToString();
                            }

                            if (!(worksheet.Rows[i][14] is DBNull))
                            {
                                bank.DV = worksheet.Rows[i][14].ToString();
                            }

                            employee.BankData = bank;
                            employee.AdmissionDemissionHistories.Add(new AdmissionDemissionHistory(employee.CurrentAdmissionDate,
                                employee.Matriculation));
                            _UpdateRoleForEmployee(employee);
                            //Caso não adicione, é repetido, aí vamos atualizar os dados de acordo com a data de admissão mais recente
                            if (!employees.Add(employee))
                            {
                                _UpdateEmployee(employee);
                            }

                            this.pbProcess.Increment(1);
                        }

                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.AppendLine("Dados de informação pessoal dos funcionários processados com sucesso!");
                        strBuilder.Append("Quantidade de Registros de Funcionários novos carregados: ");
                        strBuilder.AppendLine("" + employees.Count);
                        strBuilder.AppendLine("Funcionários repetidos na planilha: " + count);

                        txtOutput.Text = strBuilder.ToString();
                    }
                    else if (rbDepartments.Checked)
                    {
                        this.departments = new HashSet<Department>(new DepartmentComparer());
                        for (var i = 0; i < lines; i++)
                        {
                            if (!(worksheet.Rows[i][0] is DBNull) && !(worksheet.Rows[i][1] is DBNull))
                            {
                                if (!String.IsNullOrEmpty(worksheet.Rows[i][0].ToString()) && 
                                    !String.IsNullOrEmpty(worksheet.Rows[i][1].ToString()))
                                {
                                    departments.Add(new Department(worksheet.Rows[i][0].ToString(),
                                        worksheet.Rows[i][1].ToString()));
                                }
                            }

                            this.pbProcess.Increment(1);
                        }
                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.AppendLine("Dados de informação dos departamentos processados com sucesso!");
                        strBuilder.Append("Quantidade de Departamentos únicos carregados da planilha: ");
                        strBuilder.AppendLine("" + this.departments.Count);
                        strBuilder.AppendLine("Clique no botão Salvar para inserir na base de dados...");
                        this.txtOutput.Text = strBuilder.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Carregue um arquivo com uma planilha de trabalho válida.", "Leitura de Arquivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //desabilita os botões enquanto a tarefa é executada.
                this.btnProcess.Enabled = false;
                this.btnSave.Enabled = false;
                bgWorkerDatabase.RunWorkerAsync();

                //define a progressBar para Marquee
                pbSave.Style = ProgressBarStyle.Marquee;
                pbSave.MarqueeAnimationSpeed = 6;

                //informa que a tarefa esta sendo executada.
                this.txtOutput.Text = "Salvando na base de dados, aguarde...";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + ex.Message, "Importação para Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgWorkerDatabase_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (rbRoles.Checked)
            {
                _facade.InsertRoleList(roles);
                allRoles = _facade.GetTopRole();
            }
            else if (rbEmployeeInfo.Checked)
            {
                _facade.InsertEmployeeList(employees);
                allEmployees = _facade.GetTopEmployee();
            }
            else if (rbDepartments.Checked)
            {
                _facade.InsertDepartmentList(departments);
                allDepartments = _facade.GetTopDepartment();
            }
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
            btnProcess.Enabled = true;
            btnSave.Enabled = true;
        }

        private void _UpdateRoleForEmployee(Employee employee)
        {
            foreach (var role in allRoles)
            {
                if (role.Name.Equals(employee.Role.Name))
                {
                    employee.Role.Id = role.Id;
                    if (employee.AdmissionDemissionHistories.Count > 0)
                    {
                        employee.AdmissionDemissionHistories[0].Role = role;
                    }
                    break;
                }
            }
        }

        /**
         * Só entra nesse método quando o employee já existe na list (verifica por CPF) e tem outro registro com o mesmo CPF
         * Normalmente as linhas se repetem quando o funcionário tem outra data de admissão (e o cargo pode ser diferente tb)
         */
        private void _UpdateEmployee(Employee employee)
        {
            count++;
            foreach (var emp in this.employees)
            {
                if (emp.Equals(employee))
                {
                    //A data no List é maior que a data do employee passado por parâmetro, então atualiza apenas o histórico
                    if ((emp.CurrentAdmissionDate - employee.CurrentAdmissionDate).TotalHours > 0)
                    {
                        if (employee.AdmissionDemissionHistories.Count > 0)
                            emp.AdmissionDemissionHistories.Add(employee.AdmissionDemissionHistories[0]);
                        break;
                    }
                    else //a data é menor, temos que substituir pelo employee que está chegando com a data mais recente de admissão
                    {
                        foreach (var adDemHist in emp.AdmissionDemissionHistories)
                        {
                            employee.AdmissionDemissionHistories.Add(adDemHist);
                        }
                        employees.Remove(emp);
                        employees.Add(employee);
                        break;
                    }
                }
            }
        }
    }
}
