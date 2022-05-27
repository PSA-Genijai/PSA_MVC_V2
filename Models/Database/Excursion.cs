using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Excursion")]
    public partial class Excursion
    {
        public Excursion()
        {
            ExcursionPoints = new HashSet<ExcursionPoint>();
            Guides = new HashSet<Guide>();
        }

        [Key]
        [Column("ex_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExId { get; set; }
        [Column("ex_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ExTitle { get; set; }
        [Column("ex_price")]
        public double? ExPrice { get; set; }
        [Column("ex_date", TypeName = "date")]
        public DateTime? ExDate { get; set; }
        [Column("fk_AdditionalServicesadd_services_id")]
        public int? FkAdditionalServicesaddServicesId { get; set; }

        [ForeignKey("FkAdditionalServicesaddServicesId")]
        [InverseProperty("Excursions")]
        public virtual AdditionalService? FkAdditionalServicesaddServices { get; set; }
        [InverseProperty("FkExcursionex")]
        public virtual ICollection<ExcursionPoint> ExcursionPoints { get; set; }
        [InverseProperty("FkExcursionex")]
        public virtual ICollection<Guide> Guides { get; set; }
    }
}
