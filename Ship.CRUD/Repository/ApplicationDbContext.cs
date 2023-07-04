using Microsoft.EntityFrameworkCore;
using Ship.CRUD.Models;

namespace Ship.CRUD.Repository;

public class ApplicationDbContext : DbContext 
{
    public DbSet<ShipModel> Ships { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
