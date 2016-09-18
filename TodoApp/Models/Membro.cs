using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Membro
    {

        public int id { get; set; }

        public string nome { get; set; }

        public int? idade { get; set; }

        public string sexo { get; set; }

        public string cargo { get; set; }

        public string grauAcademico { get; set; }

        public string endereco { get; set; }

        public int? telefone { get; set; }

        public string email { get; set; }

        public virtual ICollection<Projecto> projectoes { get; set; }

        public virtual ICollection<Tarefa> tarefas { get; set; }
    }
}