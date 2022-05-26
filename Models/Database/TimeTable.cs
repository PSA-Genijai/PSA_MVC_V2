using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Time_table")]
    public partial class TimeTable
    {
        public TimeTable()
        {
            WorkerSchedules = new HashSet<WorkerSchedule>();
        }

        [Key]
        [Column("time_table_id")]
        public int TimeTableId { get; set; }
        [Column("from", TypeName = "date")]
        public DateTime From { get; set; }
        [Column("to", TypeName = "date")]
        public DateTime To { get; set; }

        [InverseProperty("FkTimeTable")]
        public virtual ICollection<WorkerSchedule> WorkerSchedules { get; set; }
    }
}
