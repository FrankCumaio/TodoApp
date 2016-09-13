namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=FirstModel")
        {
        }

        public virtual DbSet<membro> membros { get; set; }
        public virtual DbSet<projecto> projectos { get; set; }
        public virtual DbSet<tarefa> tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<membro>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .Property(e => e.cargo)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .Property(e => e.gAcademico)
                .IsUnicode(false);

            modelBuilder.Entity<membro>()
                .HasMany(e => e.projectos)
                .WithOptional(e => e.membro)
                .HasForeignKey(e => e.responsavel);

            modelBuilder.Entity<membro>()
                .HasMany(e => e.tarefas)
                .WithOptional(e => e.membro)
                .HasForeignKey(e => e.responsavel);

            modelBuilder.Entity<projecto>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<tarefa>()
                .Property(e => e.descricao)
                .IsFixedLength();
        }
    }
}
