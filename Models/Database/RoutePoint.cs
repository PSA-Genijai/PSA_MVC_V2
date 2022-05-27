using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class RoutePoint
    {
        public RoutePoint()
        {
            RouteCategories = new HashSet<RouteCategory>();
        }

        [Key]
        [Column("point_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PointId { get; set; }
        [Column("point_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? PointTitle { get; set; }
        [Column("point_category")]
        public int? PointCategory { get; set; }
        [Column("work_time_from", TypeName = "date")]
        public DateTime? WorkTimeFrom { get; set; }
        [Column("work_time_up_to", TypeName = "date")]
        public DateTime? WorkTimeUpTo { get; set; }

        [InverseProperty("FkRoutePointspoint")]
        public virtual ICollection<RouteCategory> RouteCategories { get; set; }
    }
}
