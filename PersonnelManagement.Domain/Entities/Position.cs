using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDB.Entities
{
    /// <summary>
    /// Должность
    /// </summary>
    public class Position
    {
        public int Id { get; set; }
        [DisplayName("Наименование должности")]
        [Required(ErrorMessage = @"Поле ""Наименование должности"" является обязательным")]
        public string Title { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
