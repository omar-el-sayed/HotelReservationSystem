using HotelReservationSystem.DTOs.Facility;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.Facilities;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Facilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacilityController : ControllerBase
    {
        IFacilityService facilityService;
        public FacilityController(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }

        [HttpGet("getFacilities")]
        public ResultViewModel<IEnumerable<FacilityViewModel>> GetAvailableFacilities()
        {
            var availableFacilities = facilityService.GetAvailableFacilities().AsQueryable().Map<FacilityViewModel>();
            return ResultViewModel<IEnumerable<FacilityViewModel>>.Success(availableFacilities);
        }

        [HttpPost("addFacility")]
        public ResultViewModel<int> addFacility(FacilityViewModel facilityVM)
        {
            var facility = facilityService.Add(facilityVM.MapeOne<FacilityDTO>());
            return ResultViewModel<int>.Success(facility.Id, $"Facility is added successfully with id: {facility.Id}");
        }

        [HttpPut("updateFacility")]
        public ResultViewModel<int> updateFacility(FacilityViewModel facilityVM)
        {
            if (facilityService.Update(facilityVM.MapeOne<UpdateFacilityDto>()))
                return ResultViewModel<int>.Success(facilityVM.Id, $"Facility with id: {facilityVM.Id} is updated successfully");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedUpdateFacility, $"Failed to update facility with id: {facilityVM.Id}");
        }

        [HttpDelete("deleteFacility/{id}")]
        public ResultViewModel<int> DeleteFacility(int id)
        {
            if (facilityService.Delete(id))
                return ResultViewModel<int>.Success(id, $"Facility with id: {id} is deleted successfully");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedDeleteFacility, $"There's an error occured while deleting facility with id: {id}");
        }
    }
}
