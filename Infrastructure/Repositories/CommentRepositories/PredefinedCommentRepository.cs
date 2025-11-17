using Core.PassengerContext.Comments.Entities;
using Core.PassengerContext.Comments.Enums;
using Core.PassengerContext.Comments.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommentRepositories;

/// <inheritdoc cref="IPredefinedCommentRepository"/>
public class PredefinedCommentRepository : IPredefinedCommentRepository
{
    private readonly AppDbContext _context;

    public PredefinedCommentRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<PredefinedComment> GetPredefinedCommentByIdAsync(PredefinedCommentEnum id)
    {
        return await _context.PredefinedComments.AsNoTracking()
            .Where(_ => _.Id == id)
            .SingleOrDefaultAsync();
    }
}