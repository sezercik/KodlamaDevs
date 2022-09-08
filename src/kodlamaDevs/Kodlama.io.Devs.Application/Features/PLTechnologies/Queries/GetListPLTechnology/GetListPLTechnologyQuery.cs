using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetListPLTechnology
{
    public class GetListPLTechnologyQuery:IRequest<PLTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListPLTechonologyQueryHandler : IRequestHandler<GetListPLTechnologyQuery, PLTechnologyListModel>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;

            //[TODO] Business rules eklenecek
            public GetListPLTechonologyQueryHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<PLTechnologyListModel> Handle(GetListPLTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PLTechnology> pLTechonology = await _pLTechnologyRepository.GetListAsync(include: 
                                    m => m.Include(c => c.ProgrammingLanguage),
                                   index: request.PageRequest.Page,
                                   size: request.PageRequest.PageSize
                                    );


                    

                PLTechnologyListModel mappedPLTechnologyListModel = _mapper.Map<PLTechnologyListModel>(pLTechonology);
                return mappedPLTechnologyListModel;

            }
        }
    }
}
