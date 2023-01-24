using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Invalid;
public class InvalidNoDataResult : Result
{
    private readonly string[] _errors;

    public override string[] Errors => _errors;

    public override T Data => default;

    public override ResultType ResultType => ResultType.Invalid;

    public InvalidNoDataResult(params string[] errors)
    {
        _errors = errors;
    }

    public InvalidNoDataResult(IEnumerable<string> errors)
    {
        _errors = errors;
    }
}
