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

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetByIdPLTechnology
{
    public class GetByIdPLTechnologyQuery : IRequest<PLTechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdPLTechnologyQueryHandler :IRequestHandler<GetByIdPLTechnologyQuery, PLTechnologyGetByIdDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;

            public GetByIdPLTechnologyQueryHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<PLTechnologyGetByIdDto> Handle(GetByIdPLTechnologyQuery request, CancellationToken cancellationToken)
            {
                PLTechnology? pLTechnology = await _pLTechnologyRepository.GetAsync(p => p.Id == request.Id);

                PLTechnologyGetByIdDto pLTechnologyGetByIdDto = _mapper.Map<PLTechnologyGetByIdDto>(pLTechnology);
                return pLTechnologyGetByIdDto;
            }
        }
    }
}
