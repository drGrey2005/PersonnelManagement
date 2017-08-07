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
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        [Required(ErrorMessage = @"Поле ""Имя"" является обязательным")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        [Required(ErrorMessage = @"Поле ""Фамилия"" является обязательным")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = @"Поле ""Должность"" является обязательным")]
        public int PositionId { get; set; }
        [DisplayName("Должность")]
        public virtual Position Position { get; set; }
    }
}
