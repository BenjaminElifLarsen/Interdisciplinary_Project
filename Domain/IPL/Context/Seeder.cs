using Domain.AL.Busses.Command;
using Domain.IPL.Services;
using Shared.Routing;

namespace Domain.IPL.Context;
internal static class Seeder
{
    public static void MockSeedData(IDomainCommandBus commandBus, IRoutingRegistry routingRegistry, IUnitOfWork unitOfWork)
    {
        routingRegistry.SetUpRouting();
    }
}
