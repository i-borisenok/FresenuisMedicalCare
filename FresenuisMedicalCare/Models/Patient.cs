
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FresenuisMedicalCare
{
    public class Patient
    {
        [Key]
        public int Id_Patient { get; set; }

        [Required]
        [MaxLength(100)] 
        public string Name { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; } 
                                          
        [MaxLength(15)]
        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        public DateTime FirstDialysis { get; set; }

        public bool PeritonealDialysis { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public double CurrentWeight { get; set; } // текущий вес

        public double TargetWeight { get; set; } // целевой вес

        public double Height { get; set; } // рост


        // ссылки на процедуры

        public virtual List<Procedure> Procedures { get; set; }

    }

}
