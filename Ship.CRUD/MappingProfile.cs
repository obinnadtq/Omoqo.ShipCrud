using AutoMapper;
using Ship.CRUD.Dtos;
using Ship.CRUD.Models;

namespace Ship.CRUD;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<ShipModel, ShipResponseDto>();
        CreateMap<ShipRequestDto, ShipModel>();
    }
}
