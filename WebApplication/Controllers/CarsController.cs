using Application.Feactures.Cars.Queries.GetCars;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseApiController
    {
        [HttpGet]
        [Route("get-cars")]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await Mediator.Send(new GetCars()));
        }
    }
}
