using Domain.DL.Models.LifeformModels;
using Domain.DL.Validation.ReadModels;

namespace TestCases.Cases.Eukaryote.GetAll.Animal;

public class GetAllAnimals
{
    [Fact]
    public void GetAllAnimalSpeicesTest()
    {
        IEnumerable<Animalia> animals = new List<Animalia>()
        {
            new("Test1",1,3,true),
            new("Test2",1,3,false),
        };
        var species = animals.AsQueryable().Select(new AnimalSpeciesQuery().Map());
        Assert.True(species.All(x => animals.Any(xx => x.Species == x.Species)));
    }
}
