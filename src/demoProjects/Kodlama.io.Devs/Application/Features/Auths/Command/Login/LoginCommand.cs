using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auths.Constants;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand:IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _businessRules;
            private readonly IUserRepository  _userRepository;

            public LoginCommandHandler(IAuthService authService, AuthBusinessRules businessRules, IUserRepository userRepository)
            {
                _authService = authService;
                _businessRules = businessRules;
                _userRepository = userRepository;
            }
            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.EmailMustBeInDatabaseWhenLogined(request.UserForLoginDto.Email);
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password,user.PasswordHash,user.PasswordSalt);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user,request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginedDto loginedDto = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken, Message = Messages.LoginSuccess };
                return loginedDto;
            }
        }
    }
}
