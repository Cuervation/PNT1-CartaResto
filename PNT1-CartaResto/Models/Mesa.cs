using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_CartaResto.Models
{
    public class Mesa
    {
        public Mesa(int id, bool estaLibre)
        {
            Id = id;
            EstaLibre = estaLibre;
            
        }

        public int Id { get; set; }
        public Boolean EstaLibre { get; set; }
    }
}
