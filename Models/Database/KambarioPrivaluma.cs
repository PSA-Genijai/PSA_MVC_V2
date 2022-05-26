using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class KambarioPrivaluma
    {
        public KambarioPrivaluma()
        {
            KambarioPrivalumais = new HashSet<KambarioPrivalumai>();
        }

        [Key]
        [Column("privalumas_id")]
        public int PrivalumasId { get; set; }
        [Column("privalumas_pavadinimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PrivalumasPavadinimas { get; set; }

        [InverseProperty("FkKambarioPrivalumasprivalumas")]
        public virtual ICollection<KambarioPrivalumai> KambarioPrivalumais { get; set; }
    }
}
