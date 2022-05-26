using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("ekskursijosPunktas")]
    public partial class EkskursijosPunkta
    {
        [Key]
        [Column("fk_Ekskursijaeks_id")]
        public int FkEkskursijaeksId { get; set; }
        [Key]
        [Column("fk_MarsrutoPunktaipunkto_id")]
        public int FkMarsrutoPunktaipunktoId { get; set; }

        [ForeignKey("FkEkskursijaeksId")]
        [InverseProperty("EkskursijosPunkta")]
        public virtual Ekskursija FkEkskursijaeks { get; set; } = null!;
    }
}
