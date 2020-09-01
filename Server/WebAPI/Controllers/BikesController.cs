using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using Entities.Models.Enums;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BikesController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikesController(IBikeService bikeService) => this._bikeService = bikeService;

        [HttpGet("{id}")]
        public IActionResult GetBikeById(int id = 0)
        {
            if (id != 0)
                return Ok(this._bikeService.GetBikeById(id));
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult GetBikes()
        {
            return Ok(this._bikeService.GetFrontBikes());
        }

        [HttpGet("rented")]
        public IActionResult GetRentedBikes()
        {
            return Ok(this._bikeService.GetBikesByStatus(Status.Rented));
        }

        [HttpGet("available")]
        public IActionResult GetAvailableBikes()
        {
            return Ok(this._bikeService.GetBikesByStatus(Status.Free));
        }

        [HttpPost("create")]
        public IActionResult CreateBike(BikeForFront bikeForFront)
        {
            if (!string.IsNullOrEmpty(bikeForFront.Title) && bikeForFront.Price >= 0 && !string.IsNullOrEmpty(bikeForFront.Type.ToString()))
                return Ok(this._bikeService.CreateBike(bikeForFront));
            else
                return BadRequest();
        }

        [HttpPut("status")]
        public IActionResult Update([FromBody]int id = 0)
        {
            if (id != 0)
            {
                this._bikeService.Update(id);
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                _bikeService.Delete(id);
                return Ok();
            }
            else
                return BadRequest();
        }
        
    }
}