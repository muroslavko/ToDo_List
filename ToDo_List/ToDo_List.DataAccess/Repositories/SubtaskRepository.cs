using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.DataAccess.Repositories
{
    class SubtaskRepository : BaseRepository<Subtask>
    {
        public SubtaskRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
