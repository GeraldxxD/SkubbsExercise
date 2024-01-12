using Exercise3.Models;

namespace Exercise3.Services
{
    public interface IEmployeeService
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
