using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FresenuisMedicalCare
{
    public class DB : DbContext
    {
        public DB() : base("DBConnectionString")
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

    }
}
 