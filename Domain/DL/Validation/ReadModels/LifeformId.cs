using Shared.CQRS.Queries;

namespace Domain.DL.Validation.ReadModels;
internal class LifeformId : BaseReadModel
{
    public int Id { get; set; }

	public LifeformId(int id)
	{
		Id = id;
	}
}
