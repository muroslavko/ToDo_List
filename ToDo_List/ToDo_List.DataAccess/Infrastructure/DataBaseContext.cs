using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToDo_List.DataAccess.Entities;

namespace ToDo_List.DataAccess.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
    }
}
