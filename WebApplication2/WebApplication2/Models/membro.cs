namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("membros")]
    public partial class membro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public membro()
        {
            projectos = new HashSet<projecto>();
            tarefas = new HashSet<tarefa>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string cargo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dRegisto { get; set; }

        public int? idade { get; set; }

        [StringLength(50)]
        public string sexo { get; set; }

        [StringLength(50)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string gAcademico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projecto> projectos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarefa> tarefas { get; set; }
    }
}
