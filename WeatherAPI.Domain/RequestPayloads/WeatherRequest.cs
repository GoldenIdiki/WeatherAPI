using FluentValidation;
using WeatherAPI.Domain.Exceptions;

namespace WeatherAPI.Domain.RequestPayloads
{
    public class WeatherRequest
    {
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Validate()
        {
            var validator = new InlineValidator<WeatherRequest>
            {
                ClassLevelCascadeMode = CascadeMode.Continue
            };

            validator.RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("Location is required");

            validator.RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required");

            validator.RuleFor(x => x.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("Please provide a date that is not before the start date");

            var result = validator.Validate(this);

            if (!result.IsValid)
                throw new BadRequestException(string.Join($"{Environment.NewLine}", result.Errors));
        }
    }
}
