﻿using Domain.AL.Services.Lifeforms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpPost(nameof(AllAnimals))]
    public async Task<IActionResult> AllAnimals()
    {
        var result = await _lifeformService.GetAllAnimals();
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetPlant))]
    public Task<IActionResult> GetPlant(int id)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpGet(nameof(GetAnimal))]
    public Task<IActionResult> GetAnimal(int id)
    {
        throw new NotImplementedException();
    }
}
