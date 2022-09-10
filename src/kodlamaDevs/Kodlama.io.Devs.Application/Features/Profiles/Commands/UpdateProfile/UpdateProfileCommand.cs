using AutoMapper;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.CrudDtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Profile = Kodlama.io.Devs.Domain.Entities.Profile;

namespace Kodlama.io.Devs.Application.Features.Profiles.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<UpdatedProfileDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, UpdatedProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IProfileRepository _profileRepository;

            public UpdateProfileCommandHandler(IMapper mapper, IProfileRepository profileRepository)
            {
                _mapper = mapper;
                _profileRepository = profileRepository;
            }

            public async Task<UpdatedProfileDto> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
            {
                //[TODO] business rules
                Profile? profile = await _profileRepository.GetAsync(p => p.Id == request.Id);
                profile.UserId = request.UserId;
                profile.GithubAddress = request.GithubAddress;

                Profile mappedProfile = _mapper.Map<Profile>(profile);

                Profile updatedProfile = await _profileRepository.UpdateAsync(mappedProfile);
                UpdatedProfileDto updatedProfileDto = _mapper.Map<UpdatedProfileDto>(updatedProfile);

                return updatedProfileDto;
            }
        }
    }
}
