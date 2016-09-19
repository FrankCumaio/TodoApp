using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Projecto
    {
        public int id { get; set; }

        public string nome { get; set; }

        public DateTime? dataInicio { get; set; }

        public DateTime? dataFim { get; set; }


        public string estado { get; set; }

        public virtual Membro membro { get; set; }

        public virtual ICollection<Tarefa> tarefas { get; set; }
    }
}