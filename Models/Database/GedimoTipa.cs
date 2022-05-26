using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class GedimoTipa
    {
        public GedimoTipa()
        {
            Gedimas = new HashSet<Gedima>();
        }

        [Column("gedimo_tipas_id")]
        public int? GedimoTipasId { get; set; }
        [Column("gedimo_tipas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GedimoTipas { get; set; }
        [Key]
        [Column("id_GedimoTipas")]
        public int IdGedimoTipas { get; set; }

        [InverseProperty("FkGedimoTipasidGedimoTipasNavigation")]
        public virtual ICollection<Gedima> Gedimas { get; set; }
    }
}
