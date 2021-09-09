using System.ComponentModel.DataAnnotations.Schema;

namespace Cargo4You.Models.Entities
{
    public partial class Validations
    {
        public int Id { get; set; }

        public int ValidationValue { get; set; }

        public Enums.MeasureUnit MeasureUnit { get; set; }

        public string Operator { get; set; }

        public int CourierId { get; set; }

        [ForeignKey(nameof(CourierId))]
        public Couriers Courier { get; set; }
    }

    public partial class Validations 
    {
        public bool Validate(int userInput)
        {
            switch (Operator)
            {
                case "<":
                    return userInput < ValidationValue;
                case ">":
                    return userInput > ValidationValue;
                case "=":
                    return userInput == ValidationValue;
                case "<=":
                    return userInput <= ValidationValue;
                case ">=":
                    return userInput >= ValidationValue;
                default:
                    break;
            }

            return true;
        }
    }
}
