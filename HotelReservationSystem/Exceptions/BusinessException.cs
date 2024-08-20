namespace HotelReservationSystem.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCode errorCode { get; set; }
        public BusinessException(ErrorCode errorCode,string message):base(message) 
        {
            this.errorCode = errorCode;
        }
    }
}
