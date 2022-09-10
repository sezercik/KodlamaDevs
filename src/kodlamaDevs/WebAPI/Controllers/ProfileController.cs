using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.CreateProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.DeleteProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Commands.UpdateProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.CrudDtos;
using Kodlama.io.Devs.Application.Features.Profiles.Dtos.QueryDtos;
using Kodlama.io.Devs.Application.Features.Profiles.Models;
using Kodlama.io.Devs.Application.Features.Profiles.Queries.GetByIdProfile;
using Kodlama.io.Devs.Application.Features.Profiles.Queries.GetListProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProfileCommand createProfileCommand)
        {
            CreatedProfileDto result = await Mediator.Send(createProfileCommand);
            return Created("", result);
        }

        [HttpPost("delete/{{Id}}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProfileCommand deleteProfileCommand)
        {
            DeletedProfileDto result = await Mediator.Send(deleteProfileCommand);
            return Created("", result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProfileCommand updateProfileCommand)
        {
            UpdatedProfileDto result = await Mediator.Send(updateProfileCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProfileQuery getListProfileQuery = new() { PageRequest = pageRequest };
            ProfileListModel result = await Mediator.Send(getListProfileQuery);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProfileQuery getByIdProfileQuery)
        {
            ProfileGetByIdDto profileGetByIdDto = await Mediator.Send(getByIdProfileQuery);
            return Ok(profileGetByIdDto);
        }

        [HttpGet("getbyuserid/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdProfileQuery getByUserIdProfileQuery)
        {
            ProfileGetByUserIdDto profileGetByUserIdDto = await Mediator.Send(getByUserIdProfileQuery);
            return Ok(profileGetByUserIdDto);
        }

    }
}
