using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Success;
public class SuccessResult<T> : Result
{
    private readonly T _data;
    public override string[] Errors => default;
    public override ResultType ResultType => ResultType.Success;
    public SuccessResult(T data)
    {
        _data = data;
    }

}
