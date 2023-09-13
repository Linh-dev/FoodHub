using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Common.Services;
public class CrudService<T> : ICrudService<T>
        where T : AggregateRoot<Guid>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IRepository<T, Guid> _repository;
    public CrudService(IRepository<T, Guid> repository)
    {
        _unitOfWork = repository.UnitOfWork;
        _repository = repository;
    }

    public IQueryable<T> GetAsync(Expression<Func<T, bool>> predicate = null)
    {
        return predicate != null ?
            _repository.GetAll().Where(predicate):
            _repository.GetAll();
    }

    public Task<T> GetByIdAsync(Guid Id)
    {
        ValidationException.Requires(Id != Guid.Empty, "Invalid Id. Values cannot be null!");

        return _repository.FirstOrDefaultAsync(_repository.GetAll().Where(x => x.Id == Id));
    }

    public async Task<T> AddOrUpdateAsync(T entity)
    {
        await _repository.AddOrUpdateAsync(entity);
        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
        }
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
    }


}