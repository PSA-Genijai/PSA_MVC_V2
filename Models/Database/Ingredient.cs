using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PSA_MVC_V2.Models.Database
{
    [Table("Ingredient")]
    public partial class Ingredient
    {
        [Key]
        [Column("ingredient_id")]
        public int IngredientId { get; set; }
        [Column("ingredient_title")]
        [StringLength(255)]
        [Unicode(false)]
        public string? IngredientTitle { get; set; }
        [Column("fk_Dishdish_id")]
        public int FkDishdishId { get; set; }

        [ForeignKey("FkDishdishId")]
        [InverseProperty("Ingredients")]
        public virtual Dish FkDishdish { get; set; } = null!;
    }
}
