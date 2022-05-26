using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Darbuotojo_tipas")]
    public partial class DarbuotojoTipa
    {
        public DarbuotojoTipa()
        {
            Darbuotojas = new HashSet<Darbuotoja>();
        }

        [Key]
        [Column("darb_tipas_id")]
        public int DarbTipasId { get; set; }
        [Column("darb_tipas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? DarbTipas { get; set; }

        [InverseProperty("FkDarbuotojoTipasdarbTipas")]
        public virtual ICollection<Darbuotoja> Darbuotojas { get; set; }
    }
}
