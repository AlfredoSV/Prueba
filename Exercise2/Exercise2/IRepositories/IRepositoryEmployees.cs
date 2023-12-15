using Exercise2.Domain;

namespace Exercise2.IServices
{
    public interface IRepositoryEmployees
    {
        IEnumerable<Employee> List();
        Employee ById(int id);
        bool Delete(int id);
        bool Update(Employee employee,int id);
        bool Create(Employee employee);
    }
}
