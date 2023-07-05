using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace ShipCrud.Test;

public static class ValidationTestExtensions
{
    private static readonly Lazy<ServiceProvider> container = new(() =>
    {
        var services = new ServiceCollection();
        services.AddValidatorsFromAssemblyContaining<Program>();
        services.AddFluentValidationAutoValidation();
        return services.BuildServiceProvider();
    });

    public static void BeValid(this ObjectAssertions assertions)
    {
        var validationResult = Validate(assertions);

        Execute.Assertion
            .ForCondition(validationResult.IsValid)
            .FailWith($"Expected model {assertions.Subject.GetType().Name} to be valid, but it was not: " +
                string.Join("; ", validationResult.Errors.Select(x => x.ErrorMessage)));
    }

    public static void NotBeValid(this ObjectAssertions assertions)
    {
        var validationResult = Validate(assertions);

        Execute.Assertion
            .ForCondition(!validationResult.IsValid)
            .FailWith($"Expected model {assertions.Subject.GetType().Name} to be invalid, but it was valid");
    }

    private static ValidationResult Validate(ObjectAssertions assertions)
    {
        var validator = (IValidator)container.Value.GetRequiredService(typeof(IValidator<>).MakeGenericType(assertions.Subject.GetType()));
        var validationContextType = typeof(ValidationContext<>).MakeGenericType(assertions.Subject.GetType());
        var validationContext = (IValidationContext)Activator.CreateInstance(validationContextType, assertions.Subject)!;
        return validator.Validate(validationContext);
    }
}
