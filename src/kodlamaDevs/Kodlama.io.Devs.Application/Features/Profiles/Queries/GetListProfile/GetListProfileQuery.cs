using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Profiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = Kodlama.io.Devs.Domain.Entities.Profile;

namespace Kodlama.io.Devs.Application.Features.Profiles.Queries.GetListProfile
{
    public class GetListProfileQuery : IRequest<ProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProfileQueryHandler : IRequestHandler<GetListProfileQuery, ProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProfileRepository _profileRepository;

            public GetListProfileQueryHandler(IMapper mapper, IProfileRepository profileRepository)
            {
                _mapper = mapper;
                _profileRepository = profileRepository;
            }

            public async Task<ProfileListModel> Handle(GetListProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Profile> profiles = await _profileRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                ProfileListModel profileListModel = _mapper.Map<ProfileListModel>(profiles);
                return profileListModel;
            }
        }
    }
}
