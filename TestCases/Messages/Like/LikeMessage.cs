using Domain.DL.Factories;
using System.Diagnostics;

namespace TestCases.Messages.Like;

public class LikeMessage
{
    [Fact]
    public void SuccessMessageLikeTest()
    { //have one for user
        IMessageFactory factory = new MessageFactory();
        var request = Domain.DL.CQRS.Commands.Messages.PostMessage.CreateTestObject(1, 1, DateTime.Now, 12.1, 12.2, "Title", "Text");
        var userIds = new int[] { 1, };
        var lifeformIds = new int[] { 1, };
        var validationData = Domain.DL.Validation.MessageValidationData.CreateTestObject(userIds, lifeformIds);
        var result = factory.CreateMessage(request, validationData);
        var message = result.Data;
        var userId = 5;
        message.AddLike(userId);
        Assert.True(message.Likes.Count() == 1);
        message.AddLike(userId);
        Assert.True(message.Likes.Count() == 1);
        message.AddLike(userId+1);
        Assert.True(message.Likes.Count() == 2);
    }

    [Fact]
    public void SuccessUserLikeTest()
    {
        throw new NotImplementedException();
        //Domain.DL.Models.UserModels.User user = new(new("Test", "Er"), "Tester", "TotallyHashedPassword");
        //user.AddLike(2);
        //Assert.True(user.Likes.Count() == 1);
        //user.AddLike(2);
        //Assert.True(user.Likes.Count() == 1);
        //user.AddLike(3);
        //Assert.True(user.Likes.Count() == 2);
    }
}
