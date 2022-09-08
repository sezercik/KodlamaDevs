using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetListPLTechnologyByDynamic
{

    public class GetListPLTechnologyByDynamicQuery : IRequest<PLTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListPLTechnologyByDynamicQueryHandler : IRequestHandler<GetListPLTechnologyByDynamicQuery, PLTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IPLTechnologyRepository _pLTechnologyRepository;

            public GetListPLTechnologyByDynamicQueryHandler(IMapper mapper, IPLTechnologyRepository pLTechnologyRepository)
            {
                _mapper = mapper;
                _pLTechnologyRepository = pLTechnologyRepository;
            }

            public async Task<PLTechnologyListModel> Handle(GetListPLTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PLTechnology> pLTechnologies = await _pLTechnologyRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              m => m.Include(c => c.ProgrammingLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                PLTechnologyListModel mappedPLTechnologies = _mapper.Map<PLTechnologyListModel>(pLTechnologies);
                return mappedPLTechnologies;
            }
        }
    }

}
