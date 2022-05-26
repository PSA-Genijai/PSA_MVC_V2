using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Saskaitum
    {
        [Key]
        [Column("saskaita_id")]
        public int SaskaitaId { get; set; }
        [Column("saskaita_suma")]
        public double? SaskaitaSuma { get; set; }
        [Column("fk_Sveciass_id")]
        public int FkSveciassId { get; set; }

        [ForeignKey("FkSveciassId")]
        [InverseProperty("Saskaita")]
        public virtual Svecia FkSveciass { get; set; } = null!;
        [InverseProperty("FkSaskaitasaskaita")]
        public virtual Rezervacija Rezervacija { get; set; } = null!;
    }
}
