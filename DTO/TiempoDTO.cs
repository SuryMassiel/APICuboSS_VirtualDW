using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.DTO
{
    public class TiempoDTO
    {
        public int Tiempo_key { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public int Trimestre { get; set; }
    }
}