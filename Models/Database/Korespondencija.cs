using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Korespondencija")]
    public partial class Korespondencija
    {
        public Korespondencija()
        {
            KorespondecijaGavejais = new HashSet<KorespondecijaGavejai>();
        }

        [Key]
        [Column("zinute_id")]
        public int ZinuteId { get; set; }
        [Column("zinute")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Zinute { get; set; }
        [Column("issiuntimo_laikas", TypeName = "date")]
        public DateTime? IssiuntimoLaikas { get; set; }
        [Column("fk_Darbuotojasd_id")]
        public int FkDarbuotojasdId { get; set; }

        [ForeignKey("FkDarbuotojasdId")]
        [InverseProperty("Korespondencijas")]
        public virtual Darbuotoja FkDarbuotojasd { get; set; } = null!;
        [InverseProperty("FkKorespondencijazinute")]
        public virtual ICollection<KorespondecijaGavejai> KorespondecijaGavejais { get; set; }
    }
}
