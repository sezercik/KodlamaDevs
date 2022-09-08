

using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.CreatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.DeletePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.UpdatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetByIdPLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetListPLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Queries.GetListPLTechnologyByDynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLTechnologiesController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPLTechnologyQuery getByIdPLTechnologyQuery)
        {
            PLTechnologyGetByIdDto pLTechnologyGetByIdDto = await Mediator.Send(getByIdPLTechnologyQuery);
            return Ok(pLTechnologyGetByIdDto);
        }

        [HttpGet("GetPLTechnologyList")]
        public async Task<IActionResult> GetPLTechnologyList([FromQuery] PageRequest pageRequest)
        {
            GetListPLTechnologyQuery getListPLTechnologyQuery = new() { PageRequest = pageRequest };
            PLTechnologyListModel result = await Mediator.Send(getListPLTechnologyQuery);
            return Ok(result);
        }
        [HttpPost("GetPLTechnologyList/ByDynamic")]
        public async Task<IActionResult> GetPLTechnologyListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListPLTechnologyByDynamicQuery getListPLTechnologyByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            PLTechnologyListModel result = await Mediator.Send(getListPLTechnologyByDynamicQuery);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePLTechnologyCommand createPLTechnologyCommand)
        {
            CreatedPLTechnologyDto result = await Mediator.Send(createPLTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeletePLTechnologyCommand deletePLTechnologyCommand)
        {
            DeletedPLTechnologyDto result = await Mediator.Send(deletePLTechnologyCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdatePLTechnologyCommand updatePLTechnologyCommand)
        {
            UpdatedPLTechnologyDto result = await Mediator.Send(updatePLTechnologyCommand);
            return Ok(result);
        }
    }
}
