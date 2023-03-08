using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class MessageHub : Hub
{
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
            await Clients.All.SendAsync("ClassTesting", new { coolId = test.id, lameName = test.name });
        }
    }

    public class Baisc
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
