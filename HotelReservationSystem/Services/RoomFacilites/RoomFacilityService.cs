using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.Facilities;

namespace HotelReservationSystem.Services.RoomFacilites
{
    public class RoomFacilityService : IRoomFacilityService
    {
        private readonly IGenericRepository<RoomFacility> repo;
        private readonly IFacilityService facilityService;

        public RoomFacilityService(IGenericRepository<RoomFacility> repo, IFacilityService facilityService)
        {
            this.repo = repo;
            this.facilityService = facilityService;
        }
        public void AddRange(int id, IEnumerable<RoomFacilityDTO> roomFacilityDTOs)
        {
            // this wrong behavior
            //foreach (var roomFacilityDTO in roomFacilityDTOs)
            //{
            //    var facility = facilityService.Add(roomFacilityDTO.Facility);
            //    var roomfacility = roomFacilityDTO.MapeOne<RoomFacility>();
            //    roomfacility.Id = id;
            //    repo.Add(roomfacility);
            //}
            repo.SaveChanges();
        }
    }
}
