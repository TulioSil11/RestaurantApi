using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Models;

namespace Restaurant.Service.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BaseController<TEntity, TDTO>: ControllerBase where TEntity : BaseEntity
                                                       where TDTO : BaseDTO
{
    private readonly IBaseService<TEntity, TDTO> _service;
    public BaseController(IBaseService<TEntity, TDTO> service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAll()
    {
        try
        {
            var response = _service.GetAll();
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var response = _service.GetById(id);
            return new OkObjectResult(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Register([FromBody] TDTO request)
    {
        try
        {
            return new OkObjectResult(_service.Insert(request));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] TDTO request)
    {
        try
        {
            _service.Update(request);
            return new OkObjectResult(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _service.Delete(id);
            return new OkObjectResult(true);
        }
        catch (Exception ex)
        {
           return BadRequest(ex.Message);
        }
    }
}
