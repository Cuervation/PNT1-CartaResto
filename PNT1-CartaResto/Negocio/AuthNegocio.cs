using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNT1_CartaResto.Negocio
{

    public sealed class AuthNegocio
    { 
        
        private readonly static AuthNegocio _instance = new AuthNegocio(); 

        private AuthNegocio() { }    
                
        public static AuthNegocio Instance 
        { get { return _instance; } } 


    }


}
