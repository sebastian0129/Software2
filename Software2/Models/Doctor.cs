using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Doctor
    {
        
        [Required]
        [RegularExpression("[0-9]+", ErrorMessage ="La cedula solo puede contener números")]
        [StringLength(15,ErrorMessage ="La longitud maxima para la cedula es de 15 caracteres")]
        [Display(Name = "Cedula")]
        [Key]
        public string cedula { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "El nombre solo puede contener letras")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "El apellido solo puede contener letras")]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Contraseña")]
        public string password { get; set; }


    }
}