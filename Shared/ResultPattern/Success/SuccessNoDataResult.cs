using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Success;
public class SuccessNoDataResult : Result
{
    public override ResultType ResultType => ResultType.SuccessNotData;
    public override string[] Errors => default;

    public SuccessNoDataResult()
    {

    }
}
