using System.Threading.Tasks;

namespace Cargo4You.Services
{
    public interface IParcelChecksService
    {
        Task<ParcelChecksDto> CreateAsync(CreateParcelChecksDto createParcelChecksDto);
    }
}
