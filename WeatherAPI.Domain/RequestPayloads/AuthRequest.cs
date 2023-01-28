using FluentValidation;
using WeatherAPI.Domain.Exceptions;

namespace WeatherAPI.Domain.RequestPayloads
{
    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            var validator = new InlineValidator<AuthRequest>
            {
                ClassLevelCascadeMode = CascadeMode.Continue
            };

            validator.RuleFor(x => x.UserName)
                .NotEmpty()
                .EmailAddress();

            validator.RuleFor(x => x.Password)
                .Matches(@"^(.){8,}$")
                .WithMessage("Password must be at least 8 characters");

            var result = validator.Validate(this);
            if (!result.IsValid)
                throw new BadRequestException(string.Join($"{Environment.NewLine}", result.Errors));
        }
    }
}
