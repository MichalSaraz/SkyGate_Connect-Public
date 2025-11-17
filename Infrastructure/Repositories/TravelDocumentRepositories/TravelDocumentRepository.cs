using Core.PassengerContext.TravelDocuments.Entities;
using Core.PassengerContext.TravelDocuments.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.TravelDocumentRepositories;

/// <inheritdoc cref="ITravelDocumentRepository"/>
public class TravelDocumentRepository : GenericRepository<TravelDocument>, ITravelDocumentRepository
{
    public TravelDocumentRepository(AppDbContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public async Task<TravelDocument> GetTravelDocumentByIdAsync(Guid id,
        bool tracked = true)
    {
        var apisDataQuery = _context.TravelDocuments.AsQueryable().Where(d => d.Id == id);

        if (!tracked)
        {
            apisDataQuery = apisDataQuery.AsNoTracking();
        }

        var apisData = await apisDataQuery.FirstOrDefaultAsync();

        return apisData;
    }
}