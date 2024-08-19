using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomMediator roomMediator, IRoomService roomService) : BaseController
    {
        [HttpGet("getall")]
        public IActionResult GetAvailableRooms()
        {
            var availableRooms = roomService.GetAvailableRoom();
            return Ok(availableRooms);
        }

        [HttpPost("add")]
        public IActionResult AddRoom(CreateRoomViewModel roomVM)
        {
            roomService.Add(roomVM.MapeOne<RoomDTO>());
            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult UpdateRoom(UpdateRoomViewModel roomVM)
        {
            if (roomService.Update(roomVM.MapeOne<UpdateRoomDto>()))
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            if (roomService.Delete(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
