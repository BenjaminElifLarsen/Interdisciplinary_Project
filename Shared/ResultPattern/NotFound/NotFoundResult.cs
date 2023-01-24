using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.NotFound;
public class NotFoundResult<T> : Result<T>
{
    private readonly string[] _errors;

    public override string[] Errors => _errors;

    public override T Data => default;

    public override ResultType ResultType => ResultType.NotFound;

    public NotFoundResult(params string[] errors)
    {
        _errors = errors;
    }

    public NotFoundResult(IEnumerable<string> errors)
    {
        _errors = errors.ToArray();
    }
}
