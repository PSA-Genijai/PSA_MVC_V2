using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class RezervacijosStatusa
    {
        public RezervacijosStatusa()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        [Key]
        [Column("rez_statusas_id")]
        public int RezStatusasId { get; set; }
        [Column("rez_statusas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RezStatusas { get; set; }

        [InverseProperty("FkRezervacijosStatusasrezStatusas")]
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
