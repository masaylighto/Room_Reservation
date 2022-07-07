using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.SharedKernel.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Get(bool trackChanges);
        IEnumerable<T> Get(Expression<Func<T,bool>> expression,bool trackChanges);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
