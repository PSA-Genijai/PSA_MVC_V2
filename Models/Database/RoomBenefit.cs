using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("RoomBenefit")]
    public partial class RoomBenefit
    {
        public RoomBenefit()
        {
            RoomBenefit1s = new HashSet<RoomBenefit1>();
        }

        [Key]
        [Column("benefit_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BenefitId { get; set; }
        [Column("benefit_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? BenefitTitle { get; set; }

        [InverseProperty("FkRoomBenefitbenefit")]
        public virtual ICollection<RoomBenefit1> RoomBenefit1s { get; set; }
    }
}
