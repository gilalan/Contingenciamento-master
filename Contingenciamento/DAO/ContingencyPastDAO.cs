using Contingenciamento.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Contingenciamento.DAO
{
    public class ContingencyPastDAO
    {
        private DAOHelper dal = new DAOHelper();
        private EmployeeHistoryDAO employeeHistoryDAO = new EmployeeHistoryDAO();

        public ContingencyPast Get<K>(K id)
        {
            ContingencyPast contingencyPast = new ContingencyPast();
            NpgsqlDataReader reader = null;

            try
            {
                string cmdSelect = "SELECT cp.id as cp_id, cp.monetary_fund_name as cp_monetary_fund_name, " +
                    "eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                    "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                    "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                    "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                    "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                    "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, " +
                    "eh.contract_id as eh_contract_id, eh.processed as eh_processed, emp.id as emp_id, emp.name as emp_name, " +
                    "emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                    "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                    "rol.id as rol_id, rol.name as rol_name, dep.id as dep_id, dep.name as dep_name, dep.code as dep_code " +
                    "FROM (contingency_past cp INNER JOIN employee_history eh ON (cp.employee_history_id = eh.id)) " +
                    "INNER JOIN employees emp ON (eh.employee_id = e.id) " +
                    "LEFT JOIN departments dep ON (eh.department_id = d.id) " +
                    "LEFT JOIN roles rol ON (e.role_id = rol.id) " +
                    "WHERE cp.id = " + id + " ORDER BY cp.id";

                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmdSelect);

                if (reader.Read())
                {
                    //TO DO
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
            return contingencyPast;
        }

        public List<ContingencyPast> GetTop()
        {
            List<ContingencyPast> contingencyPasts = new List<ContingencyPast>();
            NpgsqlDataReader reader = null;
            try
            {
                //TO DO
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                this.dal.CloseConection();
            }
            return contingencyPasts;
        }

        public HashSet<ContingencyPast> GetByContract (Contract ct)
        {
            HashSet<ContingencyPast> contingencyPasts = new HashSet<ContingencyPast>(new ContingencyPastComparer());
            NpgsqlDataReader reader = null;
            try
            {
                string selectCMD = "SELECT cp.id as cp_id, cp.monetary_fund_name as cp_monetary_fund_name, cp.calculated_value as cp_calculated_value, " +
                        "eh.id as eh_id, eh.epoch as eh_epoch, eh.base_salary as eh_base_salary, eh.net_salary as eh_net_salary, " +
                        "eh.total_earnings as eh_total_earnings, eh.in_vacation as eh_in_vacation, eh.start_vacation_taken as eh_start_vacation_taken, " +
                        "eh.end_vacation_taken as eh_end_vacation_taken, eh.hazard_additional as eh_hazard_additional, " +
                        "eh.dangerousness_additional as eh_dangerousness_additional, eh.thirteenth_salary as eh_thirteenth_salary, " +
                        "eh.thirteenth_proportional_salary as eh_thirteenth_proportional_salary, eh.vacation_pay as eh_vacation_pay, " +
                        "eh.vacation_proportional_pay as eh_vacation_proportional_pay, eh.penalty_rescission as eh_penalty_rescission, " +
                        "eh.contract_id as eh_contract_id, eh.processed as eh_processed, emp.id as emp_id, emp.name as emp_name, " +
                        "emp.matriculation as emp_matriculation, emp.admission_date as emp_admission_date, emp.birthday as emp_birthday, " +
                        "emp.pis as emp_pis, emp.cpf as emp_cpf, emp.demission_date as emp_demission_date, " +
                        "rol.id as rol_id, rol.name as rol_name, dep.id as dep_id, dep.name as dep_name, dep.code as dep_code, " +
                        "ca.id as ca_id, ca.start_date as ca_start_date, ca.end_date as ca_end_date, ca.value as ca_value, " +
                        "cf.id as cf_id, cf.name as cf_name " +
                        "FROM (contingency_past cp INNER JOIN employee_history eh ON(cp.employee_history_id = eh.id)) " +
                        "INNER JOIN contingency_aliquot ca ON (cp.contingency_aliquot_id = ca.id) " +
                        "INNER JOIN contingency_funds cf ON (ca.contingency_fund_id = cf.id) " +
                        "INNER JOIN employees emp ON (eh.employee_id = emp.id) " +
                        "LEFT JOIN roles rol ON (emp.role_id = rol.id) " +
                        "LEFT JOIN departments dep ON (eh.department_id = dep.id) " +
                        "WHERE (cp.employee_history_id IN (SELECT id FROM employee_history WHERE contract_id = :ctId AND processed = true))";

                NpgsqlCommand cmd = new NpgsqlCommand(selectCMD);
                cmd.Parameters.Add(new NpgsqlParameter("ctId", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters[0].Value = ct.Id;

                ContingencyPast contingencyPast;
                dal.OpenConnection();
                reader = dal.ExecuteDataReader(cmd);
                while (reader.Read())
                {
                    contingencyPast = new ContingencyPast();
                    contingencyPast.Id = Convert.ToInt64(reader["cp_id"]);
                    contingencyPast.MonetaryFundName = reader["cp_monetary_fund_name"].ToString();
                    contingencyPast.EmployeeHistory = new EmployeeHistory(Convert.ToInt64(reader["eh_id"]));

                    if (contingencyPasts.Add(contingencyPast))
                    {
                        contingencyPast.ContingencyAliquots.Add(new ContingencyAliquot(Convert.ToInt64(reader["ca_id"]), Convert.ToDouble(reader["ca_value"]),
                            new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString()), Convert.ToDouble(reader["cp_calculated_value"])));

                        contingencyPast.EmployeeHistory.Epoch = Convert.ToDateTime(reader["eh_epoch"]);
                        contingencyPast.EmployeeHistory.StartVacationTaken = Convert.ToDateTime(reader["eh_start_vacation_taken"]);
                        contingencyPast.EmployeeHistory.EndVacationTaken = Convert.ToDateTime(reader["eh_end_vacation_taken"]);
                        contingencyPast.EmployeeHistory.InVacation = Convert.ToBoolean(reader["eh_in_vacation"]);
                        contingencyPast.EmployeeHistory.BaseSalary = Convert.ToDouble(reader["eh_base_salary"]);
                        contingencyPast.EmployeeHistory.NetSalary = Convert.ToDouble(reader["eh_net_salary"]);
                        contingencyPast.EmployeeHistory.TotalEarnings = Convert.ToDouble(reader["eh_total_earnings"]);
                        contingencyPast.EmployeeHistory.HazardAdditional = Convert.ToDouble(reader["eh_hazard_additional"]);
                        contingencyPast.EmployeeHistory.DangerousnessAdditional = Convert.ToDouble(reader["eh_dangerousness_additional"]);
                        contingencyPast.EmployeeHistory.ThirteenthSalary = Convert.ToDouble(reader["eh_thirteenth_salary"]);
                        contingencyPast.EmployeeHistory.ThirteenthProportionalSalary = Convert.ToDouble(reader["eh_thirteenth_proportional_salary"]);
                        contingencyPast.EmployeeHistory.VacationPay = Convert.ToDouble(reader["eh_vacation_pay"]);
                        contingencyPast.EmployeeHistory.VacationProportionalPay = Convert.ToDouble(reader["eh_vacation_proportional_pay"]);
                        contingencyPast.EmployeeHistory.PenaltyRescission = Convert.ToDouble(reader["eh_penalty_rescission"]);
                        contingencyPast.EmployeeHistory.Processed = Convert.ToBoolean(reader["eh_processed"]);

                        if (!(reader["emp_id"] is DBNull))
                        {
                            Employee employee = new Employee();
                            employee.Id = Convert.ToInt64(reader["emp_id"]);
                            employee.Name = reader["emp_name"].ToString();
                            employee.Matriculation = reader["emp_matriculation"].ToString();
                            employee.Birthday = Convert.ToDateTime(reader["emp_birthday"]);
                            employee.CurrentAdmissionDate = Convert.ToDateTime(reader["emp_admission_date"]);
                            employee.CurrentDemissionDate = Convert.ToDateTime(reader["emp_demission_date"]);
                            employee.PIS = reader["emp_pis"].ToString();
                            employee.CPF = reader["emp_cpf"].ToString();
                            if (!(reader["rol_id"] is DBNull))
                            {
                                Role role = new Role();
                                role.Id = Convert.ToInt64(reader["rol_id"]);
                                role.Name = reader["rol_name"].ToString();
                                employee.Role = role;
                            }
                            contingencyPast.EmployeeHistory.Employee = employee;
                        }

                        if (!(reader["dep_id"] is DBNull))
                        {
                            Department department = new Department();
                            department.Id = Convert.ToInt64(reader["dep_id"]);
                            department.Name = reader["dep_name"].ToString();
                            department.Code = reader["dep_code"].ToString();
                            contingencyPast.EmployeeHistory.Department = department;
                        }

                    } 
                    else
                    {
                        foreach (ContingencyPast cp in contingencyPasts)
                        {
                            if (cp.EmployeeHistory.Id == contingencyPast.EmployeeHistory.Id)
                            {
                                cp.ContingencyAliquots.Add(new ContingencyAliquot(Convert.ToInt64(reader["ca_id"]), Convert.ToDouble(reader["ca_value"]),
                            new ContingencyFund(Convert.ToInt64(reader["cf_id"]), reader["cf_name"].ToString()), Convert.ToDouble(reader["cp_calculated_value"])));
                            }
                        }
                    }
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
            return contingencyPasts;
        }

        public List<long> Insert(ContingencyPast contingencyPast)
        {
            object obj = null;
            List<long> returnedIds = new List<long>();
            long returnedId = -1;
            try
            {
                string cmdInsert = "INSERT INTO contingency_past (employee_history_id,monetary_fund_name,contingency_aliquot_id,calculated_value) " +
                    "VALUES (:employee_history_id,:monetary_fund_name,:contingency_aliquot_id,:calculated_value) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("employee_history_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetary_fund_name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("contingency_aliquot_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("calculated_value", NpgsqlTypes.NpgsqlDbType.Double));

                dal.OpenConnection();
                foreach (ContingencyAliquot ca in contingencyPast.ContingencyAliquots)
                {
                    if (contingencyPast.EmployeeHistory == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = contingencyPast.EmployeeHistory.Id;

                    if (String.IsNullOrEmpty(contingencyPast.MonetaryFundName))
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = contingencyPast.MonetaryFundName;

                    if (ca == null)
                    {
                        cmd.Parameters[2].Value = DBNull.Value;
                        cmd.Parameters[3].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters[2].Value = ca.Id;
                        cmd.Parameters[3].Value = ca.CalculatedValue;
                    }

                    obj = dal.ExecuteScalar(cmd);
                    if (obj != null)
                    {
                        returnedId = (long)obj;
                        returnedIds.Add(returnedId);
                    }
                }
                employeeHistoryDAO.UpdateProcessed(contingencyPast.EmployeeHistory.Id, true);
            }
            finally
            {
                this.dal.CloseConection();
            }
            return returnedIds;
        }

        public int BulkInsert(List<ContingencyPast> contingencyPastList)
        {
            int count = 0;
            try
            {
                string cmdInsert = "INSERT INTO contingency_past (employee_history_id,monetary_fund_name,contingency_aliquot_id,calculated_value) " +
                    "VALUES (:employee_history_id,:monetary_fund_name,:contingency_aliquot_id,:calculated_value) RETURNING id";

                NpgsqlCommand cmd = new NpgsqlCommand(cmdInsert);

                cmd.Parameters.Add(new NpgsqlParameter("employee_history_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetary_fund_name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("contingency_aliquot_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("calculated_value", NpgsqlTypes.NpgsqlDbType.Double));
                int rowsAffected = -1;

                dal.OpenConnection();                
                foreach (ContingencyPast cp in contingencyPastList)
                {
                    foreach (ContingencyAliquot ca in cp.ContingencyAliquots)
                    {
                        rowsAffected = -1;
                        if (cp.EmployeeHistory == null)
                            cmd.Parameters[0].Value = DBNull.Value;
                        else
                            cmd.Parameters[0].Value = cp.EmployeeHistory.Id;

                        if (String.IsNullOrEmpty(cp.MonetaryFundName))
                            cmd.Parameters[1].Value = DBNull.Value;
                        else
                            cmd.Parameters[1].Value = cp.MonetaryFundName;

                        if (ca == null)
                        {
                            cmd.Parameters[2].Value = DBNull.Value;
                            cmd.Parameters[3].Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters[2].Value = ca.Id;
                            cmd.Parameters[3].Value = ca.CalculatedValue;
                        }

                        rowsAffected = dal.ExecuteNonQuery(cmd);
                        if (rowsAffected > 0)
                            count++;
                    }
                    employeeHistoryDAO.UpdateProcessed(cp.EmployeeHistory.Id, true);
                }
            }
            finally
            {
                this.dal.CloseConection();
            }
            return count;
        }

        public int Update<K>(K id, ContingencyPast contingencyPast)
        {
            int count = 0;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE contingency_past SET \"employee_history_id\" = :employee_history_id, " +
                    "\"monetary_fund_name\" = :monetary_fund_name, \"contingency_aliquot_id\" = :contingency_aliquot_id " +
                    "WHERE \"id\" = '" + id + "' ;");

                cmd.Parameters.Add(new NpgsqlParameter("employee_history_id", NpgsqlTypes.NpgsqlDbType.Bigint));
                cmd.Parameters.Add(new NpgsqlParameter("monetary_fund_name", NpgsqlTypes.NpgsqlDbType.Text));
                cmd.Parameters.Add(new NpgsqlParameter("contingency_aliquot_id", NpgsqlTypes.NpgsqlDbType.Bigint));

                int rowsAffected = -1;
                dal.OpenConnection();
                foreach (ContingencyAliquot ca in contingencyPast.ContingencyAliquots)
                {
                    rowsAffected = -1;
                    if (contingencyPast.EmployeeHistory == null)
                        cmd.Parameters[0].Value = DBNull.Value;
                    else
                        cmd.Parameters[0].Value = contingencyPast.EmployeeHistory.Id;

                    if (String.IsNullOrEmpty(contingencyPast.MonetaryFundName))
                        cmd.Parameters[1].Value = DBNull.Value;
                    else
                        cmd.Parameters[1].Value = contingencyPast.MonetaryFundName;

                    if (ca == null)
                        cmd.Parameters[2].Value = DBNull.Value;
                    else
                        cmd.Parameters[2].Value = ca.Id;

                    rowsAffected = dal.ExecuteNonQuery(cmd);
                    if (rowsAffected > 0)
                        count++;
                }

                rowsAffected = dal.ExecuteNonQuery(cmd);
            }
            finally
            {
                this.dal.CloseConection();
            }
            return count;
        }

        public int Delete<K>(K id)
        {
            int rowsAffected = -1;
            try
            {
                string cmdDelete = String.Format("DELETE FROM contingency_past WHERE id = '{0}'", id);

                dal.OpenConnection();
                rowsAffected = dal.ExecuteNonQuery(cmdDelete);

            }
            finally
            {
                this.dal.CloseConection();
            }
            return rowsAffected;
        }
    }
}
