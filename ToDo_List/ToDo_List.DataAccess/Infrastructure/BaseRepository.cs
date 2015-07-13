using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.DataAccess.Infrastructure
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext DataContext;
        protected readonly DbSet<T> DataSet;

        public BaseRepository(DbContext dbContext)
        {
            DataContext = dbContext;
            DataSet = DataContext.Set<T>();
        }

        public T Get(int id)
        {

            return DataSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> Get(Func<T, bool> filter)
        {
            return DataSet.Where(filter);
        }

        public T GetOne(Func<T, bool> filter)
        {
            return DataSet.Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return DataSet;
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            return DataSet.Where(filter);
        }

        public void AddItem(T item)
        {
            DataSet.Add(item);
        }

        public void UpdateItem(T item)
        {
            DataContext.Entry(item).State = EntityState.Modified;
        }

        public void DeleteItem(T item)
        {
            DataSet.Remove(item);
        }
    }
}
