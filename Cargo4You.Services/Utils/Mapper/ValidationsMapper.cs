using Cargo4You.Models.Entities;
using Cargo4You.Services.Extensions;

namespace Cargo4You.Services.Mapper
{
    public static class ValidationsMapper
    {

        /// <summary>
        /// Converts from <see cref="Validations"/> to <see cref="ValidationsDto"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ValidationsDto EntityToDto(this Validations entity)
        {
            return new ValidationsDto
            {
                Id = entity.Id,
                CourierId = entity.CourierId,
                MeasureUnit = entity.MeasureUnit.GetDisplayName(),
                Operant = entity.Operator,
                ValidationValue = entity.ValidationValue,
            };
        }
    }
}
