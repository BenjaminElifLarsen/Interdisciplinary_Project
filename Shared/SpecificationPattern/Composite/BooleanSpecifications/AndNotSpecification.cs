namespace Shared.SpecificationPattern.Composite.BooleanSpecifications;
internal class AndNotSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _spec1;
    private readonly ISpecification<T> _spec2;

    public AndNotSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    {
        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(T candidate)
    {
        return _spec1.IsSatisfiedBy(candidate) && !_spec2.IsSatisfiedBy(candidate);
    }
}