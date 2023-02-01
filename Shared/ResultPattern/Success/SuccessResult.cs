using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Success;
public class SuccessResult<T> : Result<T>
{
    private readonly T _data;
    public override string[] Errors => default;
    public override ResultType ResultType => ResultType.Success;

    public override T Data => _data;

    public SuccessResult(T data)
    {
        _data = data;
    }

}
