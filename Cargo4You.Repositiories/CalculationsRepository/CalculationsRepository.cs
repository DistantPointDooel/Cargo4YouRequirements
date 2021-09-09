using Cargo4You.Models;
using Cargo4You.Models.Entities;

namespace Cargo4You.Repositiories
{
    public class CalculationsRepository : BaseRepository<Calculations>, ICalculationsRepository
    {
        public CalculationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}