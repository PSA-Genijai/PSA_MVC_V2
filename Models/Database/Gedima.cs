using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Gedima
    {
        [Key]
        [Column("gedimas_id")]
        public int GedimasId { get; set; }
        [Column("gedimas_aprasymas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GedimasAprasymas { get; set; }
        [Column("fk_GedimoTipasid_GedimoTipas")]
        public int FkGedimoTipasidGedimoTipas { get; set; }
        [Column("fk_Darbuotojasd_id")]
        public int? FkDarbuotojasdId { get; set; }

        [ForeignKey("FkDarbuotojasdId")]
        [InverseProperty("Gedimas")]
        public virtual Darbuotoja? FkDarbuotojasd { get; set; }
        [ForeignKey("FkGedimoTipasidGedimoTipas")]
        [InverseProperty("Gedimas")]
        public virtual GedimoTipa FkGedimoTipasidGedimoTipasNavigation { get; set; } = null!;
    }
}
