using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.CreatePLTechnology
{
    public class CreatePLTechnologyCommandValidator :AbstractValidator<CreatePLTechnologyCommand>
    {
        public CreatePLTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();


        }
    }
}
