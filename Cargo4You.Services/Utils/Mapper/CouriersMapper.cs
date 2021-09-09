using Cargo4You.Models.Entities;
using System.Linq;

namespace Cargo4You.Services.Mapper
{
    public static class CouriersMapper
    {

        /// <summary>
        /// Converts from <see cref="Couriers"/> to <see cref="ValidationsDto"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static CouriersDto EntityToDto(this Couriers entity)
        {
            return new CouriersDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
