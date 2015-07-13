using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Services.Concrete
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public TaskService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public MyTask ChangeStateOfTask(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var task = unitOfWork.GetRepository<MyTask>().Get(id);
                task.Complete = true;
                unitOfWork.GetRepository<MyTask>().UpdateItem(task);
                unitOfWork.Commit();
                return task;
            }
        }


    }
}