using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.Models
{
    [Table("Dim_Paciente")]
    public class Dim_Paciente
    {
        [Column("Paciente_key")]
        [Key]
        public int Paciente_key { get; set; }
        public string Nombre_COMPLETO_Pacientes { get; set; }
        public string Sexo_Pacientes { get; set; }
        public int Edad_Pacientes { get; set; }
        public string Alergias_Pacientes { get; set; }
        public string Nombre_Completo_Tutor { get; set; }
        public string Sexo_Tutor { get; set; }
        public int Edad_Tutor { get; set; }
        public string Ocupacion_Tutor { get; set; }

        //esta linea de codigo srve para decir que en las tablas existe una relacion de Fact_CitaPediatrica
        public virtual ICollection<Fact_CitaPediatrica> Citas { get; set; }
    }
}