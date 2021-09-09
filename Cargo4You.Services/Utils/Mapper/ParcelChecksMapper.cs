using Cargo4You.Models.Entities;

namespace Cargo4You.Services.Mapper
{
    public static class ParcelChecksMapper
    {

        /// <summary>
        /// Converts from <see cref="CreateParcelChecksDto"/> to <see cref="ParcelChecks"/>
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        public static ParcelChecks CreateDtoToEntity(this CreateParcelChecksDto createDto)
        {
            return new ParcelChecks
            {
                Depth = createDto.Depth,
                Height = createDto.Height,
                Width = createDto.Width,
                Weight = createDto.Weight,
            };
        }

        /// <summary>
        /// Converts from <see cref="ParcelChecks"/> to <see cref="ParcelChecksDto"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ParcelChecksDto EntityToDto(this ParcelChecks entity)
        {
            return new ParcelChecksDto
            {
                Id = entity.Id,
                Depth = entity.Depth,
                Height = entity.Height,
                Width = entity.Width,
                Weight = entity.Weight,
            };
        }
    }
}
