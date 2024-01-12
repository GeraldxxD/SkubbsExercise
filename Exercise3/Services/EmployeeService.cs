using Exercise3.Database;
using Exercise3.Models;

namespace Exercise3.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Exercise3Context db;

        public EmployeeService(Exercise3Context db)
        {
            this.db = db;  
        }
            
        public Employee GetById(int id)
        {
            var employee = db.Employee.Find(id);
            if (employee == null)
                throw new Exception("Employee not found");

            return employee;
        }
        public IEnumerable<Employee> GetAll()
        {
            return db.Employee.AsEnumerable();
        }
        public void Create(Employee employee)
        {
            try
            {
                db.Employee.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Failed to create");
            }
          
        }
        public void Update(Employee employee)
        {
            try
            {
                var emp = db.Employee.Find(employee.Id);
                if (emp == null)
                    throw new Exception("Employee not found");

                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.DateOfBirth = employee.DateOfBirth;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Failed to update");
            }
        }
        public void Delete(int id)
        {
            var employee = db.Employee.Find(id);
            if (employee == null)
                throw new Exception("Employee not found");

            db.Employee.Remove(employee);
            db.SaveChanges();
        }

    }
}
