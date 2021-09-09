using Cargo4You.Repositiories;

namespace Cargo4You.Services
{
    public class CalculationsService : ICalculationsService
    {
        private readonly ICalculationsRepository calculationsRepository;

        public CalculationsService(ICalculationsRepository calculationsRepository)
        {
            this.calculationsRepository = calculationsRepository;
        }
    }
}
