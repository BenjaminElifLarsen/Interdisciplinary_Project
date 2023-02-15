using Domain.DL.Models.LifeformModels;
using Domain.DL.Validation.ReadModels;

namespace TestCases.Eukaryote.GetAll.Plant;

public class GetAllPlants
{
    [Fact]
    public void GetAllAnimalSpeicesTest()
    {
        IEnumerable<Plantae> plants = new List<Plantae>()
        {
            new("Test1", 12),
            new("Test2", 3)
        };
        var species = plants.AsQueryable().Select(new PlantSpeciesQuery().Map());
        Assert.True(species.All(x => plants.Any(xx => x.Species == x.Species)));
    }
}
