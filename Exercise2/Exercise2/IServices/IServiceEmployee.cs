using Exercise2.Domain;

namespace Exercise2.IServices
{
    public interface IServiceEmployee
    {
        IEnumerable<Employee> GetList();
        Employee GetById(int id);
        void Delete(int id);
        void Update(Employee employee, int id);
        void Create(Employee employee);
    }
}
