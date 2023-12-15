using Exercise2.Domain;
using System.Data.SqlClient;
using Dapper;

namespace Exercise2.IServices
{
    public class RepositoryEmployees : IRepositoryEmployees
    {
        private readonly string strCon;
        public RepositoryEmployees(string strCon) {
        
            this.strCon = strCon;
        }

        public Employee ById(int id)
        {
            Employee? employee;

            try
            {
                string sql = "SELECT firstName, lastName, salary FROM employees WHERE employeeId = @employeeId";

                using (var connection = new SqlConnection(this.strCon))
                {
                    employee = connection.QueryFirstOrDefault<Employee>(sql, new { employeeId = id });
                }
            }
            catch(Exception) {
                throw;
            }

            return employee;
        }

        public bool Create(Employee employee)
        {
            try
            {
                string sql = "INSERT INTO employees values((SELECT MAX(employeeId)+1 FROM employees),@firstName,@lastName,@salary)";

                using (var connection = new SqlConnection(this.strCon))
                {
                    return connection.Execute(sql, new { firstName= employee.FirstName,
                        lastName = employee.LastName, salary = employee.Salary
                    })==  1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = "delete from employees where employeeId = @id";

                using (var connection = new SqlConnection(this.strCon))
                {
                    return connection.Execute(sql, new
                    {
                        id
                    })==1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee> List()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string sql = "SELECT firstName, lastName, salary FROM employees;";

                using (var connection = new SqlConnection(this.strCon))
                {
                    employees = connection.Query<Employee>(sql).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return employees;
        }

        public bool Update(Employee employee,int id)
        {

            try
            {
                string sql = "update employees set employeeId = @id,firstName = @firstName,lastName = @lastName, salary=@salary where employeeId = @id";

                using (var connection = new SqlConnection(this.strCon))
                {
                    return connection.Execute(sql, new
                    {
                        id = id,
                        firstName = employee.FirstName,
                        lastName = employee.LastName,
                        salary = employee.Salary
                    })==1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
