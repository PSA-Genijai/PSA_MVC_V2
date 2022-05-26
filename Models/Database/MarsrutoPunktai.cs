using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("MarsrutoPunktai")]
    public partial class MarsrutoPunktai
    {
        public MarsrutoPunktai()
        {
            PunktuKategorijos = new HashSet<PunktuKategorijo>();
        }

        [Key]
        [Column("punkto_id")]
        public int PunktoId { get; set; }
        [Column("punkto_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PunktoPavadinimas { get; set; }
        [Column("punkto_kategorija")]
        public int? PunktoKategorija { get; set; }
        [Column("darbo_laikas_nuo", TypeName = "date")]
        public DateTime? DarboLaikasNuo { get; set; }
        [Column("darbo_laikas_iki", TypeName = "date")]
        public DateTime? DarboLaikasIki { get; set; }

        [InverseProperty("FkMarsrutoPunktaipunkto")]
        public virtual ICollection<PunktuKategorijo> PunktuKategorijos { get; set; }
    }
}
