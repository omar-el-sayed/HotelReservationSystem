﻿using HotelReservationSystem.Exceptions;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Middlewares
{
    public class GlobalErrorHandlerMiddleware(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = "";
                ErrorCode errorCode = ErrorCode.UnKnown;
                if(ex is BusinessException businessException)
                {
                    message = businessException.Message;
                    errorCode=businessException.errorCode;
                }
                var result =ResultViewModel<bool>.Failure(errorCode, message);
                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
