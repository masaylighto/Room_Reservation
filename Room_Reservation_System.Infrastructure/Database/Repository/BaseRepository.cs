using Microsoft.EntityFrameworkCore;
using Room_Reservation_System.Core.Interfaces;
using Room_Reservation_System.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Infrastructure.Database.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> Table;

        public  BaseRepository(DbSet<T> table)
        {
            Table = table;
        }

        public virtual void Add(T entity)
        {
            Table.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public virtual IQueryable<T> Get(bool trackChanges)
        {
            if (trackChanges)
            {
              return Table.AsQueryable<T>();
            }
            return Table.AsNoTracking<T>().AsQueryable<T>();
        }

        public virtual IEnumerable<T> Get(Func<T, bool> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return Table.AsQueryable<T>().Where(expression);
            }
            return Table.AsNoTracking<T>().Where(expression);
        }

        public virtual void Update(T entity)
        {
            Table.Remove(entity);
        }
    }
}
