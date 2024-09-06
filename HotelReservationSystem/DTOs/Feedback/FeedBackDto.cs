namespace HotelReservationSystem.DTOs.Feedback
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public decimal? Rate { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string StaffResponse { get; set; }
        public DateTime ResponceDate { get; set; }
    }
}
