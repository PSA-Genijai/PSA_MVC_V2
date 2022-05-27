using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Reservation")]
    public partial class Reservation
    {
        public Reservation()
        {
            AdditionalServices = new HashSet<AdditionalService>();
        }

        [Key]
        [Column("reservation_id")]
        [DisplayName("Rezervacijos ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        [Column("creation_date", TypeName = "date")]
        [DisplayName("Sukūrimo data")]
        public DateTime? CreationDate { get; set; }
        [Column("checkin_date", TypeName = "date")]
        [DisplayName("Atvykimo data")]
        public DateTime? CheckinDate { get; set; }
        [Column("checkout_date", TypeName = "date")]
        [DisplayName("Išvykimo data")]
        public DateTime? CheckoutDate { get; set; }

        [Column("adults")]
        [DisplayName("Suaugusieji")]
        public int? Adults { get; set; }
        [Column("children")]
        [DisplayName("Vaikai")]
        public int? Children { get; set; }
        [Column("price")]
        [DisplayName("Kaina")]
        public double? Price { get; set; }
        [Column("fk_Billbill_id")]
        public int? FkBillbillId { get; set; }
        [Column("fk_Guestg_id")]
        public int FkGuestgId { get; set; }
        [Column("fk_Roomid_Room")]
        public int FkRoomidRoom { get; set; }
        [Column("fk_Workerw_id")]
        public int FkWorkerwId { get; set; }
        [Column("fk_ReservationStatusres_status_id")]
        public int FkReservationStatusresStatusId { get; set; }

        [ForeignKey("FkBillbillId")]
        [DisplayName("Užsakymo ID")]
        [InverseProperty("Reservation")]
        public virtual Bill? FkBillbill { get; set; }
        [ForeignKey("FkGuestgId")]
        [DisplayName("Svečio ID")]
        [InverseProperty("Reservations")]
        public virtual Guest FkGuestg { get; set; } = null!;
        [ForeignKey("FkReservationStatusresStatusId")]
        [DisplayName("Statuso ID")]
        [InverseProperty("Reservations")]
        public virtual ReservationStatus FkReservationStatusresStatus { get; set; } = null!;
        [ForeignKey("FkRoomidRoom")]
        [DisplayName("Kambario ID")]
        [InverseProperty("Reservations")]
        public virtual Room FkRoomidRoomNavigation { get; set; } = null!;
        [ForeignKey("FkWorkerwId")]
        [DisplayName("Administratorio ID")]
        [InverseProperty("Reservations")]
        public virtual Worker FkWorkerw { get; set; } = null!;
        [InverseProperty("FkReservationreservation")]
        public virtual ICollection<AdditionalService> AdditionalServices { get; set; }
    }
}
