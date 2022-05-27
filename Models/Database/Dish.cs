using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Dish")]
    public partial class Dish
    {
        public Dish()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        [Key]
        [Column("dish_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishId { get; set; }
        [Column("dish_title")]
        [StringLength(255)]
        [Required]
        [Unicode(false)]
        public string? DishTitle { get; set; }
        [Column("dish_price")]
        public double? DishPrice { get; set; }
        [Column("fk_AdditionalServicesadd_services_id")]
        public int? FkAdditionalServicesaddServicesId { get; set; }

        [ForeignKey("FkAdditionalServicesaddServicesId")]
        [InverseProperty("Dishes")]
        public virtual AdditionalService? FkAdditionalServicesaddServices { get; set; }
        [InverseProperty("FkDishdish")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
