using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Services;
public interface ICrudService<T>
        where T : AggregateRoot<Guid>
{
    IQueryable<T> GetAsync(Expression<Func<T, bool>> predicate );

    Task<T> GetByIdAsync(Guid guid);

    Task<T> AddOrUpdateAsync(T entity);

    Task DeleteAsync(T entity);

}
