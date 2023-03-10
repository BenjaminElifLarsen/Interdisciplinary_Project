using Domain.AL.Services.Messages;
using Domain.DL.CQRS.Commands.Messages;
using Microsoft.AspNetCore.SignalR;
using Shared.ResultPattern.Success;
using Shared.Routing;

namespace API.Hubs;

public class MessageHub : Hub
{
    IMessageService _service;
    public MessageHub(IMessageService messageService, IRoutingRegistry routing)
    {
        _service = messageService;
        routing.SetUpRouting();
    }

    public async Task Post(PostMessage request)
    {
        var result = await _service.PostMessageAsync(request);
        if(result is SuccessNoDataResult)
        {
            //would need a way to get the message
            await Clients.All.SendAsync("MessagePosted");
        }
        else
        {
            await Clients.Caller.SendAsync("MessageErr", result.Errors);
        }
    }

    public async Task Testing(string message)
    {
        await Clients.All.SendAsync("Testing2", message);
    }

    public async Task TestingClass(Baisc test)
    {
        if(test.id == 0)
        {
            var testing = Clients.Caller;
            await testing.SendAsync("Err", "You made an error");
        }
        else
        {
            await Clients.Others.SendAsync("ClassTesting2", "Incoming test");
            await Clients.All.SendAsync("ClassTesting", new { coolId = test.id, lameName = test.name });
        }
    }


    public class Baisc
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
