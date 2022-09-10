using AutoMapper;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.QueryDtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Profile = Kodlama.io.Devs.Domain.Entities.Profile;
namespace Kodlama.io.Devs.Application.Features.Profiles.Queries.GetByIdProfile
{
    public class GetByUserIdProfileQuery : IRequest<ProfileGetByUserIdDto>
    {
        public int UserId { get; set; }
        public class GetByUserIdProfileQueryHandler : IRequestHandler<GetByUserIdProfileQuery, ProfileGetByUserIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProfileRepository _profileRepository;

            public GetByUserIdProfileQueryHandler(IMapper mapper, IProfileRepository profileRepository)
            {
                _mapper = mapper;
                _profileRepository = profileRepository;
            }

            public async Task<ProfileGetByUserIdDto> Handle(GetByUserIdProfileQuery request, CancellationToken cancellationToken)
            {
                //[TODO] Business rules, var mı yok mu
                Profile? profile = await _profileRepository.GetAsync(p=>p.UserId == request.UserId); 
                ProfileGetByUserIdDto profileGetByUserIdDto = _mapper.Map<ProfileGetByUserIdDto>(profile);

                return profileGetByUserIdDto;
            }
        }
    }
}
