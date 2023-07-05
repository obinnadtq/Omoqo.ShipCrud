namespace Ship.CRUD.Models;

#nullable enable
#nullable disable warnings

public class ShipModel
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public int Length { get; set; }

    public int Width { get; set; }

    public string Code { get; set; }
}
