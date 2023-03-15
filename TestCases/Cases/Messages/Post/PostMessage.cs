using Domain.DL.Factories;
using Shared.ResultPattern.Invalid;
using Shared.ResultPattern.Success;

namespace TestCases.Cases.Messages.Post;

public class PostMessage
{
    [Fact]
    public void SuccessPostTest()
    {
        IMessageFactory factory = new MessageFactory();
        var request = Domain.DL.CQRS.Commands.Messages.PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "Title", "Text");
        var userIds = new int[] { 1, 2, 3, 4 };
        var lifeformIds = new int[] { 1, 2, 3, 4, 5 };
        var validationData = Domain.DL.Validation.MessageValidationData.CreateTestObject(userIds, lifeformIds);
        var result = factory.CreateMessage(request, validationData);
        Assert.True(result is SuccessResult<Domain.DL.Models.MessageModels.Message>);
    }

    [Fact]
    public void FailedOnUserPostTest()
    {
        IMessageFactory factory = new MessageFactory();
        var request = Domain.DL.CQRS.Commands.Messages.PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "Title", "Text");
        var userIds = new int[] { 2, 3, 4 };
        var lifeformIds = new int[] { 1, 2, 3, 4, 5 };
        var validationData = Domain.DL.Validation.MessageValidationData.CreateTestObject(userIds, lifeformIds);
        var result = factory.CreateMessage(request, validationData);
        Assert.True(result is InvalidResult<Domain.DL.Models.MessageModels.Message>);
        Assert.True(result.Errors.Length == 1);
    }

    [Fact]
    public void FailedOnLifeformPostTest() //tests the message like and user like at some point, just directly using the objects, so not through the handlers
    {
        IMessageFactory factory = new MessageFactory();
        var request = Domain.DL.CQRS.Commands.Messages.PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "Title", "Text");
        var userIds = new int[] { 1, 2, 3, 4 };
        var lifeformIds = new int[] { 2, 3, 4, 5 };
        var validationData = Domain.DL.Validation.MessageValidationData.CreateTestObject(userIds, lifeformIds);
        var result = factory.CreateMessage(request, validationData);
        Assert.True(result is InvalidResult<Domain.DL.Models.MessageModels.Message>);
        Assert.True(result.Errors.Length == 1);
    }

    [Fact]
    public void FailedOnTitlePostTest()
    {
        IMessageFactory factory = new MessageFactory();
        var request = Domain.DL.CQRS.Commands.Messages.PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "", "Text");
        var userIds = new int[] { 1, 2, 3, 4 };
        var lifeformIds = new int[] { 1, 2, 3, 4, 5 };
        var validationData = Domain.DL.Validation.MessageValidationData.CreateTestObject(userIds, lifeformIds);
        var result = factory.CreateMessage(request, validationData);
        Assert.True(result is InvalidResult<Domain.DL.Models.MessageModels.Message>);
        Assert.True(result.Errors.Length == 1);
    }
}
