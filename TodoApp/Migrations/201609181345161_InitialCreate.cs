namespace TodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Membroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        idade = c.Int(),
                        sexo = c.String(),
                        cargo = c.String(),
                        grauAcademico = c.String(),
                        endereco = c.String(),
                        telefone = c.Int(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Projectoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        dataInicio = c.DateTime(),
                        dataFim = c.DateTime(),
                        id_membro = c.Int(),
                        estado = c.String(),
                        membro_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Membroes", t => t.membro_id)
                .Index(t => t.membro_id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        dataCriacao = c.DateTime(),
                        dataDesejada = c.DateTime(),
                        dataEntrega = c.String(),
                        descricao = c.String(),
                        estado = c.String(),
                        id_projecto = c.Int(),
                        id_responsavel = c.Int(),
                        membro_id = c.Int(),
                        projecto_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Membroes", t => t.membro_id)
                .ForeignKey("dbo.Projectoes", t => t.projecto_id)
                .Index(t => t.membro_id)
                .Index(t => t.projecto_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "projecto_id", "dbo.Projectoes");
            DropForeignKey("dbo.Tarefas", "membro_id", "dbo.Membroes");
            DropForeignKey("dbo.Projectoes", "membro_id", "dbo.Membroes");
            DropIndex("dbo.Tarefas", new[] { "projecto_id" });
            DropIndex("dbo.Tarefas", new[] { "membro_id" });
            DropIndex("dbo.Projectoes", new[] { "membro_id" });
            DropTable("dbo.Tarefas");
            DropTable("dbo.Projectoes");
            DropTable("dbo.Membroes");
        }
    }
}
