using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.QueryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Profiles.Models
{
    public class ProfileListModel:BasePageableModel
    {
        public IList<ProfileListDto> Items { get; set; }
    }
}
