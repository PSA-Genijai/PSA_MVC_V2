using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("RoomEvaluation")]
    public partial class RoomEvaluation
    {
        [Key]
        [Column("room_evaluation_id")]
        public int RoomEvaluationId { get; set; }
        [Column("room_evaluation")]
        public int? RoomEvaluation1 { get; set; }
        [Column("room_evaluation_date", TypeName = "date")]
        public DateTime? RoomEvaluationDate { get; set; }
        [Column("room_review")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoomReview { get; set; }
        [Column("fk_Roomid_Room")]
        public int FkRoomidRoom { get; set; }
        [Column("fk_Guestg_id")]
        public int FkGuestgId { get; set; }

        [ForeignKey("FkGuestgId")]
        [InverseProperty("RoomEvaluations")]
        public virtual Guest FkGuestg { get; set; } = null!;
        [ForeignKey("FkRoomidRoom")]
        [InverseProperty("RoomEvaluations")]
        public virtual Room FkRoomidRoomNavigation { get; set; } = null!;
    }
}
