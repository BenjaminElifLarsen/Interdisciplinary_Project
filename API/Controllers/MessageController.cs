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

	[AllowAnonymous]
	[HttpGet]
	public async Task<IActionResult> GetAllMessages() => this.FromResult(await _messageService.AllMessagesAsync());

	[HttpGet("Own")]
	public async Task<IActionResult> GetOwnMessages([FromQuery] int id) => this.FromResult(await _messageService.OwnMessagesAsync(id));

	[AllowAnonymous]
	[HttpPost("Details")]
	public async Task<IActionResult> GetDetails([FromQuery] int id) => this.FromResult(await _messageService.MessageDetailsAsync(id));

	[AllowAnonymous]
	[HttpPost()]
	public async Task<IActionResult> PostMessage([FromBody] PostMessage request) => this.FromResult(await _messageService.PostMessageAsync(request));

	[AllowAnonymous]
	[HttpPost("Like")]
	public async Task<IActionResult> LikeMessage([FromBody] LikeMessage request) => this.FromResult(await _messageService.LikeMessageAsync(request));

	[HttpPost("Remove")]
	public async Task<IActionResult> HideMessage([FromBody] HideMessage request) => this.FromResult(await _messageService.HideMessageAsync(request));
}
