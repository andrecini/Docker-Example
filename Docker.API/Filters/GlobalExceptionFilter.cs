using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception occurred.");

        context.Result = new ObjectResult("Ocorreu um erro na API.")
        {
            Value = new StringContent("An unexpected error occurred."), 
            StatusCode = 500
        };

        base.OnException(context);
    }
}
