using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Application.Interfaces;

namespace Infrastructures;

public class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IClaimsService _claimsService;
    private readonly ICurrentTime _currentTime;

    public AuditInterceptor(IClaimsService claimsService, ICurrentTime currentTime)
    {
        _currentTime = currentTime;
        _claimsService = claimsService;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null) return result;
        ChangeAuditData(context);
        return result;
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context == null) return result;
        ChangeAuditData(context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ChangeAuditData(DbContext context)
    {
        var now = _currentTime.GetCurrentTime();
        var userId = _claimsService.CurrentUserId;
        var entries = context.ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditableEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified ||
                         e.State == EntityState.Deleted));

        foreach (var entry in entries)
        {
            var entity = (IAuditableEntity)entry.Entity;
            // Skipping Hard Deleted Entities
            // if (entity is IBaseEntity baseEntity && baseEntity.IsHardDelete) continue;

            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        entity.CreationDate = now;
                        entity.CreatedById = userId;
                        continue;
                    }
                case EntityState.Modified:
                    {
                        entity.ModificationDate = now;
                        entity.ModificationById = userId;
                        continue;
                    }
                case EntityState.Deleted:
                    {
                        if (entity.IsHardDelete)
                        {
                            entry.State = EntityState.Deleted;//not sure if this works
                            continue;
                        }
                        entity.DeletionDate = now;
                        entity.DeleteById = userId;
                        entry.State = EntityState.Modified;
                        continue;
                    }
            }
        }
    }
}