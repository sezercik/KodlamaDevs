using AutoMapper;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.CreatePLTechnology
{
    public class CreatePLTechnologyCommand : IRequest<CreatedPLTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public class CreatePLTechnologyCommandHandler : IRequestHandler<CreatePLTechnologyCommand, CreatedPLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;
            //[TODO] Business Rules
            public CreatePLTechnologyCommandHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedPLTechnologyDto> Handle(CreatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                PLTechnology mappedPLTechnology = _mapper.Map<PLTechnology>(request);
                PLTechnology createdPLTechnology = await _pLTechnologyRepository.AddAsync(mappedPLTechnology);

                CreatedPLTechnologyDto createdPLTechnologyDto = _mapper.Map<CreatedPLTechnologyDto>(createdPLTechnology);
                return createdPLTechnologyDto;
            }
        }

    }
}
