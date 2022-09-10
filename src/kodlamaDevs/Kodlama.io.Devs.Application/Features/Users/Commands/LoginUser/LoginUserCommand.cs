using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private IMapper _mapper;
            private IUserRepository _userRepository;
            private ITokenHelper _tokenHelper;
            private IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginUserCommandHandler(IMapper mapper, IUserRepository userRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                //[TODO] user var mı diye kontrol et
                User user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                
                var userOperationClaims = await _userOperationClaimRepository
                   .GetListAsync(o => o.UserId == user.Id,
                   include: u => u.Include(c => c.OperationClaim),
                   cancellationToken: cancellationToken
                   );

                AccessToken accessToken = _tokenHelper.CreateToken(_mapper.Map<User>(user), userOperationClaims.Items.Select(x => x.OperationClaim).ToList());
                return accessToken;
            }
        }
    }
}
