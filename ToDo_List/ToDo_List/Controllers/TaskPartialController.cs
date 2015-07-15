using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Controllers
{
    public class TaskPartialController : Controller
    {
        private ITaskService _mytaskService { get; set; }

        public TaskPartialController()
        {
            _mytaskService = MvcApplication.Container.Get<TaskService>();
        }
        public PartialViewResult _GetForCategory(int id)
        {
            ViewBag.CategoryId = id;
            var list = _mytaskService.GetMyTasks().Where(p => p.CategoryId == id).ToList();
            return PartialView("_GetForCategory", list);
        }

        [ChildActionOnly]
        public PartialViewResult _TaskForm(int id)
        {
            var task = new MyTask { CategoryId = id };
            return PartialView("_TaskForm", task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _AddTask(MyTask task)
        {
            task.Date = DateTime.Now;
            _mytaskService.CreateMyTask(task);

            ViewBag.CategoryId = task.CategoryId;
            var list = _mytaskService.GetMyTasks().Where(p => p.CategoryId == task.CategoryId).ToList();
            return PartialView("_GetForCategory", list);
        }
    }
}