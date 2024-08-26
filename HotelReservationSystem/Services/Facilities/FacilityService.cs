using HotelReservationSystem.DTOs.Facility;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Exceptions;
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
            if (facilityDTO == null)
                throw new BusinessException(ErrorCode.FaildAddFacility, "Facility data must not be null");
            var facility = facilityDTO.MapeOne<Facility>();
            repo.Add(facility);
            repo.SaveChanges();
            return facility;
        }

        public bool Delete(int id)
        {
            var facility = repo.GetByIdWithTracking(id);
            if (facility is null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Facility with id {id} Not Exist ");

            repo.Delete(facility);
            repo.SaveChanges();

            return true;
        }

        public IEnumerable<FacilityDTO> GetAvailableFacilities()
        {
            var facilities = repo.Get(f=> f.IsAvailable == true).Map<FacilityDTO>();
            return facilities;

        }

        public bool Update(UpdateFacilityDto facilityDto)
        {
            var facility = repo.GetByIdWithTracking(facilityDto.Id);
            if (facility is null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Facility with id {facilityDto.Id} Not Exist ");

            var updatedFacility = facilityDto.MapeOne<Facility>();
            repo.Update(updatedFacility);
            repo.SaveChanges();
            return true;
        }

    }
}
