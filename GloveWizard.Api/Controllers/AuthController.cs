using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GloveWizard.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Domain.Service;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Domain.Controllers;
using GloveWizard.Domain.Helpers;

namespace APIContagem.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : BaseController
{
    private IAuthService _authService;

    public AuthController(IAuthService authService, IErrorLogger errorLogger)
        : base(errorLogger)
    {
        _authService = authService;
    }

    /// <summary>
    /// Faz login
    /// </summary>
    /// <response code="200">Retorna as informações do usuario e seu token</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="404">Não existe!</response>
    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest user)
    {
        try
        {
            ApiResponse<LoginResponse?> responseViewModel = await _authService.Login(user);

            return Response(responseViewModel);
        }
        catch (Exception ex)
        {
            _errorLogger.AddErrorLog(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Busca todos os usuarios criados.
    /// </summary>
    /// <response code="200">Retorna lista de usuarios criados</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="403">O recurso que você estava tentando visualizar é absolutamente proibido por algum motivo.</response>
    /// <response code="404">Não existe!</response>
    [Authorize(Roles = "Owner")]
    [Route("Users")]
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] PaginationFilter filter)
    {
        try
        {
            ApiResponse<PaginationResponse<IEnumerable<Users>>> responseViewModel =
                await _authService.GetUsersAsync(filter);

            return Response(responseViewModel);
        }
        catch (Exception ex)
        {
            _errorLogger.AddErrorLog(ex.Message);
            return null;
        }
    }
}
