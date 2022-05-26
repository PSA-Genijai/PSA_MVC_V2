using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Darbuotoja
    {
        public Darbuotoja()
        {
            Gedimas = new HashSet<Gedima>();
            KorespondecijaGavejais = new HashSet<KorespondecijaGavejai>();
            Korespondencijas = new HashSet<Korespondencija>();
            Rezervacijas = new HashSet<Rezervacija>();
        }

        [Key]
        [Column("d_id")]
        public int DId { get; set; }
        [Column("d_slapyvardis")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DSlapyvardis { get; set; }
        [Column("d_slaptazodis")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DSlaptazodis { get; set; }
        [Column("d_vardas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DVardas { get; set; }
        [Column("d_pavarde")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DPavarde { get; set; }
        [Column("d_el_pastas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DElPastas { get; set; }
        [Column("d_gimimo_data", TypeName = "date")]
        public DateTime? DGimimoData { get; set; }
        [Column("d_adresas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DAdresas { get; set; }
        [Column("d_telefono_nr")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DTelefonoNr { get; set; }
        [Column("d_lytis")]
        public bool? DLytis { get; set; }
        [Column("fk_Darbuotojo_tipasdarb_tipas_id")]
        public int FkDarbuotojoTipasdarbTipasId { get; set; }
        [Column("fk_Pranesimaspranesimas_id")]
        public int FkPranesimaspranesimasId { get; set; }

        [ForeignKey("FkDarbuotojoTipasdarbTipasId")]
        [InverseProperty("Darbuotojas")]
        public virtual DarbuotojoTipa FkDarbuotojoTipasdarbTipas { get; set; } = null!;
        [ForeignKey("FkPranesimaspranesimasId")]
        [InverseProperty("Darbuotojas")]
        public virtual Pranesima FkPranesimaspranesimas { get; set; } = null!;
        [InverseProperty("FkDarbuotojasd")]
        public virtual ICollection<Gedima> Gedimas { get; set; }
        [InverseProperty("FkDarbuotojasd")]
        public virtual ICollection<KorespondecijaGavejai> KorespondecijaGavejais { get; set; }
        [InverseProperty("FkDarbuotojasd")]
        public virtual ICollection<Korespondencija> Korespondencijas { get; set; }
        [InverseProperty("FkDarbuotojasd")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
