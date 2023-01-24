using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Invalid;
public class InvalidNoDataResult : Result
{
    public override string[] Errors => throw new NotImplementedException();

    public override ResultType ResultType => throw new NotImplementedException();

    public InvalidNoDataResult(params string[] errors)
    {

    }
}
