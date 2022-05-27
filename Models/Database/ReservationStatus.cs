using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("ReservationStatus")]
    public partial class ReservationStatus
    {
        public ReservationStatus()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [Column("res_status_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResStatusId { get; set; }
        [Column("res_status")]
        [StringLength(255)]
        [Unicode(false)]
        public string? ResStatus { get; set; }

        [InverseProperty("FkReservationStatusresStatus")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
