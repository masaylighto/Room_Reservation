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
        private DbSet<T> Table { get; set; }

        public BaseRepository(DbSet<T> table)
        {
            Table = table;
        }

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<T> Get(bool trackChanges)
        {
            if (trackChanges)
            {
              return Table.AsQueryable<T>();
            }
            return Table.AsNoTracking<T>().AsQueryable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return Table.AsQueryable<T>().Where(expression);
            }
            return Table.AsNoTracking<T>().Where(expression);
        }

        public void Update(T entity)
        {
            Table.Remove(entity);
        }
    }
}
