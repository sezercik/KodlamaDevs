using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.CreatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.DeletePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.UpdatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.CreateProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.DeleteProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.UpdateProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.CrudDtos;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.QueryDtos;
using Kodlama.io.Devs.Application.Features.Profiles.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Farkına varmadan automapper'ın profile'ı ile karıştırmışım. Bu sorunu geçici olarak çözmek için using kullanıyorum
//automapper işinde ise AutoMapper.Profile. 
//Kod refactor edilecektir
using Profile = Kodlama.io.Devs.Domain.Entities.Profile;

namespace Kodlama.io.Devs.Application.Features.Profiles.Profiles
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<Profile, ProfileListDto>().ReverseMap();
            CreateMap<IPaginate<Profile>, ProfileListModel>().ReverseMap();

            CreateMap<Profile, CreatedProfileDto>().ReverseMap();
            CreateMap<Profile, CreateProfileCommand>().ReverseMap();

            CreateMap<Profile, ProfileGetByIdDto>().ReverseMap();
            CreateMap<Profile, ProfileGetByUserIdDto>().ReverseMap();

            CreateMap<Profile, DeletedProfileDto>().ReverseMap();
            CreateMap<Profile, DeleteProfileCommand>().ReverseMap();

            CreateMap<Profile, UpdatedProfileDto>().ReverseMap();
            CreateMap<Profile, UpdateProfileCommand>().ReverseMap();

        }
    }
}
