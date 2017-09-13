namespace TechWeek2017.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TechWeek2017.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }//Configuration

        protected override void Seed(TechWeek2017.Models.Context context)
        {
            //Puxar dados do DB em Access

            IList<Aluno> alunos = new List<Aluno>();
            alunos.Add(new Aluno() {Nome ="Joao", Curso="Ads" });

            foreach (Aluno aluno in alunos) {
                context.Alunos.AddOrUpdate(x => x.AlunoId, aluno);
            }//ForEach

        }//Seed
    }
}
