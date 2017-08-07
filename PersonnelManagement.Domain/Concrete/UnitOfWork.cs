using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Abstract;
using EmployeesDB.Entities.Contexts;

namespace EmployeesDB.Concrete
{
    /// <summary>
    /// Единица работы
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeContext _db = new EmployeeContext();
        private IPositionRepository _positionRepository;
        private IEmployeeRepository _employeeRepository;
        
        public IPositionRepository PositionRepository => _positionRepository ?? (_positionRepository = new PositionRepository(_db));

        public IEmployeeRepository EmployeeRepository => _employeeRepository ?? (_employeeRepository = new EmployeeRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
