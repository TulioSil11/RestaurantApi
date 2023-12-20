using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;

namespace Restaurant.Service.API.Controllers;
public class DishController: BaseController<Dish, DishDTO>
{
   public DishController(IDishService service): base(service){}

}
