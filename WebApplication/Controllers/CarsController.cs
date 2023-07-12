using Application.DTOs.Car;
using Application.Feactures.Cars.Commands.DeleteCarById;
using Application.Feactures.Cars.Commands.NewCar;
using Application.Feactures.Cars.Commands.UpdateCarById;
using Application.Feactures.Cars.Queries.GetCarById;
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

        [HttpGet]
        [Route("get-car-by-id")]
        public async Task<IActionResult> GetCarById([FromQuery] long idCar)
        {
            return Ok(await Mediator.Send(new GetCarById { 
            IdCar= idCar
            }));
        }

        [HttpDelete]
        [Route("delete-car-by-id/{idCar}")]
        public async Task<IActionResult> DeleteCarById([FromRoute] long idCar)
        {
            return Ok(await Mediator.Send(new DeleteCarById { IdCar = idCar}));
        }

        [HttpPut]
        [Route("update-car")]
        public async Task<IActionResult> UpdateCard([FromBody] UpdateCarDTO updateCarDTO)
        {
            return Ok(await Mediator.Send(new UpdateCar { UpdateCarDTO = updateCarDTO }));
        }

        [HttpPost]
        [Route("new-car")]
        public async Task<IActionResult> NewCar([FromBody] NewCarDTO  newCarDTO)
        {
            return Ok(await Mediator.Send(new NewCar { NewCarDto = newCarDTO }));
        }
    }
}
