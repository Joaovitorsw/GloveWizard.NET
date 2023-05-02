namespace GloveWizard.Api.Configurations
{
    public class MiddlewareExpection
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<object> _logger;

        public MiddlewareExpection(ILogger<object> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception error)
            {
                _logger.LogError("Error capturado " + error.Message);
            }
        }
    }
}
