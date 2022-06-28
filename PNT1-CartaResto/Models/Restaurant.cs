using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_CartaResto.Models
{
    public class Restaurant
    {


        public Restaurant()
        {
         
        }
        public Restaurant(int id, string nombre, int capMax)
        {
            this.Id = id;
            this.Nombre = nombre;
            
        }

        public int Id { get; set; }
        public string Nombre { get; set; }                
        public int CapacidadMax { get; set; }



    }
}
