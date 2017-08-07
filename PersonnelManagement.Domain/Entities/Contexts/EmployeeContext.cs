using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesDB.Entities.Configuration;

namespace EmployeesDB.Entities.Contexts
{
    /// <summary>
    /// Класс-контекст хранилища сотрудников
    /// </summary>
    public class EmployeeContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }

        public EmployeeContext()
        {
        }
        public EmployeeContext(string connectionStringName) : base(connectionStringName) { }
    }
}
