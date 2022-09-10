using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQuery :IRequest<UserGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public GetByIdUserQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                //[TODO] business rules

                User user = await _userRepository.GetAsync(u => u.Id == request.Id);
                UserGetByIdDto userGetByIdDto = _mapper.Map<UserGetByIdDto>(user);

                return userGetByIdDto;
            }
        }
    }
}
