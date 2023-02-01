namespace Domain.IPL.Repositories;
public interface IPlantRepository
{
    public Task<bool> IsSpeciesInUseAsync(string species);
}
