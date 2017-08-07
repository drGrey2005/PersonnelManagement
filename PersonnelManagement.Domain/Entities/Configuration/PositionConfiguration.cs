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
    /// Класс-конфигуратор сущности "Должность"
    /// </summary>
    public class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("Positions");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("Id").IsRequired();
            Property(p => p.Title).HasColumnName("Title").IsRequired().HasMaxLength(255);
        }
    }
}
