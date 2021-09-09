using Cargo4You.Models.Entities;
using Cargo4You.Repositiories;
using Cargo4You.Services.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cargo4You.Services
{
    public class CouriersService : ICouriersSerivce
    {
        private readonly ICouriersRepository couriersRepository;

        public CouriersService(ICouriersRepository couriersRepository)
        {
            this.couriersRepository = couriersRepository;
        }

        public List<CouriersDto> Search(CreateParcelChecksDto createParcelChecksDto)
        {
            int volume = GetVolume(createParcelChecksDto);

            List<Couriers> results = couriersRepository
                .GetAll()
                .Include(x => x.Validations)
                .Include(x => x.Calculations)
                .ToList(); 

            results = results.Where(x => x.Validations.All(z => z.Validate(z.MeasureUnit.Equals(Enums.MeasureUnit.Volume) ? volume : createParcelChecksDto.Weight))).ToList();

            List<CouriersDto> calculatedPrices = results.Select(x => x.EntityToDto()).ToList();

            calculatedPrices.ForEach(x =>
            {
                x.Price = results.FirstOrDefault(y => y.Id.Equals(x.Id)).GetPrice(volume, createParcelChecksDto.Weight);
            });

            return calculatedPrices;
        }

        private static int GetVolume(CreateParcelChecksDto createParcelChecksDto)
        {
            return createParcelChecksDto.Depth * createParcelChecksDto.Height * createParcelChecksDto.Width;
        }
    }
}
