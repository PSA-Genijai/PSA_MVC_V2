using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        [Column("bill_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }
        [Column("bill_sum")]
        public double? BillSum { get; set; }
        [Column("fk_Guestg_id")]
        public int FkGuestgId { get; set; }

        [ForeignKey("FkGuestgId")]
        [InverseProperty("Bills")]
        public virtual Guest FkGuestg { get; set; } = null!;
        [InverseProperty("FkBillbill")]
        public virtual Reservation? Reservation { get; set; }
    }
}
