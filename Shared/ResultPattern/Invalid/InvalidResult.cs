using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Invalid;
public class InvalidResult<T> : Result<T>
{
    private readonly string[] _errors;

    public InvalidResult(params string[] errors)
    {
        _errors = errors;
    }

    public InvalidResult(IEnumerable<string> errors)
    {
        _errors = errors.ToArray();
    }

    public override ResultType ResultType => ResultType.Invalid;

    public override string[] Errors => _errors;

    public override T Data => default;
}