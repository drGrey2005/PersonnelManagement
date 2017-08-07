using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Entities;

namespace EmployeesDB.Abstract
{
    /// <summary>
    /// Абстрактное хранилище сущностей "Должность"
    /// </summary>
    public interface IPositionRepository
    {
        void CreatePosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(int id);
        IEnumerable<Position> GetPositions();
        Position GetPositionById(int id);
    }
}
