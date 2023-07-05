
using Ship.CRUD.Dtos;

namespace ShipCrud.Test.Factory;
public abstract class TestModelFactory
{
    protected ShipRequestDto Dto { get; private set; }

    protected TestModelFactory() => Dto = CreateBaseModel();

    public ShipRequestDto Create() => Dto;
    protected abstract ShipRequestDto CreateBaseModel();
}
