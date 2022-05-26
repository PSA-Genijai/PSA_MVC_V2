using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("RoomBenefits")]
    public partial class RoomBenefit1
    {
        [Key]
        [Column("room_benefits_id")]
        public int RoomBenefitsId { get; set; }
        [Column("benefit_assignment_date", TypeName = "date")]
        public DateTime? BenefitAssignmentDate { get; set; }
        [Column("fk_RoomBenefitbenefit_id")]
        public int FkRoomBenefitbenefitId { get; set; }
        [Column("fk_Roomid_Room")]
        public int FkRoomidRoom { get; set; }

        [ForeignKey("FkRoomBenefitbenefitId")]
        [InverseProperty("RoomBenefit1s")]
        public virtual RoomBenefit FkRoomBenefitbenefit { get; set; } = null!;
        [ForeignKey("FkRoomidRoom")]
        [InverseProperty("RoomBenefit1s")]
        public virtual Room FkRoomidRoomNavigation { get; set; } = null!;
    }
}
