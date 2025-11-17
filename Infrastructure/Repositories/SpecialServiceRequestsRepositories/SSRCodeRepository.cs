using Core.PassengerContext.SpecialServiceRequests.Entities;
using Core.PassengerContext.SpecialServiceRequests.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SpecialServiceRequestsRepositories;

/// <inheritdoc cref="ISSRCodeRepository"/>
public class SSRCodeRepository : GenericRepository<SSRCode>, ISSRCodeRepository
{
    public SSRCodeRepository(AppDbContext context) : base(context)
    {
    }
       
    /// <inheritdoc/>
    public async Task<SSRCode> GetSSRCodeAsync(string code)
    {
        return await _context.SSRCodes.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Code == code);
    }
}