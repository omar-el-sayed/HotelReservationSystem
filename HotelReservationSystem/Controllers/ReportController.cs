using HotelReservationSystem.Services.Reporting;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportingService _reportService) : BaseController
    {
        [HttpGet("generate")]
        public IActionResult GenerateReport()
        {
            try
            {
                byte[] reportBytes = _reportService.GenerateReport();
                return File(reportBytes, "application/pdf", "Report.pdf");
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
