using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Infrastructure;
using Task = ToDo_List.DataAccess.Entities.MyTask;

namespace ToDo_List.DataAccess.Repositories
{
    class MyTaskRepository : BaseRepository<Task>
    {
        public MyTaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
