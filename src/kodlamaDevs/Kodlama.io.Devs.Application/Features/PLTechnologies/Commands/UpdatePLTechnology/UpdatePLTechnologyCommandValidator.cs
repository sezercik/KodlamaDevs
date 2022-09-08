using FluentValidation;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.UpdatePLTechnology
{
    public class UpdatePLTechnologyCommandValidator : AbstractValidator<UpdatedPLTechnologyDto>
    {
        public UpdatePLTechnologyCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ImageUrl).NotEmpty();

        }
    }
}
