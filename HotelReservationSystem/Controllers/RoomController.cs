﻿using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController(IRoomMediator roomMediator) : BaseController
    {
        [HttpGet("getavailable")]
        public ResultViewModel<IEnumerable<RoomViewModel>> GetAvailableRooms()
        {
            var availableRooms = roomMediator.GetAvailableRooms().AsQueryable().Map<RoomViewModel>();
            return ResultViewModel<IEnumerable<RoomViewModel>>.Success(availableRooms);
        }

        [HttpGet("getbyid/{id}")]
        public ResultViewModel<RoomViewModel> GetById(int id)
        {
            var room = roomMediator.GetById(id).MapeOne<RoomViewModel>();
            return ResultViewModel<RoomViewModel>.Success(room);
        }

        [HttpPost("add")]
        public ResultViewModel<int> AddRoom(CreateRoomViewModel roomVM)
        {
            roomMediator.AddRoom(roomVM.MapeOne<CreateRoomDto>());
            return ResultViewModel<int>.Success(roomVM.Id, $"Room is added successfully with id: {roomVM.Id}");
        }

        [HttpPut("edit")]
        public ResultViewModel<int> UpdateRoom(UpdateRoomViewModel roomVM)
        {
            if (roomMediator.Update(roomVM.MapeOne<UpdateRoomDto>()))
                return ResultViewModel<int>.Success(roomVM.Id, $"Room with id: {roomVM.Id} is updated successfully");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedUpdateRoom, $"Failed to update room with id: {roomVM.Id}");
        }

        [HttpDelete("delete/{id}")]
        public ResultViewModel<int> DeleteRoom(int id)
        {
            if (roomMediator.Delete(id))
                return ResultViewModel<int>.Success(id, $"Room with id: {id} is deleted successfully");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedDeleteRoom, $"There's an error occured while deleting room with id: {id}");
        }
    }
}
