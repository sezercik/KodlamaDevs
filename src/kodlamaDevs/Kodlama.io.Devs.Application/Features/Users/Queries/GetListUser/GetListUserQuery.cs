using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;


namespace Kodlama.io.Devs.Application.Features.Users.Queries.GetListUser
{
    public class GetListUserQuery :IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserQueryHandler: IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public GetListUserQueryHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                //[TODO] gelecek derse göre ya yeni bir user alt sınıfı oluşturacağım çoğu kişini yaptığı gibi örn. AppUser
                //Ya da core packages'dan user'a hasone profile demek zorundayım
                //User listesini aldığımda profile'deki github linki gibi diğerlerini de almak gerekiyor.

                IPaginate<User> users = await _userRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

          
                UserListModel userListModel = _mapper.Map<UserListModel>(users);
                return userListModel;

            }
        }
    }
}
