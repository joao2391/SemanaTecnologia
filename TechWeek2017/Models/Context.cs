using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TechWeek2017.Models {
    public class Context : DbContext {

        public Context() : base("TechWeek2017") {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }//context

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Tempo> Tempos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Conventions.Remove();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //modelBuilder.Entity<Aluno>()
                
            //    .HasMany<Evento>(s => s.Eventos)
            //    .WithMany(c => c.Alunos)
            //    .Map(cs => {

            //        cs.MapLeftKey("AlunoRefId");
            //        cs.MapRightKey("EventoRefId");
            //        cs.ToTable("AlunoEvento");

            //    });
               
        }//OnModelCreating

        
    }
}