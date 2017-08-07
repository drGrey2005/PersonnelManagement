using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB.Entities.Configuration
{
    /// <summary>
    /// Класс-конфигуратор сущности "Сотрудник"
    /// </summary>
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id").IsRequired();
            Property(p => p.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(255);
            Property(p => p.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(255);
            Property(p => p.Patronymic).HasColumnName("Patronymic").IsOptional().HasMaxLength(255);
            HasRequired(e => e.Position).WithMany(p => p.Employees).HasForeignKey(e => e.PositionId).WillCascadeOnDelete(false);
        }
    }
}
