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
            //var pictureroom = pictureRoomDTO.AsQueryable().Map<PictureRoom>();
            //repo.Add(pictureroom);
            //repo.SaveChanges();
        }
    }
}
