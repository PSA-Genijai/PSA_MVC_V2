using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Guide")]
    public partial class Guide
    {
        [Key]
        [Column("g_id")]
        public int GId { get; set; }
        [Column("g_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GName { get; set; }
        [Column("g_lastname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GLastname { get; set; }
        [Column("g_birth_date", TypeName = "date")]
        public DateTime? GBirthDate { get; set; }
        [Column("g_email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GEmail { get; set; }
        [Column("g_phone_num")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GPhoneNum { get; set; }
        [Column("fk_Excursionex_id")]
        public int FkExcursionexId { get; set; }

        [ForeignKey("FkExcursionexId")]
        [InverseProperty("Guides")]
        public virtual Excursion FkExcursionex { get; set; } = null!;
    }
}
