using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Alergena
    {
        [Key]
        [Column("alergenas_id")]
        public int AlergenasId { get; set; }
        [Column("alergenas_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? AlergenasPavadinimas { get; set; }
        [Column("fk_Patiekalaspatiekalas_id")]
        public int FkPatiekalaspatiekalasId { get; set; }

        [ForeignKey("FkPatiekalaspatiekalasId")]
        [InverseProperty("Alergenas")]
        public virtual Patiekala FkPatiekalaspatiekalas { get; set; } = null!;
    }
}
