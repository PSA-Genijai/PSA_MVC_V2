using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class CorrespondenceRecipient
    {
        [Column("checked")]
        public bool? Checked { get; set; }
        [Key]
        [Column("entry_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryId { get; set; }
        [Column("fk_Workerw_id")]
        public int FkWorkerwId { get; set; }
        [Column("fk_Correspondencemessage_id")]
        public int FkCorrespondencemessageId { get; set; }

        [ForeignKey("FkCorrespondencemessageId")]
        [InverseProperty("CorrespondenceRecipients")]
        public virtual Correspondence FkCorrespondencemessage { get; set; } = null!;
        [ForeignKey("FkWorkerwId")]
        [InverseProperty("CorrespondenceRecipients")]
        public virtual Worker FkWorkerw { get; set; } = null!;
    }
}
