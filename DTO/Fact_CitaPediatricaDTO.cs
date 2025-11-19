using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.DTO
{
    public class Fact_CitaPediatricaDTO
    {
        public int FactCitaPediatricact_Key { get; set; }

        //Datos del Estado de cita
        public int Estado_cita_key { get; set; }
        public string Estado { get; set; }


        //Datos del Paciente
        public int Paciente_key { get; set; }
        public string Nombre_COMPLETO_Pacientes { get; set; }
        public string Sexo_Pacientes { get; set; }
        public int Edad_Pacientes { get; set; }
        public string Alergias_Pacientes { get; set; }
        public string Nombre_Completo_Tutor { get; set; }
        public string Sexo_Tutor { get; set; }
        public int Edad_Tutor { get; set; }
        public string Ocupacion_Tutor { get; set; }


        //Datos del personal Medico
        public int Personal_Medico_Key { get; set; }
        public string Nombre_Completo_Medico { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Dependencia { get; set; }
        public string Cargo { get; set; }

        //Datos Razon Cita
        public int Razon_cita_key { get; set; }
        public string Razon_cita { get; set; }


        //Datos Tiempo
        public int Tiempo_key { get; set; }
        public DateTime Fecha { get; set; }
        public int Semana { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public int Trimestre { get; set; }

    }//fin del fact
}