using AutoMapper;
using Restaurant.Application.DTOs;
using Restaurant.Domain.Models;

namespace Restaurant.Application;
public  class MappingEntities: Profile
{
    public MappingEntities()
    {
        CreateMap<Dish, DishDTO>();
        CreateMap<DishDTO, Dish>()
            .ConstructUsing((src, context) => src.Id != null? 
        new Dish(src.Id.Value, src.Name, src.Price) : new Dish(src.Name, src.Price));
    }
}
