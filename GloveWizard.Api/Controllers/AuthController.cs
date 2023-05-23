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

    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest user)
    {
        ApiResponse<LoginResponse?> responseViewModel = await _authService.Login(user);

        return Response(responseViewModel);
    }
}
