using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.RoomReservations
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IGenericRepository<RoomReservation> repo;

        public RoomReservationService(IGenericRepository<RoomReservation> repo)
        {
            this.repo = repo;
        }
        public void AddRange(List<RoomReservation> roomReservations)
        {
            repo.AddRange(roomReservations);
        }
    }
}
