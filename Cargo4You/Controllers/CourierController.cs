using Cargo4You.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargo4You.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CourierController : Controller
    {
        private readonly IParcelChecksService parcelChecksService;
        private readonly ICouriersSerivce couriersSerivce;

        public CourierController(IParcelChecksService parcelChecksService, ICouriersSerivce couriersSerivce)
        {
            this.parcelChecksService = parcelChecksService;
            this.couriersSerivce = couriersSerivce;
        }

        /// <summary>
        /// Creates a package info to keep evidence for user search.
        /// Searches through couriers validation and calculations to return a price for provided package info.
        /// </summary>
        /// <param name="createParcelChecksDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<CouriersDto>>> SearchForPrices(CreateParcelChecksDto createParcelChecksDto)
        {
            await parcelChecksService.CreateAsync(createParcelChecksDto);

            List<CouriersDto> couriers = couriersSerivce.Search(createParcelChecksDto);

            return Ok(couriers);
        }
    }
}
