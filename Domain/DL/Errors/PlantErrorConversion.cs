using SharedImplementation.BinaryFlag;
using static Domain.DL.Errors.PlantErrors;

namespace Domain.DL.Errors;
internal sealed class PlantErrorConversion
{
    public static IEnumerable<string> Convert(BinaryFlag flag)
    {
        List<string> errors = new();
        if(flag == SpeciesInvalid)
        {
            errors.Add("Species is invalid.");
        }
        if(flag == MaximumHeightInvalid)
        {
            errors.Add("Maximum Height is invalid.");
        }
        return errors;
    }
}
