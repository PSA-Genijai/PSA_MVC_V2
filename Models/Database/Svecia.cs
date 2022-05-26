using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Svecia
    {
        public Svecia()
        {
            KambarioIvertinimas = new HashSet<KambarioIvertinima>();
            Pranesimas = new HashSet<Pranesima>();
            Rezervacijas = new HashSet<Rezervacija>();
            Saskaita = new HashSet<Saskaitum>();
        }

        [Key]
        [Column("s_id")]
        public int SId { get; set; }
        [Column("s_slapyvardis")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SSlapyvardis { get; set; }
        [Column("s_slaptazodis")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SSlaptazodis { get; set; }
        [Column("s_vardas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SVardas { get; set; }
        [Column("s_pavarde")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SPavarde { get; set; }
        [Column("s_el_pastas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SElPastas { get; set; }
        [Column("s_gimimo_data", TypeName = "date")]
        public DateTime? SGimimoData { get; set; }
        [Column("s_adresas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? SAdresas { get; set; }
        [Column("s_telefono_nr")]
        [StringLength(255)]
        [Unicode(false)]
        public string? STelefonoNr { get; set; }
        [Column("s_lytis")]
        public bool? SLytis { get; set; }

        [InverseProperty("FkSveciass")]
        public virtual ICollection<KambarioIvertinima> KambarioIvertinimas { get; set; }
        [InverseProperty("FkSveciass")]
        public virtual ICollection<Pranesima> Pranesimas { get; set; }
        [InverseProperty("FkSveciass")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
        [InverseProperty("FkSveciass")]
        public virtual ICollection<Saskaitum> Saskaita { get; set; }
    }
}
