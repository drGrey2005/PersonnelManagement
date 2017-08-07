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
    /// Хранилище сущностей "Должность"
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        private EmployeeContext _db;

        public PositionRepository(EmployeeContext context)
        {
            _db = context;
        }
        public void CreatePosition(Position position)
        {
            _db.Positions.Add(position);
        }

        public void UpdatePosition(Position position)
        {
            _db.Entry(position).State = EntityState.Modified;
        }

        public void DeletePosition(int id)
        {
            Position position = _db.Positions.Find(id);
            if (position != null)
            {
                _db.Positions.Remove(position);
            }
        }

        public IEnumerable<Position> GetPositions()
        {
            return _db.Positions;
        }

        public Position GetPositionById(int id)
        {
            return _db.Positions.Find(id);
        }
    }
}
