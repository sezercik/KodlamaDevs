using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Commands.DeletePLTechnology
{
    public class DeletePLTechnologyCommandValidator : AbstractValidator<DeletePLTechnologyCommand>
    {
        public DeletePLTechnologyCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
