using AutoMapper;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.DeletePLTechnology
{
    public class DeletePLTechnologyCommand : IRequest<DeletedPLTechnologyDto>
    {
        public int Id { get; set; }

        public class DeletePLTechnologyCommandHandler : IRequestHandler<DeletePLTechnologyCommand, DeletedPLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;

            public DeletePLTechnologyCommandHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedPLTechnologyDto> Handle(DeletePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                PLTechnology? pLTechnology = await _pLTechnologyRepository.GetAsync(p => p.Id == request.Id);

                PLTechnology mappedPLTechnology = _mapper.Map<PLTechnology>(request);
                PLTechnology deletedPLTechnology = await _pLTechnologyRepository.DeleteAsync(mappedPLTechnology);
                DeletedPLTechnologyDto deletedPLTechnologyDto = _mapper.Map<DeletedPLTechnologyDto>(deletedPLTechnology);
                return deletedPLTechnologyDto;
            }
        }
    }
}
