using System.Collections.Generic;

namespace Cargo4You.Services
{
    public interface ICouriersSerivce
    {
        List<CouriersDto> Search(CreateParcelChecksDto createParcelChecksDto);
    }
}
