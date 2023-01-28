using FluentValidation;
using WeatherAPI.Domain.Exceptions;

namespace WeatherAPI.Domain.RequestPayloads
{
    public class RegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public void Validate()
        {
            var validator = new InlineValidator<RegistrationRequest>
            {
                ClassLevelCascadeMode = CascadeMode.Continue
            };

            validator.RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name field is required");

            validator.RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name field is required");

            validator.RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Please provide a valid Email Address");

            validator.RuleFor(x => x.PhoneNumber)
                .Matches(@"^(234)[789]\d{9}$|^(0)[789]\d{9}$")
                .WithMessage("Please provide a valid phone number");

            validator.RuleFor(x => x.Password)
                .Matches(@"^(.){8,}$")
                .WithMessage("Password must be at least 8 characters");

            validator.RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Confirm Password field must match Password field");
            
            var result = validator.Validate(this);

            if (!result.IsValid)
                throw new BadRequestException(string.Join($"{Environment.NewLine}", result.Errors));
        }
    }
}
