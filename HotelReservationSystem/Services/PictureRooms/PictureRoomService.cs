using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.PictureRooms
{
    public class PictureRoomService : IPictureRoomService
    {
        private readonly IGenericRepository<PictureRoom> repo;

        public PictureRoomService(IGenericRepository<PictureRoom> repo)
        {
            this.repo = repo;
        }
        public void AddRange(int Id,IEnumerable<PictureRoomDTO> pictureRoomDTO)
        {
            var picturerooms = pictureRoomDTO.AsQueryable().Map<PictureRoom>();
            foreach (var pictureroom in picturerooms)
            {
                pictureroom.RoomId = Id;
                repo.Add(pictureroom);
            }
            repo.SaveChanges();
        }
    }
}
