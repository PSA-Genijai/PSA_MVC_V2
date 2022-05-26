using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("excursionPoint")]
    public partial class ExcursionPoint
    {
        [Key]
        [Column("fk_Excursionex_id")]
        public int FkExcursionexId { get; set; }
        [Key]
        [Column("fk_RoutePointspoint_id")]
        public int FkRoutePointspointId { get; set; }

        [ForeignKey("FkExcursionexId")]
        [InverseProperty("ExcursionPoints")]
        public virtual Excursion FkExcursionex { get; set; } = null!;
    }
}
