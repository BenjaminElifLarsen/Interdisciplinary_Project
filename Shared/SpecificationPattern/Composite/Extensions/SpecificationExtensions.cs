using Shared.SpecificationPattern.Composite.BooleanSpecifications;

namespace Shared.SpecificationPattern.Composite.Extensions;
public static class SpecificationExtensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> spec1, ISpecification<T> spec2)
    {
        return new AndSpecification<T>(spec1, spec2);
    }

    public static ISpecification<T> AndNot<T>(this ISpecification<T> spec1, ISpecification<T> spec2)
    {
        return new AndNotSpecification<T>(spec1, spec2);
    }

    public static ISpecification<T> Or<T>(this ISpecification<T> spec1, ISpecification<T> spec2)
    {
        return new OrSpecification<T>(spec1, spec2);
    }

    public static ISpecification<T> OrNot<T>(this ISpecification<T> spec1, ISpecification<T> spec2)
    {
        return new OrNotSpecification<T>(spec1, spec2);
    }
}