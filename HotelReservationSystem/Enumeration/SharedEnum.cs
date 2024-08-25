public enum AvailableStatus
{
    available, unavailable
}

public enum RoomType
{
    Single, Double, Triple, suite
}

public enum ErrorCode
{
    None = 0,
    UnKnown = 1,
    FailedUpdateRoom = 10,
    FailedDeleteRoom,
    PaymentFailure = 1000
}
public enum ReservationStatus
{
    Pending =0,
    Confirmed = 1,
    Cancelled = 2,
    Invoiced = 3,  
}