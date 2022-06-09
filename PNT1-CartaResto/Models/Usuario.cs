using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
        private string Dni { get; set; }

    }
}
