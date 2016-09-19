using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoApp.Models.DAL
{
    public class todoAppContext : DbContext
    {
        public DbSet<Projecto> Projecto { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}