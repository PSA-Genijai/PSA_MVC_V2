using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("KorespondecijaGavejai")]
    public partial class KorespondecijaGavejai
    {
        [Column("perziureta")]
        public bool? Perziureta { get; set; }
        [Key]
        [Column("entry_id")]
        public int EntryId { get; set; }
        [Column("fk_Darbuotojasd_id")]
        public int FkDarbuotojasdId { get; set; }
        [Column("fk_Korespondencijazinute_id")]
        public int FkKorespondencijazinuteId { get; set; }

        [ForeignKey("FkDarbuotojasdId")]
        [InverseProperty("KorespondecijaGavejais")]
        public virtual Darbuotoja FkDarbuotojasd { get; set; } = null!;
        [ForeignKey("FkKorespondencijazinuteId")]
        [InverseProperty("KorespondecijaGavejais")]
        public virtual Korespondencija FkKorespondencijazinute { get; set; } = null!;
    }
}
