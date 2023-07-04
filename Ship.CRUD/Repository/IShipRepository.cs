using Ship.CRUD.Models;

namespace Ship.CRUD.Repository;

public interface IShipRepository
{
    Task<List<ShipModel>> GetAllShips();

    Task<ShipModel?> GetShip(int id);

    Task<ShipModel> CreateShip(ShipModel ship);

    Task UpdateShip(ShipModel ship, int id);

    Task DeleteShip(int id);
}