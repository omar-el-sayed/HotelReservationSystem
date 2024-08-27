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

        public RoomFacilityService(IGenericRepository<RoomFacility> repo)
        {
            this.repo = repo;
        }
        public void AddRange(int roomId, List<int> FacilitiesIDS)
        {
            // this wrong behavior
            //foreach (var roomFacilityDTO in roomFacilityDTOs)
            //{
            //    var facility = facilityService.Add(roomFacilityDTO.Facility);
            //    var roomfacility = roomFacilityDTO.MapeOne<RoomFacility>();
            //    roomfacility.Id = id;
            //    repo.Add(roomfacility);
            //}
            foreach (var facilityID in FacilitiesIDS)
            {
                var RoomFacility = new RoomFacility()
                {
                    RoomId = roomId,
                    FacilityId = facilityID
                };
                repo.Add(RoomFacility);

            }

            repo.SaveChanges();
        }
    }
}
