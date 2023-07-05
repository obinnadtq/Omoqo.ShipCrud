
using Ship.CRUD.Dtos;

namespace ShipCrud.Test.Factory;

public class ShipRequestDtoFactory : TestModelFactory
{
    protected override ShipRequestDto CreateBaseModel()
    {
        return new ShipRequestDto
        {
            Name = "Ship1",
            Length = 10,
            Width = 10,
            Code = "AAAA-1111-A1"
        };
    }

    public ShipRequestDtoFactory UseName(string name)
    {
        Dto.Name = name;
        return this;
    }

    public ShipRequestDtoFactory UseLength(int length)
    {
        Dto.Length = length;
        return this;
    }

    public ShipRequestDtoFactory UseWidth(int width)
    {
        Dto.Width = width;
        return this;
    }

    public ShipRequestDtoFactory UseCode(string code)
    {
        Dto.Code = code;
        return this;
    }

    public static ShipRequestDto Random => new ShipRequestDtoFactory().Create();
}
