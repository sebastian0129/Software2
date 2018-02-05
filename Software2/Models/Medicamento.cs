using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Medicamento
    {
        [Display(Name = "ID Medicamento")]
        public int medicamentoID { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Expresion")]
        public int expresion { get; set; }

        [Display(Name = "Lote")]
        public int lote { get; set; }

        [Display(Name = "Vía de Suministro")]
        public ViaSuministro viaSuministro { get; set; }
    }
}