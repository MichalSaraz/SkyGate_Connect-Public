using AutoMapper;

namespace Application.MappingContext.Interfaces;

/// <summary>
/// Contract for a mapping service that converts domain entities into DTOs using AutoMapper.
/// Provides convenience methods to map single entities and collections with optional mapping configuration.
/// </summary>
public interface IMappingService
{
    /// <summary>
    /// Maps a single entity to a DTO of type <typeparamref name="TDto"/>.
    /// </summary>
    /// <typeparam name="TEntity">The source entity type.</typeparam>
    /// <typeparam name="TDto">The destination DTO type.</typeparam>
    /// <param name="entity">The entity instance to map.</param>
    /// <param name="opts">Optional AutoMapper configuration options applied during mapping.</param>
    /// <returns>The mapped DTO instance.</returns>
    TDto MapToDto<TEntity, TDto>(TEntity entity, Action<IMappingOperationOptions<TEntity, TDto>>? opts = null);

    /// <summary>
    /// Maps a collection of entities to a list of DTOs of type <typeparamref name="TDto"/>.
    /// </summary>
    /// <typeparam name="TEntity">The source entity type.</typeparam>
    /// <typeparam name="TDto">The destination DTO type.</typeparam>
    /// <param name="entities">The entities to map.</param>
    /// <param name="opts">Optional AutoMapper configuration options applied during mapping.</param>
    /// <returns>A list of mapped DTOs. The returned list will not be <c>null</c> (may be empty).</returns>
    List<TDto> MapToListDto<TEntity, TDto>(IEnumerable<TEntity> entities,
        Action<IMappingOperationOptions<IEnumerable<TEntity>, List<TDto>>>? opts = null);

    TDto MapToDtoWithFlightId<TEntity, TDto>(TEntity entity, Guid flightId,
        Action<IMappingOperationOptions<TEntity, TDto>>? opts = null);

    List<TDto> MapToListDtoWithFlightId<TEntity, TDto>(
        IEnumerable<TEntity> entities, Guid flightId,
        Action<IMappingOperationOptions<IEnumerable<TEntity>, List<TDto>>>? opts = null);
}