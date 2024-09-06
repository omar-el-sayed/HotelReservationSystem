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
        public void AddRange(int reservationID,List<int> roomIDS)
        {
                foreach (var roomID in roomIDS)
                {
                    var roomReservation = new RoomReservation()
                    {
                        RoomId = roomID,
                        ReservationId = reservationID
                    };
                    repo.Add(roomReservation);

                }

                repo.SaveChanges();
        }
    }
}
