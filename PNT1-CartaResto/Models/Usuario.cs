using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PNT1_CartaResto.Models
{
    public class Usuario
    {
        public Usuario()
        {

         
        }
        public Usuario(string nombre, string apellido, string mail, string contraseña, string dni, int id)
        {

            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Contraseña = contraseña;
            Dni = dni;
        }
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor ingrese su nombre.")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Apellido:")]
        [Required(ErrorMessage = "Por favor ingrese su apellido.")]
        public string Apellido { get; set; }
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail:")]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Ingrese un mail válido")]
        [Required(ErrorMessage = "Por favor ingrese su mail.")]
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        [StringLength(8, ErrorMessage = "{0} Debe tener entre {2} y {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Contraseña:")]
        [Required(ErrorMessage = "Por favor ingrese su contraseña.")]
        public string Contraseña { get; set; }
        [DataType(DataType.Text)]
        [Range(5000000, 99000000, ErrorMessage= "El DNI debe estar comprendido entre {1} y {2}")]
        [Display(Name = "DNI:")]
        [Required(ErrorMessage = "Por favor ingrese su DNI.")]
        private string Dni { get; set; }

    }
}
