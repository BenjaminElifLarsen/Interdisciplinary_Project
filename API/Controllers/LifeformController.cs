using API.Controllers.Extensions;
using Domain.AL.Services.Lifeforms;
using Domain.DL.CQRS.Commands.Lifeforms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("[controller]")]
[ApiController]
public class LifeformController : ControllerBase
{
    private readonly ILifeformService _lifeformService;
    private const string Animal = nameof(Animal);
    private const string Plant = nameof(Plant);
    private const string Unrecognise = nameof(Unrecognise);

    public LifeformController(ILifeformService lifeformService)
    {
        _lifeformService = lifeformService;
    }

    [AllowAnonymous]
    [HttpGet(nameof(AllPlants))]
    public async Task<IActionResult> AllPlants()
    {
        var result = await _lifeformService.AllPlantsAsync();
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpGet(nameof(AllAnimals))]
    public async Task<IActionResult> AllAnimals()
    {
        var result = await _lifeformService.AllAnimalsAsync();
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetPlant))]
    public async Task<IActionResult> GetPlant(int id)
    {
        var result = await _lifeformService.GetPlantAsync(id);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetAnimal))]
    public async Task<IActionResult> GetAnimal(int id)
    {
        var result = await _lifeformService.GetAnimalAsync(id);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpPost(Animal)]
    public async Task<IActionResult> PostAnimal([FromBody] RecogniseAnimal request)
    {
        var result = await _lifeformService.RecogniseAnimalAsync(request);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpPost(Plant)]
    public async Task<IActionResult> PostPlant([FromBody] RecognisePlant request)
    {
        var result = await _lifeformService.RecognisePlantAsync(request);
        return this.FromResult(result);
    }

    [AllowAnonymous]
    [HttpPost(Unrecognise)]
    public async Task<IActionResult> UnrecogniseLifeform([FromBody] UnreogniseLifeform request)
    {
        return this.FromResult(await _lifeformService.UnrecogniseAsync(request));
    }

    [AllowAnonymous]
    [HttpPut(Animal)]
    public async Task<IActionResult> UpdateAnimal([FromBody] ChangeAnimalInformation request)
    {
        return this.FromResult(await _lifeformService.UpdateAnimalAsync(request));
    }


    [AllowAnonymous]
    [HttpPut(Plant)]
    public async Task<IActionResult> UpdatePlant([FromBody] ChangePlantInformation request)
    {
        return this.FromResult(await _lifeformService.UpdatePlantAsync(request));
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int id) => this.FromResult(await _lifeformService.GetAsync(id));
}
