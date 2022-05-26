using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class KambarioIvertinima
    {
        [Key]
        [Column("kamb_ivertinimas_id")]
        public int KambIvertinimasId { get; set; }
        [Column("kamb_ivertinimas")]
        public int? KambIvertinimas { get; set; }
        [Column("kamb_ivertinimas_data", TypeName = "date")]
        public DateTime? KambIvertinimasData { get; set; }
        [Column("kamb_atsiliepimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? KambAtsiliepimas { get; set; }
        [Column("fk_Kambarysid_Kambarys")]
        public int FkKambarysidKambarys { get; set; }
        [Column("fk_Sveciass_id")]
        public int FkSveciassId { get; set; }

        [ForeignKey("FkKambarysidKambarys")]
        [InverseProperty("KambarioIvertinimas")]
        public virtual Kambary FkKambarysidKambarysNavigation { get; set; } = null!;
        [ForeignKey("FkSveciassId")]
        [InverseProperty("KambarioIvertinimas")]
        public virtual Svecia FkSveciass { get; set; } = null!;
    }
}
