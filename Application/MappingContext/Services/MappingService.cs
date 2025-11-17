using Application.MappingContext.Interfaces;
using AutoMapper;

namespace Application.MappingContext.Services;

/// <inheritdoc/>
public class MappingService : IMappingService
{
    private readonly IMapper _mapper;

    public MappingService(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public TDto MapToDto<TEntity, TDto>(TEntity entity,
        Action<IMappingOperationOptions<TEntity, TDto>>? opts = null)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return opts == null
            ? _mapper.Map<TEntity, TDto>(entity)
            : _mapper.Map(entity, opts);
    }

    /// <inheritdoc/>
    public List<TDto> MapToListDto<TEntity, TDto>(
        IEnumerable<TEntity> entities,
        Action<IMappingOperationOptions<IEnumerable<TEntity>, List<TDto>>>? opts = null)
    {
        return opts == null 
            ? _mapper.Map<List<TDto>>(entities) 
            : _mapper.Map(entities, opts);
    }
    
    public TDto MapToDtoWithFlightId<TEntity, TDto>(TEntity entity, Guid flightId,
        Action<IMappingOperationOptions<TEntity, TDto>>? opts = null)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return _mapper.Map<TEntity, TDto>(entity, opt =>
        {
            opt.Items["FlightId"] = flightId;
            opts?.Invoke(opt);
        });
    }

    public List<TDto> MapToListDtoWithFlightId<TEntity, TDto>(
        IEnumerable<TEntity> entities, Guid flightId,
        Action<IMappingOperationOptions<IEnumerable<TEntity>, List<TDto>>>? opts = null)
    {
        return _mapper.Map<IEnumerable<TEntity>, List<TDto>>(entities, opt =>
        {
            opt.Items["FlightId"] = flightId;
            opts?.Invoke(opt);
        });
    }
}