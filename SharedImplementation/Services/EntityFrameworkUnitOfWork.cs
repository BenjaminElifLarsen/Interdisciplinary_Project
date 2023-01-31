using Microsoft.EntityFrameworkCore;
using Shared.UnitOfWork;

namespace SharedImplementation.Services;
public class EntityFrameworkUnitOfWork<TContext> : IBaseUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;

    public EntityFrameworkUnitOfWork(TContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
