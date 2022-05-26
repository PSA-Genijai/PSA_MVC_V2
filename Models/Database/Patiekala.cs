using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Patiekala
    {
        public Patiekala()
        {
            Alergenas = new HashSet<Alergena>();
        }

        [Key]
        [Column("patiekalas_id")]
        public int PatiekalasId { get; set; }
        [Column("patiekalas_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PatiekalasPavadinimas { get; set; }
        [Column("patiekalas_kaina")]
        public double? PatiekalasKaina { get; set; }
        [Column("fk_PapildomosPaslaugospap_paslaugos_id")]
        public int? FkPapildomosPaslaugospapPaslaugosId { get; set; }

        [ForeignKey("FkPapildomosPaslaugospapPaslaugosId")]
        [InverseProperty("Patiekalas")]
        public virtual PapildomosPaslaugo? FkPapildomosPaslaugospapPaslaugos { get; set; }
        [InverseProperty("FkPatiekalaspatiekalas")]
        public virtual ICollection<Alergena> Alergenas { get; set; }
    }
}
