using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Ekskursija")]
    public partial class Ekskursija
    {
        public Ekskursija()
        {
            EkskursijosPunkta = new HashSet<EkskursijosPunkta>();
            Gida = new HashSet<Gida>();
        }

        [Key]
        [Column("eks_id")]
        public int EksId { get; set; }
        [Column("eks_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? EksPavadinimas { get; set; }
        [Column("eks_kaina")]
        public double? EksKaina { get; set; }
        [Column("eks_data", TypeName = "date")]
        public DateTime? EksData { get; set; }
        [Column("fk_PapildomosPaslaugospap_paslaugos_id")]
        public int? FkPapildomosPaslaugospapPaslaugosId { get; set; }

        [ForeignKey("FkPapildomosPaslaugospapPaslaugosId")]
        [InverseProperty("Ekskursijas")]
        public virtual PapildomosPaslaugo? FkPapildomosPaslaugospapPaslaugos { get; set; }
        [InverseProperty("FkEkskursijaeks")]
        public virtual ICollection<EkskursijosPunkta> EkskursijosPunkta { get; set; }
        [InverseProperty("FkEkskursijaeks")]
        public virtual ICollection<Gida> Gida { get; set; }
    }
}
