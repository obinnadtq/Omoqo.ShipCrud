using System.ComponentModel.DataAnnotations;

namespace Ship.CRUD.Dtos;

#nullable enable
#nullable disable warnings
public class ShipRequestDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int Length { get; set; }

    [Required]
    public int Width { get; set; }

    [Required]
    public string Code { get; set; }
}
