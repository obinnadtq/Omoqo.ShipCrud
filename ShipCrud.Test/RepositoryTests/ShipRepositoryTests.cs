using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Ship.CRUD.Models;
using Ship.CRUD.Repository;
using Xunit;

namespace ShipCrud.Test.RepositoryTests;

public class ShipRepositoryTests
{
	private readonly ApplicationDbContext context;
	public ShipRepositoryTests()
	{
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());

        context = new ApplicationDbContext(optionsBuilder.Options);
    }

	[Fact]
	public async Task WhenGetAllShipsIsCalled_ThenReturnAllShips()
	{
		// Arrange
		var ships = new List<ShipModel>
		{
			new ShipModel
			{
				Id = 1,
				Name = "Ship1",
				Length = 10,
				Width = 10,
				Code = "AAAA-1111-A2"
			},
			new ShipModel
			{
				Id = 2,
				Name = "Ship2",
				Length = 10,
				Width = 10,
				Code = "AAAA-1111-A3"
			}
		};
		context.Ships.AddRange(ships);
		context.SaveChanges();

		// Act
		var shipRepo = new ShipRepository(context);
		var result = await shipRepo.GetAllShips();

		// Assert
		result.Count.Should().Be(2);
		result[0].Name.Should().Be("Ship1");
    }

    [Fact]
    public async Task WhenGetShipIsCalledAndIsExisting_ThenReturnShip()
    {
        // Arrange
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        var result = await shipRepo.GetShip(1);

        // Assert
        result?.Name.Should().Be("Ship1");
        result?.Length.Should().Be(10);
        result?.Length.Should().Be(10);
    }


    [Fact]
    public async Task WhenGetShipIsCalledAndNotExisting_ThenReturnExpectedResponse()
    {
        // Arrange
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        var result = await shipRepo.GetShip(2);

        // Assert
        result.Should().BeNull();
    }


    [Fact]
    public async Task WhenCreateShipIsCalled_ThenCreateShip()
    {

        // Arrange
        var ship = new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        };

        // Act
        var shipRepo = new ShipRepository(context);
        var result = await shipRepo.CreateShip(ship);

        // Assert
        result?.Name.Should().Be("Ship1");
        result?.Length.Should().Be(10);
        result?.Length.Should().Be(10);
    }

    [Fact]
    public async Task WhenUpdateIsCalledAndIsExisting_ThenUpdateShip()
    {
        // Arrange
        var request = new ShipModel
        {
            Name = "Ship3",
            Length = 11,
            Width = 11,
            Code = "AAAA-1111-A4"
        };
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        Func<Task> func = async () => await shipRepo.UpdateShip(request, 1);

        // Assert
        await func.Should().NotThrowAsync<Exception>();
    }
    [Fact]
    public async Task WhenUpdateIsCalledAndIsNotExisting_ThenError()
    {
        // Arrange
        var request = new ShipModel
        {
            Name = "Ship3",
            Length = 11,
            Width = 11,
            Code = "AAAA-1111-A4"
        };
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        Func<Task> func = async () => await shipRepo.UpdateShip(request, 2);

        // Assert
        await func.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public async Task WhenDeleteIsCalledAndIsExisting_ThenDelete()
    {
        // Arrange
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        Func<Task> func = async () => await shipRepo.DeleteShip(1);

        // Assert
        await func.Should().NotThrowAsync<Exception>();
    }

    [Fact]
    public async Task WhenDeleteIsCalledAndIsNotExisting_ThenThrowError()
    {
        // Arrange
        var request = new ShipModel
        {
            Name = "Ship3",
            Length = 11,
            Width = 11,
            Code = "AAAA-1111-A4"
        };
        context.Ships.Add(new ShipModel
        {
            Id = 1,
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A2"
        });
        context.SaveChanges();

        // Act
        var shipRepo = new ShipRepository(context);
        Func<Task> func = async () => await shipRepo.DeleteShip(2);

        // Assert
        await func.Should().ThrowAsync<Exception>();
    }
}
