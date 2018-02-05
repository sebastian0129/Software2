using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Software2.Models
{
    public class Practicante
    {
        private string email;

        

        [Key]
        //[Required(ErrorMessage = "El ID es obligatorio")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public string practicanteID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese un nombre")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El nombre no pueden ser n�meros o s�mbolos")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese un Apellido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El apellido no pueden ser n�meros o s�mbolos")]
        public string apellido { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Ingrese un correo")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        [Display(Name = "Contrase�a")]
        [Required(ErrorMessage = "Ingrese una contrase�a")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirmar Contrase�a")]
        [Compare("password", ErrorMessage = "Las contrase�as no coinciden")]
        [Required(ErrorMessage = "Confirme contrase�a")]
        [DataType(DataType.Password)]
        public string repetirPassword { get; set; }

        public string nombreCompleto
        {
            get
            {
                return nombre + " " + apellido; 
            }
        }
    }
}