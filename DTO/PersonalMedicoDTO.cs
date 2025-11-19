using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICuboSS_VirtualDW.DTO
{
    public class PersonalMedicoDTO
    {
        public int Personal_Medico_Key { get; set; }
        public string Nombre_Completo_Medico { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Dependencia { get; set; }
        public string Cargo { get; set; }
    }
}