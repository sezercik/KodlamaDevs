using Core.Application.Requests;
using Core.Security.Dtos;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;
using Kodlama.io.Devs.Application.Features.Users.Commands.LoginUser;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Features.Users.Models;
using Kodlama.io.Devs.Application.Features.Users.Queries.GetByIdUser;
using Kodlama.io.Devs.Application.Features.Users.Queries.GetListUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            CreatedUserDto result = await Mediator.Send(createUserCommand);
            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            AccessToken result = await Mediator.Send(loginUserCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            UserGetByIdDto userGetByIdDto = await Mediator.Send(getByIdUserQuery);
            return Ok(userGetByIdDto);
        }

    }
}
