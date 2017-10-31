using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class MedicamentosFormula
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID Formula")]
        [ForeignKey("Formula")]
        public int formulaID { get; set; }

        public virtual Formula Formula { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "ID Medicamento")]
        [ForeignKey("Medicamento")]
        public int MedicamentoID { get; set; }

        public virtual Medicamento Medicamento { get; set; }

        [Display(Name = "Frecuencia/hora")]
        public string frecuenciaHora { get; set; }

        [Display(Name = "Dosis")]
        public int dosis { get; set; }
    }
}