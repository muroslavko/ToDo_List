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
        void RemoveMyTask(int id);
        MyTask GetMyTaskById(int id);
        void SetMyTaskName(int id, string name);
        void DeleteAllDone(int id);
        void ChangeStateOfTask(IEnumerable<MyTask> tasks);
        IEnumerable<Category> GetCategorys();

    }
}
