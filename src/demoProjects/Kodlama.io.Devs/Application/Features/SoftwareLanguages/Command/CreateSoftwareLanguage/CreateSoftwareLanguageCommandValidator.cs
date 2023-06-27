using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage
{
    public class CreateSoftwareLanguageCommandValidator: AbstractValidator<CreateSoftwareLanguageCommand>
    {
        public CreateSoftwareLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
