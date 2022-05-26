using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("FailureType")]
    public partial class FailureType
    {
        public FailureType()
        {
            Failures = new HashSet<Failure>();
        }

        [Column("failure_type_id")]
        public int? FailureTypeId { get; set; }
        [Column("failure_type")]
        [StringLength(255)]
        [Unicode(false)]
        public string? FailureType1 { get; set; }
        [Key]
        [Column("id_FailureType")]
        public int IdFailureType { get; set; }

        [InverseProperty("FkFailureTypeidFailureTypeNavigation")]
        public virtual ICollection<Failure> Failures { get; set; }
    }
}
