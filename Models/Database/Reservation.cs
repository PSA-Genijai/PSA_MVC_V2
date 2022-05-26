using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Reservation
    {
        public Reservation()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        [Key]
        [Column("reservation_id")]
        public int ReservationId { get; set; }
        [Column("creation_date", TypeName = "date")]
        public DateTime? CreationDate { get; set; }
        [Column("checkin_date", TypeName = "date")]
        public DateTime? CheckinDate { get; set; }
        [Column("checkout_date", TypeName = "date")]
        public DateTime? CheckoutDate { get; set; }
        [Column("adults")]
        public int? Adults { get; set; }
        [Column("children")]
        public int? Children { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("fk_Billbill_id")]
        public int FkBillbillId { get; set; }
        [Column("fk_Guestg_id")]
        public int FkGuestgId { get; set; }
        [Column("fk_Roomid_Room")]
        public int FkRoomidRoom { get; set; }
        [Column("fk_Workerw_id")]
        public int FkWorkerwId { get; set; }
        [Column("fk_ReservationStatusres_status_id")]
        public int FkReservationStatusresStatusId { get; set; }

        [ForeignKey("FkBillbillId")]
        [InverseProperty("Reservation")]
        public virtual Bill FkBillbill { get; set; } = null!;
        [ForeignKey("FkGuestgId")]
        [InverseProperty("Reservations")]
        public virtual Guest FkGuestg { get; set; } = null!;
        [ForeignKey("FkReservationStatusresStatusId")]
        [InverseProperty("Reservations")]
        public virtual ReservationStatus FkReservationStatusresStatus { get; set; } = null!;
        [ForeignKey("FkRoomidRoom")]
        [InverseProperty("Reservations")]
        public virtual Room FkRoomidRoomNavigation { get; set; } = null!;
        [ForeignKey("FkWorkerwId")]
        [InverseProperty("Reservations")]
        public virtual Worker FkWorkerw { get; set; } = null!;
        [InverseProperty("FkReservationreservation")]
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
