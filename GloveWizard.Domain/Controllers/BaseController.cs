using GloveWizard.Domain.Helpers;
using GloveWizard.Domain.Utils.ResponseViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GloveWizard.Domain.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    public IErrorLogger _errorLogger { get; set; }

    public BaseController(IErrorLogger errorLogger)
    {
        _errorLogger = errorLogger;
    }

    protected void AddErrorLog(string message)
    {
        _errorLogger.AddErrorLog(message);
    }

    public IActionResult Response<T>(ApiResponse<T> apiResponse)
    {
        if (_errorLogger.hasError)
        {
            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                new { Errors = _errorLogger.Notifications().ToList() }
            );
            ;
        }
        else
        {
            return StatusCode((int)apiResponse.StatusCode, apiResponse);
        }
    }
}
