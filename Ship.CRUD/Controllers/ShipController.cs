using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ship.CRUD.Dtos;
using Ship.CRUD.Models;
using Ship.CRUD.Repository;

namespace Ship.CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly IShipRepository shipRepository;
        private readonly IMapper mapper;
        public ShipController(IShipRepository shipRepository, IMapper mapper)
        {
            this.shipRepository = shipRepository;
            this.mapper = mapper;
        }

        [HttpGet("/ship")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<ShipResponseDto>))]
        [ProducesResponseType(statusCode: 500, type: typeof(ProblemDetails))]
        public async Task<IActionResult> GetAllShips()
        {
            var ships = await shipRepository.GetAllShips();

            return Ok(mapper.Map<List<ShipResponseDto>>(ships));
        }

        [HttpGet("/ship/{id}")]
        [ProducesResponseType(statusCode: 200, type: typeof(ShipResponseDto))]
        [ProducesResponseType(statusCode: 500, type: typeof(ProblemDetails))]
        public async Task<IActionResult> GetShip([FromRoute] int id)
        {
            try
            {
                var ship = await shipRepository.GetShip(id);
                return Ok(mapper.Map<ShipResponseDto>(ship));
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("/ship")]
        [ProducesResponseType(statusCode: 200, type: typeof(ShipResponseDto))]
        [ProducesResponseType(statusCode: 500, type: typeof(ProblemDetails))]
        public async Task<IActionResult> CreateShip([FromBody]ShipRequestDto body)
        {
            var request = mapper.Map<ShipModel>(body);
            var response = await shipRepository.CreateShip(request);

            return Ok(mapper.Map<ShipResponseDto>(response));
        }

        [HttpPut("/ship/{id}")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 404, type: typeof(ProblemDetails))]
        [ProducesResponseType(statusCode: 500, type: typeof(ProblemDetails))]
        public async Task<IActionResult> UpdateShip([FromBody]ShipRequestDto body, [FromRoute]int id)
        {
            var request = mapper.Map<ShipModel>(body);

            try
            {
                await shipRepository.UpdateShip(request, id);
                return NoContent();
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpDelete("/ship/{id}")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, type: typeof(ProblemDetails))]
        public async Task<IActionResult> DeleteShip([FromRoute] int id)
        {
            try
            {
                await shipRepository.DeleteShip(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}