using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Entities;

namespace EmployeesDB.Abstract
{
    /// <summary>
    /// Абстрактное хранилище сущностей "Сотрудник"
    /// </summary>
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
    }
}
