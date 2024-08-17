using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.RoomFacilites
{
    public class RoomFacilityService : IRoomFacilityService
    {
        private readonly IGenericRepository<RoomFacility> repo;

        public RoomFacilityService(IGenericRepository<RoomFacility> repo)
        {
            this.repo = repo;
        }
        public void AddRang(int id, IEnumerable<RoomFacilityDTO> roomFacilityDTOs)
        {
            var roomFacilities=roomFacilityDTOs.AsQueryable().Map<RoomFacility>();
            foreach(var roomFacilitiy in roomFacilities)
            {
                roomFacilitiy.RoomId = id;
                repo.Add(roomFacilitiy);
            }
            repo.SaveChanges();
            // w2ef eni a3mel insert ll room facility and while insert it should insert facility 
        }
    }
}
