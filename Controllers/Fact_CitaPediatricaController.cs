using APICuboSS_VirtualDW.DTO;
using APICuboSS_VirtualDW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace APICuboSS_VirtualDW.Controllers
{
    public class Fact_CitaPediatricaController : ApiController
    {
        private CuboContext db = new CuboContext();

        // GET: api/Fact_CitaPediatrica
        public IQueryable<Fact_CitaPediatrica> GetFact_CitaPediatrica()
        {
            return db.Fact_CitaPediatrica;
        }

        // GET: api/Fact_CitaPediatrica/5
        [ResponseType(typeof(Fact_CitaPediatrica))]
        public IHttpActionResult GetFact_CitaPediatrica(int id)
        {
            Fact_CitaPediatrica fact_CitaPediatrica = db.Fact_CitaPediatrica.Find(id);
            if (fact_CitaPediatrica == null)
            {
                return NotFound();
            }

            return Ok(fact_CitaPediatrica);
        }

        // PUT: api/Fact_CitaPediatrica/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFact_CitaPediatrica(int id, Fact_CitaPediatrica fact_CitaPediatrica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fact_CitaPediatrica.FactCitaPediatricact_Key)
            {
                return BadRequest();
            }

            db.Entry(fact_CitaPediatrica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fact_CitaPediatricaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Fact_CitaPediatrica
        [ResponseType(typeof(Fact_CitaPediatrica))]
        public IHttpActionResult PostFact_CitaPediatrica(Fact_CitaPediatrica fact_CitaPediatrica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fact_CitaPediatrica.Add(fact_CitaPediatrica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fact_CitaPediatrica.FactCitaPediatricact_Key }, fact_CitaPediatrica);
        }

        // DELETE: api/Fact_CitaPediatrica/5
        [ResponseType(typeof(Fact_CitaPediatrica))]
        public IHttpActionResult DeleteFact_CitaPediatrica(int id)
        {
            Fact_CitaPediatrica fact_CitaPediatrica = db.Fact_CitaPediatrica.Find(id);
            if (fact_CitaPediatrica == null)
            {
                return NotFound();
            }

            db.Fact_CitaPediatrica.Remove(fact_CitaPediatrica);
            db.SaveChanges();

            return Ok(fact_CitaPediatrica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Fact_CitaPediatricaExists(int id)
        {
            return db.Fact_CitaPediatrica.Count(e => e.FactCitaPediatricact_Key == id) > 0;
        }

        ///APIS PROPIAS

        //Pacientes

        [HttpGet]
        [Route("api/Dim_Paciente/DTO")]
        public IHttpActionResult GetPacientesDTO()
        {
            var pacientes = db.Dim_Paciente
                .Select(p => new PacientesDTO
                {
                    Paciente_key = p.Paciente_key,
                    Nombre_COMPLETO_Pacientes = p.Nombre_COMPLETO_Pacientes,
                    Sexo_Pacientes = p.Sexo_Pacientes,
                    Edad_Pacientes = p.Edad_Pacientes,
                    Alergias_Pacientes = p.Alergias_Pacientes,
                    Nombre_Completo_Tutor = p.Nombre_Completo_Tutor,
                    Sexo_Tutor = p.Sexo_Tutor,
                    Edad_Tutor = p.Edad_Tutor,
                    Ocupacion_Tutor = p.Ocupacion_Tutor
                }).ToList();
            return Ok(pacientes);
        }

        //Personal Medico

        [HttpGet]
        [Route("api/Dim_PersonalMedico/DTO")]
        public IHttpActionResult GetPersonalMedicoDTO()
        {
            var personalmedico = db.Dim_PersonalMedico
                .Select(pm => new PersonalMedicoDTO
                {
                    Personal_Medico_Key = pm.Personal_Medico_Key,
                    Nombre_Completo_Medico = pm.Nombre_Completo_Medico,
                    Sexo = pm.Sexo,
                    Edad = pm.Edad,
                    Dependencia = pm.Dependencia,
                    Cargo = pm.Cargo

                }).ToList();
            return Ok(personalmedico);
        }

        //Estado Cita

        [HttpGet]
        [Route("api/Dim_EstadoCita/DTO")]
        public IHttpActionResult GetEstadoCitaDTO()
        {
            var estadocita = db.Dim_EstadoCita
                .Select(e => new EstadoCitaDTO
                {
                    Estado_cita_key = e.Estado_cita_key,
                    Estado = e.Estado
                }).ToList();
            return Ok(estadocita);
        }

        //Razon Cita
        [HttpGet]
        [Route("api/Dim_Razon/DTO")]
        public IHttpActionResult GetRazonDTO()
        {
            var razon = db.Dim_Razon
                .Select(r => new RazonDTO
                {
                    Razon_cita_key = r.Razon_cita_key,
                    Razon_cita = r.Razon_cita

                }).ToList();
            return Ok(razon);
        }


        //Tiempo
        [HttpGet]
        [Route("api/Dim_Tiempo/DTO")]
        public IHttpActionResult GetTiempoDTO()
        {
            var tiempo = db.Dim_Tiempo
                .Select(t => new TiempoDTO
                {
                    Tiempo_key = t.Tiempo_key,
                    Fecha = t.Fecha,
                    Semana = t.Semana,
                    Mes = t.Mes,
                    Anio = t.Anio,
                    Trimestre = t.Trimestre
                }).ToList();
            return Ok(tiempo);
        }


        //CONSULTAS ANALITICAS

        //ObtenerTotalcitasanio
        [HttpGet]
        [Route("api/Citas/PorAnio")]
        public IHttpActionResult GetCitasPorAnio()
        {
            var resultado =
                db.Fact_CitaPediatrica
                .Join(db.Dim_Tiempo,
                    f => f.Tiempo_key,
                    t => t.Tiempo_key,
                    (f, t) => new
                    {
                        Anio = t.Anio
                    })
                .GroupBy(x => x.Anio)
                .Select(g => new CitasAnioDTO
                {
                    Anio = g.Key,
                    Total_Citas = g.Count()
                })
                .OrderBy(x => x.Anio)
                .ToList();

            return Ok(resultado);
        }


        //ObtenerTotalCitasConfirmada_Cancelda_Trismestre

        [HttpGet]
        [Route("api/Citas/Trimestre2025PorEstado")]
        public IHttpActionResult GetCitasTrimestre2025PorEstado()
        {
            // Obtenemos los datos filtrando solo el año 2025
            var datos = db.Fact_CitaPediatrica
                .Join(db.Dim_Tiempo,
                    f => f.Tiempo_key,
                    t => t.Tiempo_key,
                    (f, t) => new { f, t })
                .Join(db.Dim_EstadoCita,
                    ft => ft.f.Estado_cita_key,
                    e => e.Estado_cita_key,
                    (ft, e) => new
                    {
                        Anio = ft.t.Anio,
                        Trimestre = ft.t.Trimestre.ToString(),
                        Estado = e.Estado
                    })
                .Where(x => x.Anio == 2025)
                .ToList(); // Traemos a memoria para poder usar conteos condicionales

            // Creamos lista final agregando el "All" del año
            var resultado = datos
                .GroupBy(x => new { x.Anio, x.Trimestre })
                .Select(g => new CitasEstadoTrimestreDTO
                {
                    Anio = g.Key.Anio,
                    Trimestre = g.Key.Trimestre,
                    Total = g.Count(),
                    Confirmada = g.Count(x => x.Estado == "Confirmada"),
                    Cancelada = g.Count(x => x.Estado == "Cancelada")
                })
                .OrderBy(x => x.Trimestre == "All" ? 0 : int.Parse(x.Trimestre)) // Ponemos All primero
                .ToList();

            // Agregamos fila "All" total general del año
            var totalAnio = new CitasEstadoTrimestreDTO
            {
                Anio = 2025,
                Trimestre = "All",
                Total = resultado.Sum(x => x.Total),
                Confirmada = resultado.Sum(x => x.Confirmada),
                Cancelada = resultado.Sum(x => x.Cancelada)
            };
            resultado.Insert(0, totalAnio); // Insertamos al inicio

            return Ok(resultado);
        }


        //ObtenerRazonesComunesPorcentaje2024
        [HttpGet]
        [Route("api/Citas/Top6Razon2024")]
        public IHttpActionResult GetTop6Razon2024()
        {
            var totalGeneral = db.Fact_CitaPediatrica
                .Join(db.Dim_Tiempo,
                    f => f.Tiempo_key,
                    t => t.Tiempo_key,
                    (f, t) => new { f, t })
                .Where(x => x.t.Anio == 2024)
                .Count();

            var resultado = db.Fact_CitaPediatrica
                .Join(db.Dim_Razon,
                    f => f.Razon_cita_key,
                    r => r.Razon_cita_key,
                    (f, r) => new { f, r })
                .Join(db.Dim_Tiempo,
                    fr => fr.f.Tiempo_key,
                    t => t.Tiempo_key,
                    (fr, t) => new { fr.r.Razon_cita, t.Anio })
                .Where(x => x.Anio == 2024)
                .GroupBy(x => x.Razon_cita)
                .Select(g => new RazonesComunes2024
                {
                    Razon = g.Key,
                    Anio = 2024,
                    Total_Citas = g.Count(),
                    Porcentaje_Citas = Math.Round((decimal)g.Count() * 100 / totalGeneral, 2)
                })
                .OrderByDescending(x => x.Total_Citas)
                .Take(6) // TOP 6 razones
                .ToList();

            return Ok(resultado);
        }


        //ObtenerTotalCitasConfirmada_Cancelda_Sexo2025
        [HttpGet]
        [Route("api/Citas/PorSexo2025PorEstado")]
        public IHttpActionResult GetCitasPorSexo2025PorEstado()
        {
            var resultado = db.Fact_CitaPediatrica
                .Join(db.Dim_Paciente,
                    f => f.Paciente_key,
                    p => p.Paciente_key,
                    (f, p) => new { f, p })
                .Join(db.Dim_EstadoCita,
                    fp => fp.f.Estado_cita_key,
                    e => e.Estado_cita_key,
                    (fp, e) => new { fp.p.Sexo_Pacientes, Estado = e.Estado, fp.f.Tiempo_key })
                .Join(db.Dim_Tiempo,
                    fpe => fpe.Tiempo_key,
                    t => t.Tiempo_key,
                    (fpe, t) => new { fpe.Sexo_Pacientes, fpe.Estado, t.Anio })
                .Where(x => x.Anio == 2025)
                .GroupBy(x => x.Sexo_Pacientes)
                .Select(g => new CitasSexo2025
                {
                    Sexo = g.Key, 
                    Confirmada = g.Count(x => x.Estado == "Confirmada"),
                    Cancelada = g.Count(x => x.Estado == "Cancelada"),
                    Total_Citas = g.Count() 
                })
                .ToList();

            return Ok(resultado);
        }

        //Citas_Confirmadas_Caceladas_Medico2025

        [HttpGet]
        [Route("api/Citas/PorMedico2025")]
        public IHttpActionResult GetCitasPorMedico2025()
        {
            var resultado = db.Fact_CitaPediatrica
                .Join(db.Dim_PersonalMedico,
                    f => f.Personal_Medico_Key,
                    m => m.Personal_Medico_Key,
                    (f, m) => new { f, m })
                .Join(db.Dim_EstadoCita,
                    fm => fm.f.Estado_cita_key,
                    e => e.Estado_cita_key,
                    (fm, e) => new { fm.m.Nombre_Completo_Medico, Estado = e.Estado, fm.f.Tiempo_key })
                .Join(db.Dim_Tiempo,
                    fme => fme.Tiempo_key,
                    t => t.Tiempo_key,
                    (fme, t) => new { fme.Nombre_Completo_Medico, fme.Estado, t.Anio })
                .Where(x => x.Anio == 2025)
                .GroupBy(x => x.Nombre_Completo_Medico)
                .Select(g => new Citas_Confirmadas_Caceladas_Medico2025
                {
                    Medico = g.Key,                   
                    Confirmada = g.Count(x => x.Estado == "Confirmada"),
                    Cancelada = g.Count(x => x.Estado == "Cancelada"),
                    Total_Citas = g.Count()           
                })
                .OrderBy(x => x.Medico)
                .ToList();

            return Ok(resultado);
        }


        //Citas Por razon respiratorias 1

        [HttpGet]
        [Route("api/Citas/RazonTosMeses")]
        public IHttpActionResult GetCitasRazonTosPorMes()
        {
            var resultado =
                db.Fact_CitaPediatrica
                .Join(db.Dim_Razon,
                    f => f.Razon_cita_key,
                    r => r.Razon_cita_key,
                    (f, r) => new { f, r })
                .Join(db.Dim_Tiempo,
                    fr => fr.f.Tiempo_key,
                    t => t.Tiempo_key,
                    (fr, t) => new
                    {
                        Razon = fr.r.Razon_cita,
                        t.Anio,
                        t.Mes
                    })
                .Where(x =>
                    x.Razon == "Consulta por tos" &&
                    (x.Mes == "December" || x.Mes == "January") &&
                    (x.Anio == 2023 || x.Anio == 2024)
                )
                .GroupBy(x => new { x.Razon, x.Anio, x.Mes })
                .Select(g => new ConsultasRespiratorias
                {
                    Razon = g.Key.Razon,
                    Anio = g.Key.Anio,
                    Mes = g.Key.Mes,
                    Total_Citas = g.Count()
                })
                .OrderBy(x => x.Anio)
                .ThenBy(x => x.Mes)
                .ToList();

            return Ok(resultado);
        }


        //Citas Por razon por fiebre 2

        [HttpGet]
        [Route("api/Citas/RazonFiebreMeses")]
        public IHttpActionResult GetCitasRazonFiebrePorMes2()
        {
            var resultado =
                db.Fact_CitaPediatrica
                .Join(db.Dim_Razon,
                    f => f.Razon_cita_key,
                    r => r.Razon_cita_key,
                    (f, r) => new { f, r })
                .Join(db.Dim_Tiempo,
                    fr => fr.f.Tiempo_key,
                    t => t.Tiempo_key,
                    (fr, t) => new
                    {
                        Razon = fr.r.Razon_cita,
                        t.Anio,
                        t.Mes
                    })
                .Where(x =>
                    x.Razon == "Consulta por fiebre" &&
                    (x.Mes == "December" || x.Mes == "January") &&
                    (x.Anio == 2023 || x.Anio == 2024)
                )
                .GroupBy(x => new { x.Razon, x.Anio, x.Mes })
                .Select(g => new ConsultasRespiratorias
                {
                    Razon = g.Key.Razon,
                    Anio = g.Key.Anio,
                    Mes = g.Key.Mes,
                    Total_Citas = g.Count()
                })
                .OrderBy(x => x.Anio)
                .ThenBy(x => x.Mes)
                .ToList();

            return Ok(resultado);
        }


        //Citas Por razon respiratorias 3

        [HttpGet]
        [Route("api/Citas/RazonProblemasRespiratoriosMeses")]
        public IHttpActionResult GetCitasRazonProblemasRespiratoriosPorMes3()
        {
            var resultado =
                db.Fact_CitaPediatrica
                .Join(db.Dim_Razon,
                    f => f.Razon_cita_key,
                    r => r.Razon_cita_key,
                    (f, r) => new { f, r })
                .Join(db.Dim_Tiempo,
                    fr => fr.f.Tiempo_key,
                    t => t.Tiempo_key,
                    (fr, t) => new
                    {
                        Razon = fr.r.Razon_cita,
                        t.Anio,
                        t.Mes
                    })
                .Where(x =>
                    x.Razon == "Problemas respiratorios" &&
                    (x.Mes == "December" || x.Mes == "January") &&
                    (x.Anio == 2023 || x.Anio == 2024)
                )
                .GroupBy(x => new { x.Razon, x.Anio, x.Mes })
                .Select(g => new ConsultasRespiratorias
                {
                    Razon = g.Key.Razon,
                    Anio = g.Key.Anio,
                    Mes = g.Key.Mes,
                    Total_Citas = g.Count()
                })
                .OrderBy(x => x.Anio)
                .ThenBy(x => x.Mes)
                .ToList();

            return Ok(resultado);
        }


        [HttpGet]
        [Route("api/Citas/RazonDolorGargantaMeses")]
        public IHttpActionResult GetCitasRazonDolorGargantaPorMes4()
        {
            var resultado =
                db.Fact_CitaPediatrica
                .Join(db.Dim_Razon,
                    f => f.Razon_cita_key,
                    r => r.Razon_cita_key,
                    (f, r) => new { f, r })
                .Join(db.Dim_Tiempo,
                    fr => fr.f.Tiempo_key,
                    t => t.Tiempo_key,
                    (fr, t) => new
                    {
                        Razon = fr.r.Razon_cita,
                        t.Anio,
                        t.Mes
                    })
                .Where(x =>
                    x.Razon == "Dolor de garganta" &&
                    (x.Mes == "December" || x.Mes == "January") &&
                    (x.Anio == 2023 || x.Anio == 2024)
                )
                .GroupBy(x => new { x.Razon, x.Anio, x.Mes })
                .Select(g => new ConsultasRespiratorias
                {
                    Razon = g.Key.Razon,
                    Anio = g.Key.Anio,
                    Mes = g.Key.Mes,
                    Total_Citas = g.Count()
                })
                .OrderBy(x => x.Anio)
                .ThenBy(x => x.Mes)
                .ToList();

            return Ok(resultado);
        }


    }
}