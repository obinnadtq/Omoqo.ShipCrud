using System.ComponentModel.DataAnnotations;

namespace Ship.CRUD.Dtos;

#nullable enable
#nullable disable warnings
public class ShipResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Length { get; set; }

    public int Width { get; set; }

    public string Code { get; set; }
}
