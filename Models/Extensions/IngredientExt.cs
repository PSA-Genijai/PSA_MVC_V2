using System.ComponentModel.DataAnnotations.Schema;

namespace PSA_MVC_V2.Models.Database
{
    public partial class Ingredient
    {
        [NotMapped]
        public bool Checked;
    }
}
