using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Rooms

using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomMediator roomMediator, IRoomService roomService) : BaseController
    {
        [HttpGet("getall")]
        public ResultViewModel<IEnumerable<RoomViewModel>> GetAvailableRooms()
        {
            var availableRooms = roomService.GetAvailableRoom().AsQueryable().Map<RoomViewModel>();
            return ResultViewModel<RoomViewModel>.Success<IEnumerable<RoomViewModel>>(availableRooms);
        }

        [HttpPost("add")]
        public ResultViewModel<int> AddRoom(CreateRoomViewModel roomVM)
        {
            roomMediator.AddRoom(roomVM.MapeOne<RoomDTO>());
            return ResultViewModel<int>.Success(roomVM.Id,$"Room Is Added Successfuly with id:{roomVM.Id}");
        }

        [HttpPut("edit")]
        public ResultViewModel<int> UpdateRoom(UpdateRoomViewModel roomVM)
        {
            if (roomService.Update(roomVM.MapeOne<UpdateRoomDto>()))
                return ResultViewModel<int>.Success(roomVM.Id, $"Room  with Id:{roomVM.Id} is Updated Successfuly");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedUpdateRoom, $"Faild To Update Room with id:{roomVM.Id}");
        }

        [HttpDelete("delete/{id}")]
        public ResultViewModel<int> DeleteRoom(int id)
        {
            if (roomService.Delete(id))
                return ResultViewModel<int>.Success(id, $"Room with Id:{id} is Deleted Successfuly");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedDeleteRoom, $"There's an error occured while deleting room with id: {id}");
        }
    }
}
