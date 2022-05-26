using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Room")]
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
            RoomBenefit1s = new HashSet<RoomBenefit1>();
            RoomEvaluations = new HashSet<RoomEvaluation>();
        }

        [Column("room_floor")]
        public int RoomFloor { get; set; }
        [Column("room_number")]
        public int? RoomNumber { get; set; }
        [Column("room_price")]
        public double? RoomPrice { get; set; }
        [Column("room_max_guests")]
        public int? RoomMaxGuests { get; set; }
        [Column("room_description")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoomDescription { get; set; }
        [Column("room_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoomTitle { get; set; }
        [Key]
        [Column("id_Room")]
        public int IdRoom { get; set; }
        [Column("fk_RoomTyperoom_type_id")]
        public int FkRoomTyperoomTypeId { get; set; }
        [Column("fk_RoomStatusroom_statug_id")]
        public int FkRoomStatusroomStatugId { get; set; }

        [ForeignKey("FkRoomStatusroomStatugId")]
        [InverseProperty("Rooms")]
        public virtual RoomStatus FkRoomStatusroomStatug { get; set; } = null!;
        [ForeignKey("FkRoomTyperoomTypeId")]
        [InverseProperty("Rooms")]
        public virtual RoomType FkRoomTyperoomType { get; set; } = null!;
        [InverseProperty("FkRoomidRoomNavigation")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        [InverseProperty("FkRoomidRoomNavigation")]
        public virtual ICollection<RoomBenefit1> RoomBenefit1s { get; set; }
        [InverseProperty("FkRoomidRoomNavigation")]
        public virtual ICollection<RoomEvaluation> RoomEvaluations { get; set; }
    }
}
