using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Facilities
{
    public class FacilityService : IFacilityService
    {
        private readonly IGenericRepository<Facility> repo;

        public FacilityService(IGenericRepository<Facility> repo)
        {
            this.repo = repo;
        }

        public Facility Add(FacilityDTO facilityDTO)
        {
            bool Exisited = ValidateFacilityExisiting(facilityDTO.Name);
            // need to handle this error using errorcode and handle exception
            if (Exisited)
                throw new InvalidOperationException("A facility with this name already exists.");

            var facility = facilityDTO.MapeOne<Facility>();
            repo.Add(facility);
            repo.SaveChanges();
            return facility;
        }
        public bool ValidateFacilityExisiting(string name)
        {
            var ExisitingFacility=  repo.Get(f => f.Name == name).FirstOrDefault();
            bool Exisited;
            if (ExisitingFacility != null)
                Exisited = true;
            else Exisited = false;
            return Exisited;
        }
    }
}
