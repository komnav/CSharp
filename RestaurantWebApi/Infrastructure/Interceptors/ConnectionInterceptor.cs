using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RestaurantWeb.Infrastructure.Interceptors;

public class ConnectionInterceptor(ILogger<ConnectionInterceptor> logger) : DbConnectionInterceptor
{
    public override Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Connection opened");
        return base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
    }

    public override Task ConnectionClosedAsync(DbConnection connection, ConnectionEndEventData eventData)
    {
        logger.LogInformation("Connection closed");
        return base.ConnectionClosedAsync(connection, eventData);
    }
}