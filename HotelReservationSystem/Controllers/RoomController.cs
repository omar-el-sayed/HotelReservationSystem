using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomMediator roomMediator) : BaseController
    {
        [HttpGet("getall")]
        public IActionResult GetAvailableRooms()
        {
            return Ok();
        }

        [HttpPost("add")]
        public IActionResult AddRoom(CreateRoomViewModel roomVM)
        {
            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult UpdateRoom(UpdateRoomViewModel roomVM)
        {
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            return Ok();
        }
    }
}
