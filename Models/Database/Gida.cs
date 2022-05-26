using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Gida
    {
        [Key]
        [Column("g_id")]
        public int GId { get; set; }
        [Column("g_vardas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GVardas { get; set; }
        [Column("g_pavarde")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GPavarde { get; set; }
        [Column("g_gimimo_data", TypeName = "date")]
        public DateTime? GGimimoData { get; set; }
        [Column("g_el_pastas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GElPastas { get; set; }
        [Column("g_telefono_nr")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GTelefonoNr { get; set; }
        [Column("fk_Ekskursijaeks_id")]
        public int FkEkskursijaeksId { get; set; }

        [ForeignKey("FkEkskursijaeksId")]
        [InverseProperty("Gida")]
        public virtual Ekskursija FkEkskursijaeks { get; set; } = null!;
    }
}
