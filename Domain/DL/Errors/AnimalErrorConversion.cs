using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.AnimalErrors;

namespace Domain.DL.Errors;
internal class AnimalErrorConversion
{
    public static IEnumerable<string> Convert(BinaryFlag flag)
    {
        List<string> errors = new();
        if(flag == SpeciesInvalid)
        {
            errors.Add("Species is invalid.");
        }
        if (flag == MaximumOffspringInvalid)
        {
            errors.Add("The maximum offspring is invalid");
        }
        if (flag == MinimumOffspringInvalid)
        {
            errors.Add("The minimum offspring is invalid.");
        }
        if (flag == OffspringCombinationInvalid)
        {
            errors.Add("The combination of minimum and maximum offspring is invalid.");
        }
        return errors;
    }
}
