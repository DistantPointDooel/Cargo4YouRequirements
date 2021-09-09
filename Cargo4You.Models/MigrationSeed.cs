using Microsoft.EntityFrameworkCore.Migrations;

namespace Cargo4You.Models
{
    public static class MigrationSeed
    {
        public static void SeedInitialData(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Couriers(Name)\nValues('Cargo4You'),('ShipFaster'),('MaltaShip')");

            migrationBuilder.Sql(
                "INSERT INTO Validations(ValidationValue, MeasureUnit, Operator, CourierId)\nValues(20, 1, '<=', 1),(2000, 0, '<=', 1),(10, 1, '>' , 2),(30, 1, '<=', 2),(1700, 0, '<=', 2),(10, 1, '>=', 3),(500, 0, '>=', 3)"
                );

            migrationBuilder.Sql(
                "INSERT INTO Calculations(Operator,ValueLimit,MeasureUnit,CourierId,PredefinedCost,IncrementalCost)\nValues('<=', 1000, 0, 1, 10, null),('>', 1000, 0, 1, 20, null),('<=', 2000, 0, 1, 20, null),('<=', 2, 1, 1, 15, null),('>', 2, 1, 1, 18, null),('<=', 15, 1, 1, 18, null),('>', 15, 1, 1, 35, null),('<=', 20, 1, 1, 35, null),('<=', 1000, 0, 2, 11.99, null),( '>' , 1000, 0, 2, 21.99, null),('<=', 1700, 0, 2, 21.99, null),('>', 10, 1, 2, 16.50, null),('<=', 15, 1, 2, 16.50, null),('>', 15, 1, 2, 36.50, null),('<=', 25, 1, 2, 36.50, null),('>', 25, 1, 2, 40, 0.417),('<=', 1000,0, 3, 9.50, null),('>', 1000, 0, 3, 19.50, null),('<=', 2000, 0, 3, 19.50, null),('>', 2000, 0, 3, 48.50, null),('<=', 5000, 0, 3, 48.50, null),('>', 5000, 0, 3, 147.50, null),('>', 10, 1, 3, 16.99, null),('<=', 20, 1, 3, 16.99, null),('>', 20, 1, 3, 33.99, null),('<=', 30, 1, 3, 33.99, null),('>', 30, 1, 3, 43.99, 0.41)"
                );
        }

    }
}
