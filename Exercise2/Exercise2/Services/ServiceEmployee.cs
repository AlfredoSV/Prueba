using Exercise2.Domain;

namespace Exercise2.IServices
{
    public class ServiceEmployee : IServiceEmployee
    {
        private readonly IRepositoryEmployees _repositoryEmployees;
        public ServiceEmployee(IRepositoryEmployees repositoryEmployees)
        {
            this._repositoryEmployees = repositoryEmployees;
        }

        public void Create(Employee employee)
        {
            bool result = _repositoryEmployees.Create(employee);

            if (!result)
                throw new CommonException("User Not create", "The employee wa not create");
        }

        public void Delete(int id)
        {
            bool result = _repositoryEmployees.Delete(id);

            if (!result)
                throw new CommonException("User Not delete", "The employee wa not delete");
        }

        public Employee GetById(int id)
        {
            var employee = _repositoryEmployees.ById(id);

            if (employee == null)
                throw new CommonException("Not Found", "The employee wa not exist");

            return employee;
        }

        public IEnumerable<Employee> GetList()
        {
            return _repositoryEmployees.List();
        }

        public void Update(Employee employee, int id)
        {
            bool result = _repositoryEmployees.Update(employee,id);

            if (!result)
                throw new CommonException("User Not update", "The employee wa not update");
        }
    }
}
