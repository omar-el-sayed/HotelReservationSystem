﻿public enum AvailableStatus
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
    DoesNotExist,
    InvalidDateRange,
    FailedUpdateRoom = 10,
    FailedDeleteRoom,
    FailedUpdateFacility = 20,
    FailedDeleteFacility,
    FaildAddFacility,
    PaymentFailure = 1000
}
public enum ReservationStatus
{
    Pending =0,
    Confirmed ,
    Cancelled ,
    Invoiced ,
}