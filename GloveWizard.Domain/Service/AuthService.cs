using AutoMapper;
using GloveWizard.Data.Contexts;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Constants;
using GloveWizard.Domain.Helpers;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GloveWizard.Domain.Service
{
    public class AuthService : IAuthService
    {
        private IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IErrorLogger _errorLogger;

        public AuthService(
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IErrorLogger errorLogger
        )
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _errorLogger = errorLogger;
        }

        public async Task<ApiResponse<LoginResponse?>> Login(LoginRequest user)
        {
            try
            {
                if (user == null)
                {
                    return new ApiResponse<LoginResponse>(
                        ApiMessagesConstant.NotFoundUser,
                        HttpStatusCode.NotFound
                    );
                }

                Users userDataBase = await GetUserByNickName(user.Login);

                if (userDataBase == null)
                {
                    return new ApiResponse<LoginResponse>(
                        ApiMessagesConstant.NotFoundUser,
                        HttpStatusCode.NotFound
                    );
                }

                if (user.Login == userDataBase.Login && user.Password == userDataBase.Password)
                {
                    var tokenString = GetJwtToken();
                    return new ApiResponse<LoginResponse>(
                        (
                            new LoginResponse
                            {
                                UserID = userDataBase.UserID,
                                UserName = userDataBase.UserName,
                                Token = tokenString,
                                ExpiresDate = DateTime.Now.AddHours(3),
                            }
                        ),
                        HttpStatusCode.OK
                    );
                }

                return new ApiResponse<LoginResponse>(
                    ApiMessagesConstant.UnauthorizedMessage,
                    HttpStatusCode.Unauthorized
                );
            }
            catch (Exception ex)
            {
                _errorLogger.AddErrorLog(ex.Message);
                return null;
            }
        }

        public async Task<Users> GetUserByNickName(string Login)
        {
            Users dataBaseFind = await _unitOfWork.Users.FindAsync(x => x.Login == Login);

            return dataBaseFind;
        }

        public string GetJwtToken()
        {
            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: new List<Claim>(),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
