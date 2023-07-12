using Application.Feactures.Models.Queries.GetModelsByIdBrand;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseApiController
    {
        [HttpGet]
        [Route("get-models-by-idbrand")]
        public async Task<IActionResult> GetModelsByIdBrand([FromQuery] long idBrand) {
            return Ok(await Mediator.Send(new GetModelsByIdBrand { IdBrand = idBrand }));
        }

    }
}
