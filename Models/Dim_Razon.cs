using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.Models
{
    [Table("Dim_Razon")]
    public class Dim_Razon
    {
        [Column("Razon_cita_key")]
        [Key]
        public int Razon_cita_key { get; set; }
        public string Razon_cita { get; set; }

        //esta linea de codigo srve para decir que en las tablas existe una relacion de Fact_CitaPediatrica
        public virtual ICollection<Fact_CitaPediatrica> Citas { get; set; }
    }
}