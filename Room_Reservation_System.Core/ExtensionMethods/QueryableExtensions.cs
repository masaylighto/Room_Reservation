using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.ExtensionMethods
{
    public static class QueryableExtensions
    {
        public static bool IsExist<TSource, Comparer >(this IQueryable<TSource> source, TSource item) where Comparer:class, IEqualityComparer<TSource>,new()  {
             return  source.ToList().Contains(item, new Comparer());         
        }
    }
}
