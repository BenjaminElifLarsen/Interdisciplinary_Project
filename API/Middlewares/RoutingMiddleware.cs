using Shared.Routing;

namespace API.Middlewares;

public class RoutingMiddleware
{
    private readonly RequestDelegate _next;

	public RoutingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context, IRoutingRegistry routing)
	{
		routing.SetUpRouting();


		await _next(context);
	}
}
