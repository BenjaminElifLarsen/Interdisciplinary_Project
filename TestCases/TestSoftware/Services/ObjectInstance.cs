using Domain.AL.Handlers.Commands;
using Domain.DL.Factories;
using TestCases.TestSoftware.Context;

namespace TestCases.TestSoftware.Services;
internal static class ObjectInstance
{
    public static IDomainCommandHandler CommandHandler => new DomainCommandHandler(new TestUnitOfWork<TestContext>(new TestContext()), new MessageFactory(), new UserFactory(), new LifeformFactory());
}
