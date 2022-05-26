using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class RouteCategory
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("category_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? CategoryTitle { get; set; }
        [Column("fk_RoutePointspoint_id")]
        public int FkRoutePointspointId { get; set; }

        [ForeignKey("FkRoutePointspointId")]
        [InverseProperty("RouteCategories")]
        public virtual RoutePoint FkRoutePointspoint { get; set; } = null!;
    }
}
