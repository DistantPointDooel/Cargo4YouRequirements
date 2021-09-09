using Cargo4You.Models;
using Cargo4You.Models.Entities;

namespace Cargo4You.Repositiories
{
    public class CouriersRepository : BaseRepository<Couriers> , ICouriersRepository
    {
        public CouriersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
