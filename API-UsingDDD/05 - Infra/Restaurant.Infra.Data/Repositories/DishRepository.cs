using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Models;
using Restaurant.Infra.Data.Contexts;

namespace Restaurant.Infra.Data.Repositories;

public class DishRepository: BaseRepository<Dish>, IDishRepository
{
    public DishRepository(RestaurantContext contex): base(contex) {}
}
