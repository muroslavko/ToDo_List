using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);
        IEnumerable<T> Get(Func<T, Boolean> filter);
        T GetOne(Func<T, Boolean> filter);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Func<T, Boolean> filter);
        void AddItem(T item);
        void UpdateItem(T item);
        void DeleteItem(T item);
    }
}
