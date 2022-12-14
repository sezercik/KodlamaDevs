using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand :IRequest<CreatedUserDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly ITokenHelper _tokenHelper;

            public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                //[TODO] business rules ile email kontrol et
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                User mappedUser = _mapper.Map<User>(request.UserForRegisterDto);
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.PasswordHash = passwordHash;
                mappedUser.Status = true;

                User createdUser = await _userRepository.AddAsync(mappedUser);

                //Yeni üye olan kişilere default olarak 1 atanacaktır yani normal üye rolü
                await _userOperationClaimRepository.AddAsync(
                    new UserOperationClaim  { UserId = createdUser.Id, OperationClaimId = 1 }
                );

                CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
               return createdUserDto;

            }
        }
    }
}
