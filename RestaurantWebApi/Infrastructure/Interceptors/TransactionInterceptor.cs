using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RestaurantWeb.Infrastructure.Interceptors;

public class TransactionInterceptor(ILogger<TransactionInterceptor> logger) : DbTransactionInterceptor
{
    public override ValueTask<InterceptionResult> TransactionCommittingAsync(DbTransaction transaction,
        TransactionEventData eventData,
        InterceptionResult result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation($"Transaction {eventData.TransactionId} finished successfully");
        return base.TransactionCommittingAsync(transaction, eventData, result, cancellationToken);
    }
}