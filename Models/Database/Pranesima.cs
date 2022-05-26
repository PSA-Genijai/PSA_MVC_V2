using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Pranesima
    {
        public Pranesima()
        {
            Darbuotojas = new HashSet<Darbuotoja>();
        }

        [Key]
        [Column("pranesimas_id")]
        public int PranesimasId { get; set; }
        [Column("pranesimas")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Pranesimas { get; set; }
        [Column("perziureta")]
        public bool? Perziureta { get; set; }
        [Column("fk_Sveciass_id")]
        public int FkSveciassId { get; set; }

        [ForeignKey("FkSveciassId")]
        [InverseProperty("Pranesimas")]
        public virtual Svecia FkSveciass { get; set; } = null!;
        [InverseProperty("FkPranesimaspranesimas")]
        public virtual ICollection<Darbuotoja> Darbuotojas { get; set; }
    }
}
