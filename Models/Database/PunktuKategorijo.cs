using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class PunktuKategorijo
    {
        [Key]
        [Column("kategorijos_id")]
        public int KategorijosId { get; set; }
        [Column("kategorijos_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KategorijosPavadinimas { get; set; }
        [Column("fk_MarsrutoPunktaipunkto_id")]
        public int FkMarsrutoPunktaipunktoId { get; set; }

        [ForeignKey("FkMarsrutoPunktaipunktoId")]
        [InverseProperty("PunktuKategorijos")]
        public virtual MarsrutoPunktai FkMarsrutoPunktaipunkto { get; set; } = null!;
    }
}
