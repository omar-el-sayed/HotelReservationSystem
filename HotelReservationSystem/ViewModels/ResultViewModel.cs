namespace HotelReservationSystem.ViewModels
{
    public class ResultViewModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public ErrorCode errorCode { get; set; }

        public static ResultViewModel<T>Success<T>(T data,string message="")
        {
            return new ResultViewModel<T>
            {
                Data = data,
                Message = message,
                IsSuccess = true,
                errorCode = ErrorCode.None
            };
        }
        public static ResultViewModel<T>Failure(ErrorCode errorCode,string message)
        {
            return new ResultViewModel<T>
            {
                Data=default,
                Message = message,
                IsSuccess=false,
                errorCode = errorCode
            };
        }
    }
}
