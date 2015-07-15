using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Infrastructure.Exceptions;
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


        public List<MyTask> GetMyTasks()
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                return unitOfWork.GetRepository<MyTask>().GetAll().ToList();
            }
        }

        public void CreateMyTask(MyTask task)
        {
            if (task.Text == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                unitOfWork.GetRepository<MyTask>().AddItem(task);
                unitOfWork.Commit();
            }
        }

        public void RemoveMyTask(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _mytaskRepository = unitOfWork.GetRepository<MyTask>();
                var task = _mytaskRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Task with specified id does not exist");
                }

                _mytaskRepository.DeleteItem(task);
                unitOfWork.Commit();
            }
        }

        public MyTask GetMyTaskById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _mytaskRepository = unitOfWork.GetRepository<MyTask>();
                var task = _mytaskRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Task with specified id does not exist");
                }

                return task;
            }
        }

        public void SetMyTaskName(int id, string name)
        {
            if (name == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _mytaskRepository = unitOfWork.GetRepository<MyTask>();
                var task = _mytaskRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Task with specified id does not exist");
                }
                task.Text = name;
                _mytaskRepository.UpdateItem(task);
                unitOfWork.Commit();
            }
        }

        public void DeleteAllDone(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _taskRepository = unitOfWork.GetRepository<MyTask>();
                List<MyTask> tasks = unitOfWork.GetRepository<Category>().GetOne(x => x.Id == id)
                    .Tasks.Where(x=>x.Complete == true).ToList();
                foreach (var task in tasks)
                {
                    _taskRepository.DeleteItem(task);
                }
                unitOfWork.Commit();
            }
        }

        public void ChangeStateOfTask(IEnumerable<MyTask> tasks)
        {

            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _mytaskRepository = unitOfWork.GetRepository<MyTask>();
                foreach (var item in tasks)
                {
                    var task = _mytaskRepository.GetOne(x => x.Id == item.Id);
                    task.Complete = item.Complete;
                    _mytaskRepository.UpdateItem(task);
                }
                
                unitOfWork.Commit();
            }
        }

        public IEnumerable<Category> GetCategorys()
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                return unitOfWork.GetRepository<Category>().GetAll().ToList();
            }
        } 
    }
}