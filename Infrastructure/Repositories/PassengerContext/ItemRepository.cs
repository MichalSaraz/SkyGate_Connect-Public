using Core.PassengerContext.Passengers.Entities;
using Core.PassengerContext.Passengers.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PassengerContext;

/// <inheritdoc cref="IItemRepository"/>
public class ItemRepository : BasePassengerOrItemRepository<BasePassengerOrItem>, IItemRepository
{
    public ItemRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public override async Task<bool> ExistsAsync(Guid id)
    {
        var existsInExtraSeat = await _context.Set<ExtraSeat>().AnyAsync(f => f.Id == id);
        var existsInCabinBaggageRequiringSeat = await _context.Set<CabinBaggageRequiringSeat>()
            .AnyAsync(f => f.Id == id);

        return existsInExtraSeat || existsInCabinBaggageRequiringSeat;
    }
}