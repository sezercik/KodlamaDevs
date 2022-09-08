using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Models
{
    public class PLTechnologyListModel:BasePageableModel
    {
        public IList<PLTechnologyListDto> Items { get; set; }
    }
}
