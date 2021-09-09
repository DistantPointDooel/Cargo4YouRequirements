using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Cargo4You.Services.Extensions
{
    public static class EnumExtensions
    {

        /// <summary>
        /// A generic extension method that aids in reflecting 
        /// and retrieving display atribute that is applied to an `Enum`.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
