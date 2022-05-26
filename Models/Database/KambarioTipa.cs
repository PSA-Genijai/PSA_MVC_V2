using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class KambarioTipa
    {
        public KambarioTipa()
        {
            Kambaries = new HashSet<Kambary>();
        }

        [Key]
        [Column("kamb_tipas_id")]
        public int KambTipasId { get; set; }
        [Column("kamb_tipas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KambTipas { get; set; }

        [InverseProperty("FkKambarioTipaskambTipas")]
        public virtual ICollection<Kambary> Kambaries { get; set; }
    }
}
