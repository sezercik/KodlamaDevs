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
    public class GetByIdProfileQuery : IRequest<ProfileGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProfileQueryHandler : IRequestHandler<GetByIdProfileQuery, ProfileGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IProfileRepository _profileRepository;

            public GetByIdProfileQueryHandler(IMapper mapper, IProfileRepository profileRepository)
            {
                _mapper = mapper;
                _profileRepository = profileRepository;
            }

            public async Task<ProfileGetByIdDto> Handle(GetByIdProfileQuery request, CancellationToken cancellationToken)
            {
                //[TODO] Business rules, var mı yok mu
                Profile? profile = await _profileRepository.GetAsync(p=>p.Id == request.Id);
                ProfileGetByIdDto profileGetByIdDto = _mapper.Map<ProfileGetByIdDto>(profile);

                return profileGetByIdDto;
            }
        }
    }
}
