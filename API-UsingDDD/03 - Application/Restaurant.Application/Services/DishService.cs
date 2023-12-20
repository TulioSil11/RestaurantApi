using AutoMapper;
using Restaurant.Application.DTOs;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Models;

namespace Restaurant.Application.Services;
public class DishService: BaseService<Dish, DishDTO>, IDishService
{
    public DishService(IMapper mapper, IDishRepository repository): base(mapper, repository) {}
}
