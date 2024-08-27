using Autofac.Core.Lifetime;
using HotelReservationSystem.Data;

namespace HotelReservationSystem.Middlewares
{
    public class TransactionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ApplicationDbContext context;

        public TransactionHandlerMiddleware(RequestDelegate _next, ApplicationDbContext context) {
            next = _next;
            this.context = context;

        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var method = httpContext.Request.Method;
            if (method.ToUpper() != "GET")
            {
                var Transaction = context.Database.BeginTransaction();
                try
                {
                    await next(httpContext);
                    Transaction.Commit();
                }
                catch (Exception ex) {
                    Transaction.Rollback();
                    throw;
                }

            }
        }
    }
}
