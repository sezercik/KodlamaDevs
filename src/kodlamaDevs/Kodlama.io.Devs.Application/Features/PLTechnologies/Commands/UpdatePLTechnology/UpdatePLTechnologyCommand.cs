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

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.UpdatePLTechnology
{
    public class UpdatePLTechnologyCommand : IRequest<UpdatedPLTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public class UpdatePLTechnologyCommandHandler: IRequestHandler<UpdatePLTechnologyCommand, UpdatedPLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdatePLTechnologyCommandHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedPLTechnologyDto> Handle(UpdatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                //[TODO] business rules

                PLTechnology? pLTechnology = await _pLTechnologyRepository.GetAsync(p => p.Id == request.Id);
                PLTechnology updatedPLTechnology = await _pLTechnologyRepository.UpdateAsync(_mapper.Map(request, pLTechnology));

                UpdatedPLTechnologyDto updatedPLTechnologyDto = _mapper.Map<UpdatedPLTechnologyDto>(updatedPLTechnology);

                return updatedPLTechnologyDto;
            }
        }
    }
}
