using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class EmployeeHistoryDAO
    {
        private DAOHelper dal = new DAOHelper();

        public EmployeeHistory Get<K>(K id)
        {
            EmployeeHistory employeeHistory = new EmployeeHistory();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                    "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                    "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                    "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                    "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                    "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, emp.id as emp_id, " +
                    "emp.name as emp_name, emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                    "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                    "rol.id as rol_id, rol.name as rol_name, dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, cont.id as cont_id, " +
                    "cont.name as cont_name, cont.start_date as cont_start_date, cont.end_date as cont_end_date " +
                    "FROM (employee_history eh INNER JOIN employees emp ON (eh.employee_id = emp.id)) " +
                    "INNER JOIN roles rol ON (emp.role_id = rol.id) " +
                    "INNER JOIN departments dep ON (eh.department_id = dep.id) " +
                    "INNER JOIN contracts cont ON (dep.contract_id = cont.id) " +
                    "WHERE eh.id = :passedId ORDER BY eh.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = id;

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                if (reader.Read())
                {                    
                    employeeHistory.Id = Convert.ToInt64(reader["eh_id"]);
                    employeeHistory.Epoch = Convert.ToDateTime(reader["eh_epoch"]);
                    employeeHistory.StartVacationTaken = Convert.ToDateTime(reader["eh_start_vacation_taken"]);
                    employeeHistory.EndVacationTaken = Convert.ToDateTime(reader["eh_end_vacation_taken"]);
                    employeeHistory.InVacation = Convert.ToBoolean(reader["eh_in_vacation"]);
                    employeeHistory.BaseSalary = Convert.ToDouble(reader["eh_base_salary"]);
                    employeeHistory.NetSalary = Convert.ToDouble(reader["eh_net_salary"]);
                    employeeHistory.TotalEarnings = Convert.ToDouble(reader["eh_total_earnings"]);
                    employeeHistory.HazardAdditional = Convert.ToDouble(reader["eh_hazard_additional"]);
                    employeeHistory.DangerousnessAdditional = Convert.ToDouble(reader["eh_dangerousness_additional"]);
                    employeeHistory.ThirteenthSalary = Convert.ToDouble(reader["eh_thirteenth_salary"]);
                    employeeHistory.ThirteenthProportionalSalary = Convert.ToDouble(reader["eh_thirteenth_proportional_salary"]);
                    employeeHistory.VacationPay = Convert.ToDouble(reader["eh_vacation_pay"]);
                    employeeHistory.VacationProportionalPay = Convert.ToDouble(reader["eh_vacation_proportional_pay"]);
                    employeeHistory.PenaltyRescission = Convert.ToDouble(reader["eh_penalty_rescission"]);

                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["emp_id"]);
                    employee.Name = reader["emp_name"].ToString();
                    employee.Matriculation = reader["emp_matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["emp_birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["emp_admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["emp_demission_date"]);
                    employee.PIS = reader["emp_pis"].ToString();
                    employee.CPF = reader["emp_cpf"].ToString();
                    Role role = new Role();
                    role.Id = Convert.ToInt32(reader["rol_id"]);
                    role.Name = reader["rol_name"].ToString();
                    employee.Role = role;

                    Department department = new Department();
                    department.Id = Convert.ToInt64(reader["dep_id"]);
                    department.Name = reader["dep_name"].ToString();
                    department.Code = reader["dep_code"].ToString();

                    Contract contract = new Contract();
                    if (!(reader["cont_id"] is DBNull))
                    {
                        contract.Id = Convert.ToInt64(reader["cont_id"]);
                        contract.Name = reader["cont_name"].ToString();
                        contract.StartDate = Convert.ToDateTime(reader["cont_start_date"]);
                        contract.EndDate = Convert.ToDateTime(reader["cont_end_date"]);
                    }

                    employeeHistory.Employee = employee;
                    employeeHistory.Department = department;
                    employeeHistory.Contract = contract;

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
            return employeeHistory;
        }

        public EmployeeHistory GetByEmployeeMatriculation<K>(K matriculation)
        {

            EmployeeHistory employeeHistory = new EmployeeHistory();
            Contract contract;
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                    "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                    "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                    "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                    "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                    "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, emp.id as emp_id, " +
                    "emp.name as emp_name, emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                    "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                    "rol.id as rol_id, rol.name as rol_name, dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, cont.id as cont_id, " +
                    "cont.name as cont_name, cont.start_date as cont_start_date, cont.end_date as cont_end_date " +
                    "FROM (employee_history eh INNER JOIN employees emp ON (eh.employee_id = emp.id)) " +
                    "INNER JOIN roles rol ON (emp.role_id = rol.id) " +
                    "INNER JOIN departments dep ON (eh.department_id = dep.id) " +
                    "LEFT JOIN contracts cont ON (dep.contract_id = cont.id) " +
                    "WHERE eh.id = :passedMatric ORDER BY eh.id";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);

                cmd.Parameters.Add(new NpgsqlParameter("passedMatric", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters[0].Value = matriculation;

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);

                if (reader.Read())
                {
                    employeeHistory.Id = Convert.ToInt64(reader["eh_id"]);
                    employeeHistory.Epoch = Convert.ToDateTime(reader["eh_epoch"]);
                    employeeHistory.StartVacationTaken = Convert.ToDateTime(reader["eh_start_vacation_taken"]);
                    employeeHistory.EndVacationTaken = Convert.ToDateTime(reader["eh_end_vacation_taken"]);
                    employeeHistory.InVacation = Convert.ToBoolean(reader["eh_in_vacation"]);
                    employeeHistory.BaseSalary = Convert.ToDouble(reader["eh_base_salary"]);
                    employeeHistory.NetSalary = Convert.ToDouble(reader["eh_net_salary"]);
                    employeeHistory.TotalEarnings = Convert.ToDouble(reader["eh_total_earnings"]);
                    employeeHistory.HazardAdditional = Convert.ToDouble(reader["eh_hazard_additional"]);
                    employeeHistory.DangerousnessAdditional = Convert.ToDouble(reader["eh_dangerousness_additional"]);
                    employeeHistory.ThirteenthSalary = Convert.ToDouble(reader["eh_thirteenth_salary"]);
                    employeeHistory.ThirteenthProportionalSalary = Convert.ToDouble(reader["eh_thirteenth_proportional_salary"]);
                    employeeHistory.VacationPay = Convert.ToDouble(reader["eh_vacation_pay"]);
                    employeeHistory.VacationProportionalPay = Convert.ToDouble(reader["eh_vacation_proportional_pay"]);
                    employeeHistory.PenaltyRescission = Convert.ToDouble(reader["eh_penalty_rescission"]);

                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["emp_id"]);
                    employee.Name = reader["emp_name"].ToString();
                    employee.Matriculation = reader["emp_matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["emp_birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["emp_admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["emp_demission_date"]);
                    employee.PIS = reader["emp_pis"].ToString();
                    employee.CPF = reader["emp_cpf"].ToString();
                    Role role = new Role();
                    role.Id = Convert.ToInt32(reader["rol_id"]);
                    role.Name = reader["rol_name"].ToString();
                    employee.Role = role;

                    Department department = new Department();
                    department.Id = Convert.ToInt64(reader["dep_id"]);
                    department.Name = reader["dep_name"].ToString();
                    department.Code = reader["dep_code"].ToString();

                    contract = new Contract();
                    if (!(reader["cont_id"] is DBNull))
                    {
                        contract.Id = Convert.ToInt64(reader["cont_id"]);
                        contract.Name = reader["cont_name"].ToString();
                        contract.StartDate = Convert.ToDateTime(reader["cont_start_date"]);
                        contract.EndDate = Convert.ToDateTime(reader["cont_end_date"]);
                    }

                    employeeHistory.Employee = employee;
                    employeeHistory.Department = department;
                    employeeHistory.Contract = contract;
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
            return employeeHistory;
        }

        public List<EmployeeHistory> GetTop()
        {
            List<EmployeeHistory> employeeHistories = new List<EmployeeHistory>();
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                    "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                    "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                    "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                    "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                    "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, emp.id as emp_id, " +
                    "emp.name as emp_name, emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                    "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                    "rol.id as rol_id, rol.name as rol_name, dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, cont.id as cont_id, " +
                    "cont.name as cont_name, cont.start_date as cont_start_date, cont.end_date as cont_end_date " +
                    "FROM (employee_history eh INNER JOIN employees emp ON (eh.employee_id = emp.id)) " +
                    "INNER JOIN roles rol ON (emp.role_id = rol.id) " +
                    "INNER JOIN departments dep ON (eh.department_id = dep.id) " +
                    "LEFT JOIN contracts cont ON (dep.contract_id = cont.id) " +
                    "ORDER BY eh.id";

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(selectCMD);
                Employee employee;
                Role role;
                Department department;
                Contract contract;
                EmployeeHistory employeeHistory;

                while (reader.Read())
                {
                    employeeHistory = new EmployeeHistory();
                    employeeHistory.Id = Convert.ToInt64(reader["eh_id"]);
                    employeeHistory.Epoch = Convert.ToDateTime(reader["eh_epoch"]);
                    employeeHistory.StartVacationTaken = Convert.ToDateTime(reader["eh_start_vacation_taken"]);
                    employeeHistory.EndVacationTaken = Convert.ToDateTime(reader["eh_end_vacation_taken"]);
                    employeeHistory.InVacation = Convert.ToBoolean(reader["eh_in_vacation"]);
                    employeeHistory.BaseSalary = Convert.ToDouble(reader["eh_base_salary"]);
                    employeeHistory.NetSalary = Convert.ToDouble(reader["eh_net_salary"]);
                    employeeHistory.TotalEarnings = Convert.ToDouble(reader["eh_total_earnings"]);
                    employeeHistory.HazardAdditional = Convert.ToDouble(reader["eh_hazard_additional"]);
                    employeeHistory.DangerousnessAdditional = Convert.ToDouble(reader["eh_dangerousness_additional"]);
                    employeeHistory.ThirteenthSalary = Convert.ToDouble(reader["eh_thirteenth_salary"]);
                    employeeHistory.ThirteenthProportionalSalary = Convert.ToDouble(reader["eh_thirteenth_proportional_salary"]);
                    employeeHistory.VacationPay = Convert.ToDouble(reader["eh_vacation_pay"]);
                    employeeHistory.VacationProportionalPay = Convert.ToDouble(reader["eh_vacation_proportional_pay"]);
                    employeeHistory.PenaltyRescission = Convert.ToDouble(reader["eh_penalty_rescission"]);

                    employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["emp_id"]);
                    employee.Name = reader["emp_name"].ToString();
                    employee.Matriculation = reader["emp_matriculation"].ToString();
                    employee.Birthday = Convert.ToDateTime(reader["emp_birthday"]);
                    employee.CurrentAdmissionDate = Convert.ToDateTime(reader["emp_admission_date"]);
                    employee.CurrentDemissionDate = Convert.ToDateTime(reader["emp_demission_date"]);
                    employee.PIS = reader["emp_pis"].ToString();
                    employee.CPF = reader["emp_cpf"].ToString();
                    role = new Role();
                    role.Id = Convert.ToInt32(reader["rol_id"]);
                    role.Name = reader["rol_name"].ToString();
                    employee.Role = role;

                    department = new Department();
                    department.Id = Convert.ToInt64(reader["dep_id"]);
                    department.Name = reader["dep_name"].ToString();
                    department.Code = reader["dep_code"].ToString();

                    contract = new Contract();
                    if (!(reader["cont_id"] is DBNull))
                    {
                        contract.Id = Convert.ToInt64(reader["cont_id"]);
                        contract.Name = reader["cont_name"].ToString();
                        contract.StartDate = Convert.ToDateTime(reader["cont_start_date"]);
                        contract.EndDate = Convert.ToDateTime(reader["cont_end_date"]);
                    }

                    employeeHistory.Employee = employee;
                    employeeHistory.Department = department;
                    employeeHistory.Contract = contract;

                    employeeHistories.Add(employeeHistory);
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
            return employeeHistories;
        }

        public List<EmployeeHistory> GetFromContract(Contract ct)
        {
            List<EmployeeHistory> employeeHistories = new List<EmployeeHistory>();
            NpgsqlDataReader reader = null;

            try
            {
                //string selectCMD = "SELECT eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                //    "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                //    "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                //    "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                //    "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                //    "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, emp.id as emp_id, " +
                //    "emp.name as emp_name, emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                //    "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                //    "rol.id as rol_id, rol.name as rol_name, d.name as d_name, d.code as d_code " +
                //    "FROM (employee_history eh INNER JOIN employees emp ON (eh.employee_id = emp.id)) " +
                //    "INNER JOIN roles rol ON (emp.role_id = rol.id) " +
                //    "INNER JOIN departments d ON (eh.department_id = d.id) " +
                //    "WHERE code LIKE ";

                ////NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);
                ////cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Integer));
                ////cmd.Parameters.Add(new NpgsqlParameter("passedId", NpgsqlTypes.NpgsqlDbType.Text));
                //string newQuery;
                //dal.OpenConnection();
                //foreach (Department dept in ct.Departments)
                //{
                //    //cmd.Parameters[0].Value = "%" + dept.Code + "%";
                //    newQuery = selectCMD + "%" + dept.Code + "%";
                //    reader = dal.ExecuteDataReader(newQuery);
                //    Employee employee;
                //    Role role;
                //    EmployeeHistory employeeHistory;

                //    while (reader.Read())
                //    {
                //        employeeHistory = new EmployeeHistory();
                //        employeeHistory.Id = Convert.ToInt64(reader["eh_id"]);
                //        employeeHistory.Epoch = Convert.ToDateTime(reader["eh_epoch"]);
                //        employeeHistory.StartVacationTaken = Convert.ToDateTime(reader["eh_start_vacation_taken"]);
                //        employeeHistory.EndVacationTaken = Convert.ToDateTime(reader["eh_end_vacation_taken"]);
                //        employeeHistory.InVacation = Convert.ToBoolean(reader["eh_in_vacation"]);
                //        employeeHistory.BaseSalary = Convert.ToDouble(reader["eh_base_salary"]);
                //        employeeHistory.NetSalary = Convert.ToDouble(reader["eh_net_salary"]);
                //        employeeHistory.TotalEarnings = Convert.ToDouble(reader["eh_total_earnings"]);
                //        employeeHistory.HazardAdditional = Convert.ToDouble(reader["eh_hazard_additional"]);
                //        employeeHistory.DangerousnessAdditional = Convert.ToDouble(reader["eh_dangerousness_additional"]);
                //        employeeHistory.ThirteenthSalary = Convert.ToDouble(reader["eh_thirteenth_salary"]);
                //        employeeHistory.ThirteenthProportionalSalary = Convert.ToDouble(reader["eh_thirteenth_proportional_salary"]);
                //        employeeHistory.VacationPay = Convert.ToDouble(reader["eh_vacation_pay"]);
                //        employeeHistory.VacationProportionalPay = Convert.ToDouble(reader["eh_vacation_proportional_pay"]);
                //        employeeHistory.PenaltyRescission = Convert.ToDouble(reader["eh_penalty_rescission"]);

                //        employee = new Employee();
                //        employee.Id = Convert.ToInt32(reader["emp_id"]);
                //        employee.Name = reader["emp_name"].ToString();
                //        employee.Matriculation = reader["emp_matriculation"].ToString();
                //        employee.Birthday = Convert.ToDateTime(reader["emp_birthday"]);
                //        employee.CurrentAdmissionDate = Convert.ToDateTime(reader["emp_admission_date"]);
                //        employee.CurrentDemissionDate = Convert.ToDateTime(reader["emp_demission_date"]);
                //        employee.PIS = reader["emp_pis"].ToString();
                //        employee.CPF = reader["emp_cpf"].ToString();
                //        role = new Role();
                //        role.Id = Convert.ToInt32(reader["rol_id"]);
                //        role.Name = reader["rol_name"].ToString();
                //        employee.Role = role;

                //        employeeHistory.Employee = employee;
                //        employeeHistory.Department = dept;
                //        employeeHistory.Contract = ct;

                //        employeeHistories.Add(employeeHistory);
                //    }
                //    reader.Close();
                //}

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }

            return employeeHistories;
        }

        public long Insert(EmployeeHistory oEmployeeHistory)
        {
            //int rowsAffected = -1;
            object obj = null;
            long idReturned = -1;
            try
            {
                string insertCMD = "INSERT INTO employee_history(epoch,base_salary,net_salary,total_earnings,in_vacation,start_vacation_taken,end_vacation_taken, " +
                    "hazard_additional,dangerousness_additional,thirteenth_salary,thirteenth_proportional_salary,vacation_pay,vacation_proportional_pay,penalty_rescission, " +
                    "employee_id,department_id) " +
                    "VALUES (:epoch,:base_salary,:net_salary,:total_earnings,:in_vacation,:start_vacation_taken,:end_vacation_taken, " +
                    ":hazard_additional,:dangerousness_additional,:thirteenth_salary,:thirteenth_proportional_salary,:vacation_pay,:vacation_proportional_pay," +
                    ":penalty_rescission,:employee_id,:department_id) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("epoch", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("base_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("net_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("total_earnings", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("in_vacation", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("start_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("hazard_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("dangerousness_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_proportional_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_proportional_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("penalty_rescission", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("department_id", NpgsqlTypes.NpgsqlDbType.Integer));

                if (oEmployeeHistory.Epoch == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oEmployeeHistory.Epoch;
                
                cmd.Parameters[1].Value = oEmployeeHistory.BaseSalary;
                cmd.Parameters[2].Value = oEmployeeHistory.NetSalary;
                cmd.Parameters[3].Value = oEmployeeHistory.TotalEarnings;
                cmd.Parameters[4].Value = oEmployeeHistory.InVacation;

                if (oEmployeeHistory.StartVacationTaken == null)
                    cmd.Parameters[5].Value = DBNull.Value;
                else
                    cmd.Parameters[5].Value = oEmployeeHistory.StartVacationTaken;

                if (oEmployeeHistory.EndVacationTaken == null)
                    cmd.Parameters[6].Value = DBNull.Value;
                else
                    cmd.Parameters[6].Value = oEmployeeHistory.EndVacationTaken;

                cmd.Parameters[7].Value = oEmployeeHistory.HazardAdditional;
                cmd.Parameters[8].Value = oEmployeeHistory.DangerousnessAdditional;
                cmd.Parameters[9].Value = oEmployeeHistory.ThirteenthSalary;
                cmd.Parameters[10].Value = oEmployeeHistory.ThirteenthProportionalSalary;
                cmd.Parameters[11].Value = oEmployeeHistory.VacationPay;
                cmd.Parameters[12].Value = oEmployeeHistory.VacationProportionalPay;
                cmd.Parameters[13].Value = oEmployeeHistory.PenaltyRescission;

                if (oEmployeeHistory.Employee == null)
                    cmd.Parameters[14].Value = DBNull.Value;
                else
                    cmd.Parameters[14].Value = oEmployeeHistory.Employee.Id;

                if (oEmployeeHistory.Department == null)
                    cmd.Parameters[15].Value = DBNull.Value;
                else
                    cmd.Parameters[15].Value = oEmployeeHistory.Department.Id;

                dal.OpenConnection();
                obj = dal.ExecuteScalar(cmd);
                if (obj != null) //salvar em tabelas extras outras informações do usuário
                {
                    idReturned = (int)obj;
                }
            }
            finally
            {
                this.dal.CloseConection();
            }

            return idReturned;
        }

        public int BulkInsert(HashSet<EmployeeHistory> employeeHistoryList)
        {
            int rowsAffected = 0;
            int duplicateRows = 0;
            try
            {
                object obj = null;
                string insertCMD = "INSERT INTO employee_history(epoch,base_salary,net_salary,total_earnings,in_vacation,start_vacation_taken,end_vacation_taken, " +
                    "hazard_additional,dangerousness_additional,thirteenth_salary,thirteenth_proportional_salary,vacation_pay,vacation_proportional_pay,penalty_rescission, " +
                    "employee_id,department_id) " +
                    "VALUES (:epoch,:base_salary,:net_salary,:total_earnings,:in_vacation,:start_vacation_taken,:end_vacation_taken, " +
                    ":hazard_additional,:dangerousness_additional,:thirteenth_salary,:thirteenth_proportional_salary,:vacation_pay,:vacation_proportional_pay," +
                    ":penalty_rescission,:employee_id,:department_id) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(insertCMD);

                cmd.Parameters.Add(new NpgsqlParameter("epoch", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("base_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("net_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("total_earnings", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("in_vacation", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("start_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("hazard_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("dangerousness_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_proportional_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_proportional_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("penalty_rescission", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("department_id", NpgsqlTypes.NpgsqlDbType.Integer));
                dal.OpenConnection();

                foreach (var oEmployeeHistory in employeeHistoryList)
                {
                    obj = null;

                    if (oEmployeeHistory.Epoch == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = oEmployeeHistory.Epoch;

                    cmd.Parameters[1].Value = oEmployeeHistory.BaseSalary;
                    cmd.Parameters[2].Value = oEmployeeHistory.NetSalary;
                    cmd.Parameters[3].Value = oEmployeeHistory.TotalEarnings;
                    cmd.Parameters[4].Value = oEmployeeHistory.InVacation;

                    if (oEmployeeHistory.StartVacationTaken == null)
                        cmd.Parameters[5].Value = DBNull.Value;
                    else
                        cmd.Parameters[5].Value = oEmployeeHistory.StartVacationTaken;

                    if (oEmployeeHistory.EndVacationTaken == null)
                        cmd.Parameters[6].Value = DBNull.Value;
                    else
                        cmd.Parameters[6].Value = oEmployeeHistory.EndVacationTaken;

                    cmd.Parameters[7].Value = oEmployeeHistory.HazardAdditional;
                    cmd.Parameters[8].Value = oEmployeeHistory.DangerousnessAdditional;
                    cmd.Parameters[9].Value = oEmployeeHistory.ThirteenthSalary;
                    cmd.Parameters[10].Value = oEmployeeHistory.ThirteenthProportionalSalary;
                    cmd.Parameters[11].Value = oEmployeeHistory.VacationPay;
                    cmd.Parameters[12].Value = oEmployeeHistory.VacationProportionalPay;
                    cmd.Parameters[13].Value = oEmployeeHistory.PenaltyRescission;

                    if (oEmployeeHistory.Employee == null)
                        cmd.Parameters[14].Value = DBNull.Value;
                    else
                        cmd.Parameters[14].Value = oEmployeeHistory.Employee.Id;

                    if (oEmployeeHistory.Department == null)
                        cmd.Parameters[15].Value = DBNull.Value;
                    else
                        cmd.Parameters[15].Value = oEmployeeHistory.Department.Id;
                    //usando o ID para salvar na tabela de banks
                    obj = dal.ExecuteScalar(cmd);
                    if (obj != null)
                    {
                        rowsAffected++;
                    } else
                    {
                        duplicateRows++;
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

            return rowsAffected;
        }

        public void Update<K>(K id, EmployeeHistory oEmployeeHistory)
        {
            int rowsAffected = -1;
            try
            {               
                string updateCMD = "UPDATE employee_history SET \"epoch\" = :epoch, \"base_salary\" = :base_salary, \"net_salary\" = :net_salary, " +
                "\"total_earnings\" = :total_earnings, \"in_vacation\" = :in_vacation, \"start_vacation_taken\" = :start_vacation_taken, " +
                "\"end_vacation_taken\" = :end_vacation_taken, \"hazard_additional\" = :hazard_additional, \"dangerousness_additional\" = :dangerousness_additional " +
                "\"thirteenth_salary\" = :thirteenth_salary, \"thirteenth_proportional_salary\" = :thirteenth_proportional_salary, \"vacation_pay\" = :vacation_pay " +
                "\"vacation_proportional_pay\" = :vacation_proportional_pay, \"penalty_rescission\" = :penalty_rescission, \"employee_id\" = :employee_id, " +
                "\"department_id\" = :department_id WHERE \"id\" = '" + id + "' ;";

                NpgsqlCommand cmd = new NpgsqlCommand(updateCMD);

                cmd.Parameters.Add(new NpgsqlParameter("epoch", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("base_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("net_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("total_earnings", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("in_vacation", NpgsqlTypes.NpgsqlDbType.Boolean));
                cmd.Parameters.Add(new NpgsqlParameter("start_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("end_vacation_taken", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters.Add(new NpgsqlParameter("hazard_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("dangerousness_additional", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("thirteenth_proportional_salary", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("vacation_proportional_pay", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("penalty_rescission", NpgsqlTypes.NpgsqlDbType.Double));
                cmd.Parameters.Add(new NpgsqlParameter("employee_id", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters.Add(new NpgsqlParameter("department_id", NpgsqlTypes.NpgsqlDbType.Integer));

                if (oEmployeeHistory.Epoch == null)
                    cmd.Parameters[0].Value = DBNull.Value;
                else
                    cmd.Parameters[0].Value = oEmployeeHistory.Epoch;

                cmd.Parameters[1].Value = oEmployeeHistory.BaseSalary;
                cmd.Parameters[2].Value = oEmployeeHistory.NetSalary;
                cmd.Parameters[3].Value = oEmployeeHistory.TotalEarnings;
                cmd.Parameters[4].Value = oEmployeeHistory.InVacation;

                if (oEmployeeHistory.StartVacationTaken == null)
                    cmd.Parameters[5].Value = DBNull.Value;
                else
                    cmd.Parameters[5].Value = oEmployeeHistory.StartVacationTaken;

                if (oEmployeeHistory.EndVacationTaken == null)
                    cmd.Parameters[6].Value = DBNull.Value;
                else
                    cmd.Parameters[6].Value = oEmployeeHistory.EndVacationTaken;

                cmd.Parameters[7].Value = oEmployeeHistory.HazardAdditional;
                cmd.Parameters[8].Value = oEmployeeHistory.DangerousnessAdditional;
                cmd.Parameters[9].Value = oEmployeeHistory.ThirteenthSalary;
                cmd.Parameters[10].Value = oEmployeeHistory.ThirteenthProportionalSalary;
                cmd.Parameters[11].Value = oEmployeeHistory.VacationPay;
                cmd.Parameters[12].Value = oEmployeeHistory.VacationProportionalPay;
                cmd.Parameters[13].Value = oEmployeeHistory.PenaltyRescission;

                if (oEmployeeHistory.Employee == null)
                    cmd.Parameters[14].Value = DBNull.Value;
                else
                    cmd.Parameters[14].Value = oEmployeeHistory.Employee.Id;

                if (oEmployeeHistory.Department == null)
                    cmd.Parameters[15].Value = DBNull.Value;
                else
                    cmd.Parameters[15].Value = oEmployeeHistory.Department.Id;

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
                string deleteCMD = String.Format("DELETE From employee_history WHERE id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(deleteCMD);

            }
            finally
            {
                this.dal.CloseConection();
            }
            //return rowsAffected;
        }
    }
}
