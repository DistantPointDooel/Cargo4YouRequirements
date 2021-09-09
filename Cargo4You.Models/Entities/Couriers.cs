using System;
using System.Collections.Generic;
using System.Linq;

namespace Cargo4You.Models.Entities
{
    public partial class Couriers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Validations> Validations { get; set; }

        public ICollection<Calculations> Calculations { get; set; }
    }

    public partial class Couriers
    {
        public decimal GetPrice(int volume, int weight)
        {
            decimal price = default;

            this.Calculations.GroupBy(x => x.MeasureUnit).ToList().ForEach(calculationGroup =>
            {
                decimal? cmCost = null;
                decimal? kgCost = null;

                calculationGroup.OrderBy(x => x.ValueLimit).ToList().ForEach(calculation =>
                {
                    if (calculation.MeasureUnit.Equals(Enums.MeasureUnit.Volume) && !cmCost.HasValue)
                    {
                        cmCost = calculation.Calculate(volume);
                    }
                    else if (!kgCost.HasValue)
                    {
                        kgCost = calculation.Calculate(weight);
                    }
                });


                price = Math.Max(kgCost ?? 0, cmCost ?? 0);

            });

            return price;
        }
    }
}
