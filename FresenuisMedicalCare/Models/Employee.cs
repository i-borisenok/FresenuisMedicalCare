
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;

namespace FresenuisMedicalCare
{
    public class Employee
    {
        [Key]
        public int Id_Employee { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public string Position { get; set; }

        /// <summary>
        /// Процедура поиска сотрудника по Email в базе данных.
        /// </summary>
        /// <param name="Email">Email сотрудника.</param>
        /// <param name="dataBase">Подключение к базе данных.</param>
        /// <returns>В случае успешного поиска возвращает объект Employee, иначе - null.</returns>
        public static Employee SearchEmployeeByEmail(string Email, DB dataBase)
        {
            Employee employee = dataBase.Employees
                .Where(c => c.Email == Email)
                .FirstOrDefault();

            if (employee == null) 
            {
                return null;
            }
            else
            {
                return employee;
            }
        }

    }
}
