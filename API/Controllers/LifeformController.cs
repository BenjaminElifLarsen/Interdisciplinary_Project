using API.Controllers.Extensions;
using Domain.AL.Services.Lifeforms;
using Domain.DL.CQRS.Commands.Lifeforms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.ResultPattern.Abstract;

namespace API.Controllers;
[Route("[controller]")]
[ApiController]
public class LifeformController : ControllerBase
{
    private readonly ILifeformService _lifeformService;

    public LifeformController(ILifeformService lifeformService)
    {
        _lifeformService = lifeformService;
    }

    [AllowAnonymous]
    [HttpPost(nameof(AllPlants))]
    public async Task<IActionResult> AllPlants()
    {
        var result = await _lifeformService.GetAllPlants();
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpPost(nameof(AllAnimals))]
    public async Task<IActionResult> AllAnimals()
    {
        var result = await _lifeformService.GetAllAnimals();
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetPlant))]
    public async Task<IActionResult> GetPlant(int id)
    {
        var result = await _lifeformService.GetPlant(id);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetAnimal))]
    public async Task<IActionResult> GetAnimal(int id)
    {
        var result = await _lifeformService.GetAnimal(id);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpPost("Animal")]
    public async Task<IActionResult> PostAnimal([FromBody] RecogniseAnimal request)
    {
        var result = await _lifeformService.RecogniseAnimal(request);
        return this.FromResult(result);
    }
}
