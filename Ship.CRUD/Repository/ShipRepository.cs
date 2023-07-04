using Microsoft.EntityFrameworkCore;
using Ship.CRUD.Models;

namespace Ship.CRUD.Repository;

public class ShipRepository : IShipRepository
{
    private readonly ApplicationDbContext context;

    public ShipRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<List<ShipModel>> GetAllShips()
    {
        return await context.Ships.ToListAsync();
    }

    public async Task<ShipModel?> GetShip(int id)
    {
        return await context.Ships.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ShipModel> CreateShip(ShipModel ship)
    {
        context.Add(ship);
        await context.SaveChangesAsync();

        return ship;
    }

    public async Task UpdateShip(ShipModel ship, int id)
    {
        var shipToUpdate = CheckIfShipExistsInDb(id);

        shipToUpdate.Name = ship.Name;
        shipToUpdate.Width = ship.Width;
        shipToUpdate.Length = ship.Length;
        shipToUpdate.Code = ship.Code;

        context.Update(shipToUpdate);
        await context.SaveChangesAsync();
    }

    public async Task DeleteShip(int id)
    {
        var shipToDelete = CheckIfShipExistsInDb(id);

        context.Remove(shipToDelete);
        await context.SaveChangesAsync();
    }

    private ShipModel CheckIfShipExistsInDb(int id)
    {
        var ship = context.Ships.FirstOrDefault(x => x.Id == id);

        if (ship is null)
        {
            throw new Exception("ship is not in the database");
        }

        return ship;
    }
}
