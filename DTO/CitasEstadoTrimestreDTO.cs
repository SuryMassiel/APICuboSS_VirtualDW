using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.DTO
{
    public class CitasEstadoTrimestreDTO
    {
            public int Anio { get; set; }          
            public string Trimestre { get; set; }  
            public int Total { get; set; }    
            public int Confirmada { get; set; }   
            public int Cancelada { get; set; }  

    }//fin
}