using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Message")]
    public partial class Message
    {
        public Message()
        {
            Workers = new HashSet<Worker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Correspondence { get; set; }
        [Column("message")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Message1 { get; set; }
        [Column("checked")]
        public bool? Checked { get; set; }
        [Column("fk_Guestg_id")]
        public int FkGuestgId { get; set; }

        [ForeignKey("FkGuestgId")]
        [InverseProperty("Messages")]
        public virtual Guest FkGuestg { get; set; } = null!;
        [InverseProperty("FkMessageCorrespondenceNavigation")]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
