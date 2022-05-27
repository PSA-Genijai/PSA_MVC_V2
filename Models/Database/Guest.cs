using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Guest")]
    public partial class Guest
    {
        public Guest()
        {
            Bills = new HashSet<Bill>();
            Messages = new HashSet<Message>();
            Reservations = new HashSet<Reservation>();
            RoomEvaluations = new HashSet<RoomEvaluation>();
        }

        [Key]
        [Column("g_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GId { get; set; }
        [Column("g_nickname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GNickname { get; set; }
        [Column("g_password")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GPassword { get; set; }
        [Column("g_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GName { get; set; }
        [Column("g_lastname")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GLastname { get; set; }
        [Column("g_email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GEmail { get; set; }
        [Column("g_birth_date", TypeName = "date")]
        public DateTime? GBirthDate { get; set; }
        [Column("g_adress")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GAdress { get; set; }
        [Column("g_phone_number")]
        [StringLength(255)]
        [Unicode(false)]
        public string? GPhoneNumber { get; set; }
        [Column("g_gender")]
        public bool? GGender { get; set; }

        [InverseProperty("FkGuestg")]
        public virtual ICollection<Bill> Bills { get; set; }
        [InverseProperty("FkGuestg")]
        public virtual ICollection<Message> Messages { get; set; }
        [InverseProperty("FkGuestg")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        [InverseProperty("FkGuestg")]
        public virtual ICollection<RoomEvaluation> RoomEvaluations { get; set; }
    }
}
