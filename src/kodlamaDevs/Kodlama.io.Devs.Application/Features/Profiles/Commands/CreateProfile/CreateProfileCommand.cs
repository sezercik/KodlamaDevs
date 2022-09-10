using AutoMapper;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.CrudDtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = Kodlama.io.Devs.Domain.Entities.Profile;

namespace Kodlama.io.Devs.Application.Features.Profiles.Commands.CreateProfile
{
    public class CreateProfileCommand :IRequest<CreatedProfileDto>
    {
        public int UserId { get; set; }
        public string GithubAddress { get; set; }

        public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, CreatedProfileDto>
        {
            IProfileRepository _profileRepository;
            IMapper _mapper;

            public CreateProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper)
            {
                _profileRepository = profileRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProfileDto> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
            {
                Profile mappedProfile = _mapper.Map<Profile>(request);
                Profile createdProfile = await _profileRepository.AddAsync(mappedProfile);

                CreatedProfileDto createdProfileDto = _mapper.Map<CreatedProfileDto>(createdProfile);
                return createdProfileDto;
            }
        }
    }
}
