using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class PapildomosPaslaugo
    {
        public PapildomosPaslaugo()
        {
            Ekskursijas = new HashSet<Ekskursija>();
            Patiekalas = new HashSet<Patiekala>();
        }

        [Key]
        [Column("pap_paslaugos_id")]
        public int PapPaslaugosId { get; set; }
        [Column("pap_paslaugos_kaina")]
        public double? PapPaslaugosKaina { get; set; }
        [Column("fk_Rezervacijarezervacija_id")]
        public int FkRezervacijarezervacijaId { get; set; }

        [ForeignKey("FkRezervacijarezervacijaId")]
        [InverseProperty("PapildomosPaslaugos")]
        public virtual Rezervacija FkRezervacijarezervacija { get; set; } = null!;
        [InverseProperty("FkPapildomosPaslaugospapPaslaugos")]
        public virtual ICollection<Ekskursija> Ekskursijas { get; set; }
        [InverseProperty("FkPapildomosPaslaugospapPaslaugos")]
        public virtual ICollection<Patiekala> Patiekalas { get; set; }
    }
}
