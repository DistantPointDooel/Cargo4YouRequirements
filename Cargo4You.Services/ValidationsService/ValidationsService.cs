using Cargo4You.Repositiories;

namespace Cargo4You.Services
{
    public class ValidationsService : IValidationsService
    {
        private readonly IValidationsRepository validationsRepository;

        public ValidationsService(IValidationsRepository validationsRepository)
        {
            this.validationsRepository = validationsRepository;
        }
    }
}
