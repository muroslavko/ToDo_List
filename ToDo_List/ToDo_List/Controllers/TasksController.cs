using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Infrastructure.Exceptions;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Controllers
{
    public class TasksController : Controller
    {
        private ITaskService _mytaskService { get; set; }

        public TasksController()
        {
            _mytaskService = MvcApplication.Container.Get<TaskService>();
        }
        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var task = _mytaskService.GetMyTaskById((int)id);
                return View(task);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
        }
        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var task = _mytaskService.GetMyTaskById((int)id);
                ViewBag.CategoryId = new SelectList(_mytaskService.GetCategorys(), "Id", "Text", task.CategoryId);
                return View(task);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
            
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Text,Complete,CategoryId")] MyTask task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _mytaskService.SetMyTaskName(task.Id, task.Text);
                    ViewBag.CategoryId = new SelectList(_mytaskService.GetCategorys(), "Id", "Text", task.CategoryId);
                    return RedirectToAction("Details", new { id = task.Id.ToString() });
                }
                catch (BadParametersException e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                catch (InstanceNotFoundException e)
                {
                    return HttpNotFound();
                }

            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var task = _mytaskService.GetMyTaskById((int)id);
                return View(task);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _mytaskService.RemoveMyTask(id);
            return RedirectToAction("Index", "Categories");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStateOfTask([Bind(Include = "Id,Complete")] IEnumerable<MyTask> task)
        {
            if (task == null)
            {
                return RedirectToAction("Index", "Categories"); ;
            }
            _mytaskService.ChangeStateOfTask(task);
            return RedirectToAction("Index", "Categories");
        }
        public ActionResult DeleteDone(int id)
        {
            _mytaskService.DeleteAllDone(id);
            return RedirectToAction("Index", "Categories");
        }
    }
}