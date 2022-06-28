using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PNT1_CartaResto.Models
{
    public class Reserva
    {

        public Reserva()
        {

        }
        public int Id { get; set; }
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail:")]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Ingrese un mail válido")]
        [Required(ErrorMessage = "Por favor ingrese su mail.")]
        public string Mail { get; set; }
        [Range(1, 15, ErrorMessage = "Las reservas son entre {1} y {2} comensales.")]
        [Required(ErrorMessage = "Por favor ingrese los comensales.")]
        public int Comensales { get; set; }
        public Usuario Usuario { get; set; } 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Display(Name = "Restriccion:")]
        [EnumDataType(typeof(Restricciones))]
        public Restricciones Tipo { get; set; }

        //public int MesaId { get; set; }

        //public Mesa Mesa { get; set; }




    }
}
