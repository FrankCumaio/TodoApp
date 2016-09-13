namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTarefa { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dCriacao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dEntrega { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dEntregaReal { get; set; }

        public int? responsavel { get; set; }

        [StringLength(10)]
        public string descricao { get; set; }

        public virtual membro membro { get; set; }
    }
}
