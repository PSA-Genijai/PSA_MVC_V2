using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("RoomStatus")]
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("room_statug_id")]
        public int RoomStatugId { get; set; }
        [Column("room_status")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoomStatus1 { get; set; }

        [InverseProperty("FkRoomStatusroomStatug")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
