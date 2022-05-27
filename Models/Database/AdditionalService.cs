using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    public partial class AdditionalService
    {
        public AdditionalService()
        {
            Dishes = new HashSet<Dish>();
            Excursions = new HashSet<Excursion>();
        }

        [Key]
        [Column("add_services_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddServicesId { get; set; }
        [Column("add_services_price")]
        public double? AddServicesPrice { get; set; }
        [Column("fk_Reservationreservation_id")]
        public int FkReservationreservationId { get; set; }

        [ForeignKey("FkReservationreservationId")]
        [InverseProperty("AdditionalServices")]
        public virtual Reservation FkReservationreservation { get; set; } = null!;
        [InverseProperty("FkAdditionalServicesaddServices")]
        public virtual ICollection<Dish> Dishes { get; set; }
        [InverseProperty("FkAdditionalServicesaddServices")]
        public virtual ICollection<Excursion> Excursions { get; set; }
    }
}
