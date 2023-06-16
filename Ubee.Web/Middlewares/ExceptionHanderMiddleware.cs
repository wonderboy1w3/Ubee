using Microsoft.AspNetCore.Diagnostics;
using Ubee.Service.Exceptions;

namespace Ubee.Web.Middlewares
{
	public class ExceptionHanderMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionHandlerMiddleware> logger;

		public ExceptionHanderMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
		{
			this.next = next;
			this.logger = logger;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await this.next(context);
			}
			catch (CustomException ex)
			{
				context.Response.StatusCode= ex.Code;
				await context.Response.WriteAsJsonAsync(new
				{
					code = ex.Code,
					message = ex.Message,
				});
			}
			catch(Exception ex)
			{
				this.logger.LogError($"{ex.ToString()}\n");
				context.Response.StatusCode= 500;
				await context.Response.WriteAsJsonAsync(new
				{
					code = 500,
					message = ex.Message,
				});
			}
		}
	}
}
