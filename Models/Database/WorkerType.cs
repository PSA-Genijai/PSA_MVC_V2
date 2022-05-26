using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Worker_type")]
    public partial class WorkerType
    {
        public WorkerType()
        {
            Workers = new HashSet<Worker>();
        }

        [Key]
        [Column("worker_type_id")]
        public int WorkerTypeId { get; set; }
        [Column("worker_type")]
        [StringLength(255)]
        [Unicode(false)]
        public string? WorkerType1 { get; set; }

        [InverseProperty("FkWorkerTypeworkerType")]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
