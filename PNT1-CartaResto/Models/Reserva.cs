using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PNT1_CartaResto.Models
{
    public class Reserva
    {

        public Reserva()
        {

        }
        //    public Reserva(int id, string nombre, int capacidadMax, Usuario usuario, DateTime fecha, string tipo, Mesa mesa)
        //{
        //    Id = id;
        //    Nombre = nombre;
        //    CapacidadMax = capacidadMax;
        //    Usuario = usuario;
        //    Fecha = fecha;
        //    Tipo = tipo;
        //    Mesa = mesa;
        //}
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadMax { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public Mesa Mesa { get; set; }




    }
}
