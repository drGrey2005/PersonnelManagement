using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Concrete;

namespace EmployeesDB.Abstract
{
    /// <summary>
    /// Абстрактная единица работы
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IPositionRepository PositionRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        void Save();
    }
}
