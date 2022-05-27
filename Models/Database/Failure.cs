using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Failure")]
    public partial class Failure
    {
        [Key]
        [Column("failure_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FailureId { get; set; }
        [Column("failure_description")]
        [StringLength(255)]
        [Unicode(false)]
        public string? FailureDescription { get; set; }
        [Column("fk_FailureTypeid_FailureType")]
        public int FkFailureTypeidFailureType { get; set; }
        [Column("fk_Workerw_id")]
        public int? FkWorkerwId { get; set; }

        [ForeignKey("FkFailureTypeidFailureType")]
        [InverseProperty("Failures")]
        public virtual FailureType FkFailureTypeidFailureTypeNavigation { get; set; } = null!;
        [ForeignKey("FkWorkerwId")]
        [InverseProperty("Failures")]
        public virtual Worker? FkWorkerw { get; set; }
    }
}
