using Domain.AL.Handlers.Commands;
using Domain.DL.CQRS.Commands.Lifeforms;
using Domain.DL.CQRS.Commands.Messages;
using Domain.DL.CQRS.Commands.Users;
using Shared.ResultPattern.Success;
using TestCases.TestSoftware.Services;

namespace TestCases.Cases.Messages.Handlers.Post;
public class HandlerPostMessage
{
    [Fact]
    public void HandlerPostMessageSuccess()
    {
        IDomainCommandHandler handler = ObjectInstance.CommandHandler;

        handler.Handle(RecogniseAnimal.CreateTestObject(2, 1, true, "Test"));
        handler.Handle(RegistrateUser.CreateTestObject("Test", "Er", "Test123!", "Tester"));

        var result = handler.Handle(PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "This is a test", "testing"));
        Assert.True(result is SuccessNoDataResult);
    }
}
