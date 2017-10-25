using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class HistoriaClinica
    {
        [Key]
        public string id { get; set; }

        



        public virtual List<Control> controles { get; set; }

    }
}