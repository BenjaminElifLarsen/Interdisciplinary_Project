using Domain.AL.Services.Messages.Queries.GetSingle;
using Domain.DL.Models.MessageModels;

namespace TestCases.Cases.Messages.GetSingle;
public class GetSingleMessage
{
    [Fact]
    public void GetSingleMessageTest()
    {
        IList<Message> messages = new List<Message>()
        {
            new("Test Title", "This messsage is short", 1, 1, new(DateTime.Now,0,0))
        };
        var list = messages.AsQueryable().Select(new MessageDetailsQuery().Map());
        Assert.True(string.Equals(messages.First().Text, list.First().Text));
    }
}
