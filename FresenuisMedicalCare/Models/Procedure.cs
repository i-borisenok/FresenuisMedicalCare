using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Security.Cryptography.X509Certificates;

namespace FresenuisMedicalCare
{
    public class Procedure
    {
        [Key]
        public int Id_Procedure { get; set; }

        [Required]
        public Patient Patient { get; set; } 

        [Required]
        public DateTime DateOfProcedure { get; set; }

        public DateTime BeginingTime { get; set; }

        public DateTime EndTime { get; set; }

        public double WeightBefore { get; set; }

        public double WeightAfter { get; set; }

        public string TypeOfProcedure { get; set; }

        public string Comment { get; set; }
    }
}
