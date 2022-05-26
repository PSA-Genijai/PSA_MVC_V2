using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class KambarioStatusa
    {
        public KambarioStatusa()
        {
            Kambaries = new HashSet<Kambary>();
        }

        [Key]
        [Column("kamb_statusas_id")]
        public int KambStatusasId { get; set; }
        [Column("kamb_statusas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KambStatusas { get; set; }

        [InverseProperty("FkKambarioStatusaskambStatusas")]
        public virtual ICollection<Kambary> Kambaries { get; set; }
    }
}
