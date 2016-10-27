using Capacitarte.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Capacitarte.DataAccess
{
    public class CapacitarteContext : DbContext
    {

        public CapacitarteContext() : base("CapacitarteContext")
        {
        }

        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}