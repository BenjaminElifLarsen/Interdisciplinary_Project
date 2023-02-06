using Domain.DL.Models.LifeformModels;
using Shared.CQRS.Queries;
using System.Linq.Expressions;

namespace Domain.DL.Validation.ReadModels;
internal sealed class AnimalOffspringInformation : BaseReadModel
{
    public byte CurrentMax { get; private set; }
    public byte CurrentMin { get; private set; }

    public AnimalOffspringInformation(byte currentMax, byte currentMin)
    {
        CurrentMax = currentMax;
        CurrentMin = currentMin;
    }
}

internal sealed class AnimalOffspringInformationQuery : BaseQuery<Animalia, AnimalOffspringInformation>
{
    public override Expression<Func<Animalia, AnimalOffspringInformation>> Map()
    {
        return e => new(e.MaximumOffspringsPerMating, e.MinimumOffspringsPerMating);
    }
}
