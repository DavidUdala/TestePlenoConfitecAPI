using Confitec.API.Domain.Commands.Requests.User;
using Confitec.API.Models;
using FluentValidation;

namespace Confitec.API.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.BirthDate)
                .Must(t => t.Date < DateTime.Now)
                .WithMessage("Data e Nascimento deve ser menor que a data de hoje!");
        }
    }
}
