using Domain.AL.Services.Messages.Queries.GetAll;
using Domain.DL.Models.MessageModels;

namespace TestCases.Cases.Messages.GetAll;
public class GetAllMessages
{
    [Fact]
    public void GetAllMessageTest()
    {
        IEnumerable<Message> messages = new List<Message>()
        {
            new("Test1","T1",1,1,new(DateTime.Now, 0,0)),
            new("Test2","T2",1,1,new(DateTime.Now, 0,0)),
            new("Test3","T3",1,1,new(DateTime.Now, 0,0)),
        };
        var list = messages.AsQueryable().Select(new MessageListQuery().Map());
        Assert.True(list.All(x => messages.Any(xx => x.Title == x.Title)));
    }

    [Fact]
    public void TextLengthShouldShorten()
    {
        IEnumerable<Message> messages = new List<Message>()
        {
            new("Test1","This text message would be consier quite long by some people, but not other people, whoever this software is should split it at its 40 sign and 3 dots."
            ,1,1,new(DateTime.Now, 0,0)),
        };
        var list = messages.AsQueryable().Select(new MessageListQuery().Map());
        Assert.Equal(40 + 3, list.First().Text.Length);
    }

    [Fact]
    public void TextLengthShouldNotShorten()
    {
        IEnumerable<Message> messages = new List<Message>()
        {
            new("Test1","Short text."
            ,1,1,new(DateTime.Now, 0,0)),
        };
        var list = messages.AsQueryable().Select(new MessageListQuery().Map());
        Assert.Equal(messages.First().Text.Length, list.First().Text.Length);
    }
}
