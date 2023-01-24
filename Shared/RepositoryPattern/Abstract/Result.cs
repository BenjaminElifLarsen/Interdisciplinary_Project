namespace Shared.RepositoryPattern.Abstract;
public abstract class Result<T>
{
	public abstract string[] Errors { get; }
	public abstract T Data { get; }

	internal Result()
	{

	}

}

public abstract class Result : Result<object>
{
	public override object Data => default;
}

public abstract class ErrorResult<T> : Result<T>
{
	private readonly string[] _errors;
    public override T Data => default;
    public override string[] Errors { get => _errors; }

	public ErrorResult(params string[] errors)
	{
		_errors = errors;
	}
}

public abstract class ErrorResult : ErrorResult<object>
{
	public ErrorResult(params string[] errors) : base(errors)
	{

	}
}