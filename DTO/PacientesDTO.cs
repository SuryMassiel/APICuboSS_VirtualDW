using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.DTO
{
    public class PacientesDTO
    {
        public int Paciente_key { get; set; }
        public string Nombre_COMPLETO_Pacientes { get; set; }
        public string Sexo_Pacientes { get; set; }
        public int Edad_Pacientes { get; set; }
        public string Alergias_Pacientes { get; set; }
        public string Nombre_Completo_Tutor { get; set; }
        public string Sexo_Tutor { get; set; }
        public int Edad_Tutor { get; set; }
        public string Ocupacion_Tutor { get; set; }
    }
}