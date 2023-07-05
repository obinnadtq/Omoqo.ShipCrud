using FluentAssertions;
using ShipCrud.Test.Factory;
using Xunit;

namespace ShipCrud.Test.ValidationTest;

public class ShipRequesrDtoValidationTests
{
    [Fact]
    public void WhenPropertiesAreFilled_ThenModelIsValid()
    {
        ShipRequestDtoFactory.Random.Should().BeValid();
    }

    [Fact]
    public void WhenNameIsInvalid_ThenModelIsInValid()
    {
        new ShipRequestDtoFactory().UseName("").Create().Should().NotBeValid();
    }

    [Fact]
    public void WhenLengthIsInvalid_ThenModelIsInValid()
    {
        new ShipRequestDtoFactory().UseLength(0).Create().Should().NotBeValid();
    }

    [Fact]
    public void WhenWidthIsInvalid_ThenModelIsInValid()
    {
        new ShipRequestDtoFactory().UseWidth(0).Create().Should().NotBeValid();
    }

    [Fact]
    public void WhenCodeIsInvalid_ThenModelIsInValid()
    {
        new ShipRequestDtoFactory().UseCode("Anycode").Create().Should().NotBeValid();
    }
}