using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantWeb.Model;

namespace RestaurantWeb.Infrastructure.Interceptors;

public class AvoidDeletingContactInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        if (eventData.Context is not null)
            UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
            UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    private static void UpdateEntities(DbContext context)
    {
        var entities = context.ChangeTracker.Entries<Contact>().ToList();

        foreach (EntityEntry<Contact> entry in entities)
        {
            if (entry.State == EntityState.Deleted)
            {
                if (entry.Entity.FirstName == "Komilov" || entry.Entity.LastName == "Komilov")
                {
                    entry.State = EntityState.Detached;
                }
                else
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }
        }
    }
}