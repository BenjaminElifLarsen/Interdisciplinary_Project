namespace Shared.SpecificationPattern;
public interface ISpecification<T> //consider to constrain to class
{
    bool IsSatisfiedBy(T candidate);
}
