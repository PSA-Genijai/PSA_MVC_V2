using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("RoomType")]
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("room_type_id")]
        public int RoomTypeId { get; set; }
        [Column("room_type")]
        [StringLength(255)]
        [Unicode(false)]
        public string? RoomType1 { get; set; }

        [InverseProperty("FkRoomTyperoomType")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
