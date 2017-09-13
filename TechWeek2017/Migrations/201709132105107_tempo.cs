namespace TechWeek2017.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Curso = c.String(unicode: false),
                        Ra = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AlunoId);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        DataEvento = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.EventoId);
            
            CreateTable(
                "dbo.Tempo",
                c => new
                    {
                        TempoId = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        EventoId = c.Int(nullable: false),
                        Time = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TempoId)
                .ForeignKey("dbo.Aluno", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.EventoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tempo", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Tempo", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.Tempo", new[] { "EventoId" });
            DropIndex("dbo.Tempo", new[] { "AlunoId" });
            DropTable("dbo.Tempo");
            DropTable("dbo.Evento");
            DropTable("dbo.Aluno");
        }
    }
}
