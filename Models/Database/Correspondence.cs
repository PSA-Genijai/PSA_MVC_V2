using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Correspondence")]
    public partial class Correspondence
    {
        public Correspondence()
        {
            CorrespondenceRecipients = new HashSet<CorrespondenceRecipient>();
        }

        [Key]
        [Column("message_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        [Column("message_content")]
        [StringLength(255)]
        [Unicode(false)]
        public string? MessageContent { get; set; }
        [Column("sent_time", TypeName = "date")]
        public DateTime? SentTime { get; set; }
        [Column("fk_Workerw_id")]
        public int FkWorkerwId { get; set; }

        [ForeignKey("FkWorkerwId")]
        [InverseProperty("Correspondences")]
        public virtual Worker FkWorkerw { get; set; } = null!;
        [InverseProperty("FkCorrespondencemessage")]
        public virtual ICollection<CorrespondenceRecipient> CorrespondenceRecipients { get; set; }
    }
}
