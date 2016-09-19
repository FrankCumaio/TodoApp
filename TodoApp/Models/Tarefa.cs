using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Tarefa
    {
        public int id { get; set; }

        public string nome { get; set; }

        public DateTime? dataCriacao { get; set; }

        public DateTime? dataDesejada { get; set; }

        public string dataEntrega { get; set; }

        public string descricao { get; set; }

        public string estado { get; set; }

        public int? id_projecto { get; set; }

        public int? id_responsavel { get; set; }

        public virtual Membro membro { get; set; }

        public virtual Projecto projecto { get; set; }
    }
}