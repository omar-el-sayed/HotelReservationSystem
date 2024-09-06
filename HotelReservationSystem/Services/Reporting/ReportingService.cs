using HotelReservationSystem.Reports.Models;
using Microsoft.Reporting.WebForms;

namespace HotelReservationSystem.Services.Reporting
{
    public class ReportingService : IReportingService
    {
        public byte[] GenerateReport()
        {
            LocalReport localReport = new LocalReport();
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "YourReportFile.rdlc");

            if (!File.Exists(reportPath))
            {
                throw new FileNotFoundException("Report file not found.", reportPath);
            }

            localReport.ReportPath = reportPath;

            // Prepare the data source
            List<ReportDataModel> reportData = GetReportData();
            ReportDataSource reportDataSource = new ReportDataSource();
            localReport.DataSources.Add(reportDataSource);

            // Render the report to a byte array in PDF format
            return localReport.Render("PDF");
        }

        private List<ReportDataModel> GetReportData()
        {
            return new List<ReportDataModel>
            {
                new ReportDataModel { Property1 = "Example", Property2 = 123 },
            };
        }
    }
}
