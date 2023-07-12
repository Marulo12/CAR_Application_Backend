using Application.Feactures.Brands.Queries.GetBrands;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseApiController
    {
        [HttpGet]
        [Route("get-brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await Mediator.Send(new GetBrands()));
        }
    }
}
