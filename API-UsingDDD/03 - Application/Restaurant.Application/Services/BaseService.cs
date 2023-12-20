using AutoMapper;
using Restaurant.Application.DTOs;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Domain.Models;

namespace Restaurant.Application.Services;

public class BaseService<TEntity, TDTO>: IBaseService<TEntity, TDTO> 
    where TEntity: BaseEntity
    where TDTO: BaseDTO
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

     public BaseService(IMapper mapper, IBaseRepository<TEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public Guid Insert(TDTO entity) => _repository.Add(_mapper.Map<TEntity>(entity));
    
    public void Update(TDTO entity) => _repository.Update(_mapper.Map<TEntity>(entity));

    public void Delete(Guid id) => _repository.Delete(id);
    
    public void Delete(TDTO entity) =>  _repository.Delete(_mapper.Map<TEntity>(entity));

    public IEnumerable<TDTO> GetAll() =>  _mapper.Map<IEnumerable<TDTO>>(_repository.GetAll()); 

    public TDTO GetById(Guid id) =>  _mapper.Map<TDTO>(_repository.GetById(id));
}
 