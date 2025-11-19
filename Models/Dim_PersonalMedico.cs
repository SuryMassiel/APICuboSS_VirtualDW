using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.Models
{
    [Table("Dim_PersonalMedico")]
    public class Dim_PersonalMedico
    {
        [Column("Personal_Medico_Key")]
        [Key]
        public int Personal_Medico_Key { get; set; }
        public string Nombre_Completo_Medico { get; set; }
        public string Sexo {  get; set; }
        public int Edad {  get; set; }
        public string Dependencia { get; set; }
        public string Cargo { get; set; }
        //esta linea de codigo srve para decir que en las tablas existe una relacion de Fact_CitaPediatrica
        public virtual ICollection<Fact_CitaPediatrica> Citas { get; set; }
    }
}