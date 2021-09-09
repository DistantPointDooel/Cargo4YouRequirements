using System.ComponentModel.DataAnnotations;

namespace Cargo4You.Models.Entities
{
    public class Enums
    {
        public enum MeasureUnit
        {
            [Display(Name = "cm3")]
            Volume,

            [Display(Name = "kg")]
            Weight
        }
    }
}
