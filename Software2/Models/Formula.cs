﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Formula
    {   
        [Key]
        [Display(Name = "ID Formula")]
        public int formulaID { get; set; }

        [Display(Name = "ID Mascota")]
        [ForeignKey("Mascota")]
        public int mascotaID { get; set; }

        public virtual Mascota Mascota { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Ingrese una fecha")]
        public DateTime fecha { get; set; }

        public virtual ICollection<Medicamento> medicamentos { get; set; }

        [Display(Name = "Cédula Practicante")]
        [ForeignKey("Practicante")]
        public int practicanteID { get; set; }

        public virtual Practicante Practicante { get; set; }

    }
}