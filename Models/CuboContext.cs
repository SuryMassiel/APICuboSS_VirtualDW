using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using APICuboSS_VirtualDW.Models;

namespace APICuboSS_VirtualDW.Models
{
    public class CuboContext : DbContext
    {
        public CuboContext() : base ("name=CuboContext")
        {
            //evitamos redundancia
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            
        }

        //Tablas del modelo estrella
        public DbSet<Dim_EstadoCita> Dim_EstadoCita { get; set; }
        public DbSet<Dim_Paciente> Dim_Paciente { get; set; }
        public DbSet<Dim_PersonalMedico> Dim_PersonalMedico { get; set; }
        public DbSet<Dim_Razon> Dim_Razon { get; set; }
        public DbSet<Dim_Tiempo> Dim_Tiempo { get; set; }
        public DbSet<Fact_CitaPediatrica> Fact_CitaPediatrica { get; set; }

        //evitamos pluralizacion
        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating (modelBuilder);
        }

    }
}