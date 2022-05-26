using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("KambarioPrivalumai")]
    public partial class KambarioPrivalumai
    {
        [Key]
        [Column("kamb_privalumai_id")]
        public int KambPrivalumaiId { get; set; }
        [Column("privalumai_priskirimo_data", TypeName = "date")]
        public DateTime? PrivalumaiPriskirimoData { get; set; }
        [Column("fk_KambarioPrivalumasprivalumas_id")]
        public int FkKambarioPrivalumasprivalumasId { get; set; }
        [Column("fk_Kambarysid_Kambarys")]
        public int FkKambarysidKambarys { get; set; }

        [ForeignKey("FkKambarioPrivalumasprivalumasId")]
        [InverseProperty("KambarioPrivalumais")]
        public virtual KambarioPrivaluma FkKambarioPrivalumasprivalumas { get; set; } = null!;
        [ForeignKey("FkKambarysidKambarys")]
        [InverseProperty("KambarioPrivalumais")]
        public virtual Kambary FkKambarysidKambarysNavigation { get; set; } = null!;
    }
}
