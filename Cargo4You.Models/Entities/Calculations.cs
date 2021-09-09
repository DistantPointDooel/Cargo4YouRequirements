using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo4You.Models.Entities
{
    public partial class Calculations
    {
        public int Id { get; set; }

        public string Operator { get; set; }

        public int CourierId { get; set; }

        [ForeignKey(nameof(CourierId))]
        public Couriers Courier { get; set; }

        public int ValueLimit { get; set; }

        public Enums.MeasureUnit MeasureUnit { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PredefinedCost { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? IncrementalCost { get; set; }
    }

    public partial class Calculations
    {
        public decimal? Calculate(int userInput)
        {
            decimal? result = null;

            switch (Operator)
            {
                case "<":
                    result = ReturnCost(userInput < ValueLimit, userInput);
                    break;
                case ">":
                    result = ReturnCost(userInput > ValueLimit, userInput);
                    break;
                case "=":
                    result = ReturnCost(userInput == ValueLimit, userInput);
                    break;
                case "<=":
                    result = ReturnCost(userInput <= ValueLimit, userInput);
                    break;
                case ">=":
                    result = ReturnCost(userInput >= ValueLimit, userInput);
                    break;
                default:
                    break;
            }

            return result;
        }

        public decimal? ReturnCost(bool condition, int userInput)
        {
            if (condition)
            {
                return IncrementalCost.HasValue ? PredefinedCost + (IncrementalCost.Value * (userInput - ValueLimit)) : PredefinedCost;
            }

            return null;
        }
    }
}
