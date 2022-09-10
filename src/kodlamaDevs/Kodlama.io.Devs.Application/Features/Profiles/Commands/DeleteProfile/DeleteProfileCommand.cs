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

namespace Kodlama.io.Devs.Application.Features.Profiles.Commands.DeleteProfile
{
    public class DeleteProfileCommand : IRequest<DeletedProfileDto>
    {
        public int Id { get; set; }

        public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, DeletedProfileDto>
        {
            private readonly IMapper _mapper;
            private readonly IProfileRepository _profileRepository;

            public DeleteProfileCommandHandler(IMapper mapper, IProfileRepository profileRepository)
            {
                _mapper = mapper;
                _profileRepository = profileRepository;
            }

            public async Task<DeletedProfileDto> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
            {
                //[TODO] business rules
                Profile? profile = await _profileRepository.GetAsync(p => p.Id == request.Id);
                Profile mappedProfile = _mapper.Map<Profile>(profile);

                Profile deletedProfile = await _profileRepository.DeleteAsync(mappedProfile);
                DeletedProfileDto deletedProfileDto = _mapper.Map<DeletedProfileDto>(deletedProfile);

                return deletedProfileDto;
            }
        }
    }
}
