using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo_List.DataAccess.Entities;

namespace ToDo_List.Services.Interfaces
{
    public interface ITaskService
    {
        List<MyTask> GetMyTasks();
        void CreateMyTask(MyTask task);
        MyTask ChangeStateOfTask(int id);
    }
}
