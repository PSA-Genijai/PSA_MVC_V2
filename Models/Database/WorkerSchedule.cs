using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Worker_schedule")]
    public partial class WorkerSchedule
    {
        [Key]
        [Column("worker_schedule_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerScheduleId { get; set; }
        [Column("s_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string SName { get; set; } = null!;
        [Column("s_type")]
        [StringLength(255)]
        [Unicode(false)]
        public string SType { get; set; } = null!;
        [Column("fk_time_table_id")]
        public int FkTimeTableId { get; set; }

        [ForeignKey("FkTimeTableId")]
        [InverseProperty("WorkerSchedules")]
        public virtual TimeTable FkTimeTable { get; set; } = null!;
    }
}
