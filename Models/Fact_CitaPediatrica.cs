using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.Models
{
    [Table("Fact_CitaPediatrica")]
    public class Fact_CitaPediatrica
    {
        [Key]
        public int FactCitaPediatricact_Key { get; set; }
        public int Estado_cita_key { get; set; }
        public int Paciente_key { get; set; }
        public int Personal_Medico_Key { get; set; }
        public int Razon_cita_key { get; set; }
        public int Tiempo_key { get; set; }

        //establece relaciones con las dimensiones
        [ForeignKey("Estado_cita_key")]
        public virtual Dim_EstadoCita Dim_EstadoCita { get; set; }

        [ForeignKey("Paciente_key")]
        public virtual Dim_Paciente Dim_Paciente { get; set; }

        [ForeignKey("Personal_Medico_Key")]
        public virtual Dim_PersonalMedico Dim_PersonalMedico { get; set; }

        [ForeignKey("Razon_cita_key")]
        public virtual Dim_Razon Dim_Razon { get; set; }

        [ForeignKey("Tiempo_key")]
        public virtual Dim_Tiempo Dim_Tiempo { get; set; }
    }
}