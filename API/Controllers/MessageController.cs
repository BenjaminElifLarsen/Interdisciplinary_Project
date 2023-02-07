using API.Controllers.Extensions;
using Domain.AL.Services.Messages;
using Domain.DL.CQRS.Commands.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

	public MessageController(IMessageService messageService)
	{
		_messageService = messageService;
	}

	[HttpGet("Message/Own")]
	public async Task<IActionResult> GetOwnMessages([FromQuery] int id)
	{
		return this.FromResult(await _messageService.OwnMessagesAsync(id));
	}

	[AllowAnonymous]
	[HttpPost("Message")]
	public async Task<IActionResult> PostMessage([FromBody] PostMessage request)
	{
		var result = await _messageService.PostMessageAsync(request);
		return this.FromResult(result);
	}

	[AllowAnonymous]
	[HttpPost("Message/Like")]
	public async Task<IActionResult> LikeMessage([FromBody] LikeMessage request)
	{
		var result = await _messageService.LikeMessageAsync(request);
		return this.FromResult(result);
	}
}
