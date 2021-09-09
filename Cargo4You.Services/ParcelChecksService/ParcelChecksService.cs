using Cargo4You.Models.Entities;
using Cargo4You.Repositiories;
using Cargo4You.Services.Mapper;
using System.Threading.Tasks;

namespace Cargo4You.Services
{
    public class ParcelChecksService : IParcelChecksService
    {
        private readonly IParcelChecksRepository parcelChecksRepository;

        public ParcelChecksService(IParcelChecksRepository parcelChecksRepository)
        {
            this.parcelChecksRepository = parcelChecksRepository;
        }

        public async Task<ParcelChecksDto> CreateAsync(CreateParcelChecksDto createParcelChecksDto)
        {
            ParcelChecks parcelChecks = await parcelChecksRepository.Create(createParcelChecksDto.CreateDtoToEntity());

            return parcelChecks.EntityToDto();
        }
    }
}
