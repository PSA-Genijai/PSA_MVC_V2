using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Kambary
    {
        public Kambary()
        {
            KambarioIvertinimas = new HashSet<KambarioIvertinima>();
            KambarioPrivalumais = new HashSet<KambarioPrivalumai>();
            Rezervacijas = new HashSet<Rezervacija>();
        }

        [Column("kamb_aukstas")]
        public int? KambAukstas { get; set; }
        [Column("kamb_numeris")]
        public int? KambNumeris { get; set; }
        [Column("kamb_kaina")]
        public double? KambKaina { get; set; }
        [Column("kamb_max_svec")]
        public int? KambMaxSvec { get; set; }
        [Column("kamb_aprasymas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KambAprasymas { get; set; }
        [Column("kamb_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KambPavadinimas { get; set; }
        [Key]
        [Column("id_Kambarys")]
        public int IdKambarys { get; set; }
        [Column("fk_KambarioTipaskamb_tipas_id")]
        public int FkKambarioTipaskambTipasId { get; set; }
        [Column("fk_KambarioStatusaskamb_statusas_id")]
        public int FkKambarioStatusaskambStatusasId { get; set; }

        [ForeignKey("FkKambarioStatusaskambStatusasId")]
        [InverseProperty("Kambaries")]
        public virtual KambarioStatusa FkKambarioStatusaskambStatusas { get; set; } = null!;
        [ForeignKey("FkKambarioTipaskambTipasId")]
        [InverseProperty("Kambaries")]
        public virtual KambarioTipa FkKambarioTipaskambTipas { get; set; } = null!;
        [InverseProperty("FkKambarysidKambarysNavigation")]
        public virtual ICollection<KambarioIvertinima> KambarioIvertinimas { get; set; }
        [InverseProperty("FkKambarysidKambarysNavigation")]
        public virtual ICollection<KambarioPrivalumai> KambarioPrivalumais { get; set; }
        [InverseProperty("FkKambarysidKambarysNavigation")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
