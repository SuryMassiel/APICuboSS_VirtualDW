using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.Models
{
    [Table("Dim_Tiempo")]
    public class Dim_Tiempo
    {
        [Column("Tiempo_key")]
        [Key]
        public int Tiempo_key {  get; set; }
        public DateTime Fecha {  get; set; }
        public int Semana { get; set; }
        public string Mes {  get; set; }
        public int Anio { get; set; }
        public int Trimestre { get; set; }


        //esta linea de codigo srve para decir que en las tablas existe una relacion de Fact_CitaPediatrica
        public virtual ICollection<Fact_CitaPediatrica> Citas { get; set; }
    }
}