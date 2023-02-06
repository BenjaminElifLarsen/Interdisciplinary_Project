using Microsoft.AspNetCore.Mvc;
using Shared.ResultPattern.Abstract;
using Shared.ResultPattern.Enum;

namespace API.Controllers.Extensions;

public static class ResultToHttpResponseConverter
{
    public static ActionResult FromResult<T>(this ControllerBase controller, Result<T> result)
    {
        return result.ResultType switch
        {
            ResultType.Success => controller.Ok(result.Data),
            ResultType.SuccessNotData => controller.NoContent(),
            ResultType.Invalid => controller.BadRequest(result.Errors),
            ResultType.NotFound => controller.NotFound(result.Errors),
            ResultType.Unexpected => controller.BadRequest(result.Errors),
            _ => throw new Exception("Dev made an erorr."), // Only thrown if the int value of ResultType is not a part of the ResultTypes. This should never be hit. 
        };
    }
}
