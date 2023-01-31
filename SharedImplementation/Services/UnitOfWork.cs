using Microsoft.EntityFrameworkCore;
using Shared.UnitOfWork;

namespace SharedImplementation.Services;
public class UnitOfWork<TContext> : IBaseUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;

    public UnitOfWork(TContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
