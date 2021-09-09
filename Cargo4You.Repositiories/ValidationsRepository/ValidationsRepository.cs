using Cargo4You.Models;
using Cargo4You.Models.Entities;

namespace Cargo4You.Repositiories
{
    public class ValidationsRepository : BaseRepository<Validations>, IValidationsRepository
    {
        public ValidationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
