namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("projectos")]
    public partial class projecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProjecto { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Column(TypeName = "date")]
        public DateTime dInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime dFim { get; set; }

        public int? responsavel { get; set; }

        public virtual membro membro { get; set; }
    }
}
