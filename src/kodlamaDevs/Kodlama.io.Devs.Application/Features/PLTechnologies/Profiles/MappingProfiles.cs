using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.CreatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.DeletePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.UpdatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<PLTechnology, PLTechnologyListDto>()
               .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
               .ReverseMap();
            CreateMap<IPaginate<PLTechnology>, PLTechnologyListModel>().ReverseMap();

            CreateMap<PLTechnology, CreatedPLTechnologyDto>().ReverseMap();
            CreateMap<PLTechnology, CreatePLTechnologyCommand>().ReverseMap();

            CreateMap<PLTechnology, PLTechnologyGetByIdDto>().ReverseMap();

            CreateMap<PLTechnology, DeletedPLTechnologyDto>().ReverseMap();
            CreateMap<PLTechnology, DeletePLTechnologyCommand>().ReverseMap();

            CreateMap<PLTechnology, UpdatedPLTechnologyDto>().ReverseMap();
            CreateMap<PLTechnology, UpdatePLTechnologyCommand>().ReverseMap();
        }
    }
}
