using SharedImplementation.Services;

namespace Domain.IPL.Services;
internal sealed class UnitOfWork : EntityFrameworkUnitOfWork<>, IUnitOfWork
{

}
