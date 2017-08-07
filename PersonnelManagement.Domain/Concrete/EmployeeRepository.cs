using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Abstract;
using EmployeesDB.Entities;
using EmployeesDB.Entities.Contexts;

namespace EmployeesDB.Concrete
{
    /// <summary>
    /// Хранилище сущностей "Сотрудник"
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _db;

        public EmployeeRepository(EmployeeContext context)
        {
            _db = context;
        }
        public void CreateEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _db.Employees.Find(id);
        }
    }
}
