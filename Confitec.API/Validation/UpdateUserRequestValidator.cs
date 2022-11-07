using Confitec.API.Domain.Commands.Requests.User;
using FluentValidation;

namespace Confitec.API.Validation
{
    public class UpdateUserRequestValidator :  AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.BirthDate)
                .Must(t => t.Date < DateTime.Now)
                .WithMessage("Data e Nascimento deve ser menor que a data de hoje!");
        }
    }
}
