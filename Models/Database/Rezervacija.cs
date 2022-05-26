using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    //[Table("Rezervacija")]
    //[Index("FkSaskaitasaskaitaId", Name = "UQ__Rezervac__B1B81D903EF5BF46", IsUnique = true)]
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            PapildomosPaslaugos = new HashSet<PapildomosPaslaugo>();
        }

        [Key]
        [Column("rezervacija_id")]
        public int RezervacijaId { get; set; }
        [Column("sukurimo_data", TypeName = "date")]
        public DateTime? SukurimoData { get; set; }
        [Column("isiregistravimo_data", TypeName = "date")]
        public DateTime? IsiregistravimoData { get; set; }
        [Column("issiregistravimo_data", TypeName = "date")]
        public DateTime? IssiregistravimoData { get; set; }
        [Column("suaugusieji")]
        public int? Suaugusieji { get; set; }
        [Column("vaikai")]
        public int? Vaikai { get; set; }
        [Column("kaina")]
        public double? Kaina { get; set; }
        [Column("fk_Saskaitasaskaita_id")]
        public int FkSaskaitasaskaitaId { get; set; }
        [Column("fk_Sveciass_id")]
        public int FkSveciassId { get; set; }
        [Column("fk_Kambarysid_Kambarys")]
        public int FkKambarysidKambarys { get; set; }
        [Column("fk_Darbuotojasd_id")]
        public int FkDarbuotojasdId { get; set; }
        [Column("fk_RezervacijosStatusasrez_statusas_id")]
        public int FkRezervacijosStatusasrezStatusasId { get; set; }

        [ForeignKey("FkDarbuotojasdId")]
        [InverseProperty("Rezervacijas")]
        public virtual Darbuotoja FkDarbuotojasd { get; set; } = null!;
        [ForeignKey("FkKambarysidKambarys")]
        [InverseProperty("Rezervacijas")]
        public virtual Kambary FkKambarysidKambarysNavigation { get; set; } = null!;
        [ForeignKey("FkRezervacijosStatusasrezStatusasId")]
        [InverseProperty("Rezervacijas")]
        public virtual RezervacijosStatusa FkRezervacijosStatusasrezStatusas { get; set; } = null!;
        [ForeignKey("FkSaskaitasaskaitaId")]
        [InverseProperty("Rezervacija")]
        public virtual Saskaitum FkSaskaitasaskaita { get; set; } = null!;
        [ForeignKey("FkSveciassId")]
        [InverseProperty("Rezervacijas")]
        public virtual Svecia FkSveciass { get; set; } = null!;
        [InverseProperty("FkRezervacijarezervacija")]
        public virtual ICollection<PapildomosPaslaugo> PapildomosPaslaugos { get; set; }
    }
}
