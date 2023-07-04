using FluentValidation;

namespace Ship.CRUD.Dtos;

public class ShipRequestDtoValidator : AbstractValidator<ShipRequestDto>
{
	public ShipRequestDtoValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.NotNull();

		RuleFor(x => x.Length)
			.NotNull()
			.GreaterThan(0);

		RuleFor(x => x.Width)
			.NotNull()
			.GreaterThan(0);

		RuleFor(x => x.Code)
			.NotNull()
			.Matches(@"^[a-zA-Z]{4}-\d{4}-[a-zA-Z]{1}\d$");
	}
}