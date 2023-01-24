using Shared.ResultPattern.Enum;

namespace Shared.ResultPattern.Abstract;
public abstract class Result<T>
{
    public abstract string[] Errors { get; }
    public abstract T Data { get; }
    public abstract ResultType ResultType { get; }

    internal Result()
    {

    }
}

public abstract class Result : Result<object>
{
    public override object Data => default;
}