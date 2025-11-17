using Core.PassengerContext.Passengers.Entities;

namespace Core.PassengerContext.Passengers.Interfaces;

/// <summary>
/// Repository contract for <see cref="BasePassengerOrItem"/> entities. Extends
/// <see cref="IBasePassengerOrItemRepository{BasePassengerOrItem}"/> with queries specific to items.
/// </summary>
public interface IItemRepository : IBasePassengerOrItemRepository<BasePassengerOrItem>
{
}