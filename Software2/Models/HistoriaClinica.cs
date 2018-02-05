using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class HistoriaClinica
    {
        [Key,ForeignKey("mascota")]
        public string id { get; set; }

        public DateTime fecha_creacion;


       

        public virtual List<Control> controles { get; set; }
        public virtual Mascota mascota { get; set; }
    }
}