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
    public class SubtasksController : Controller
    {
        private ISubtaskService _subtaskService { get; set; }

        public SubtasksController()
        {
            _subtaskService = MvcApplication.Container.Get<SubtaskService>();
        }

        public PartialViewResult _GetSubtaskFor(int id)
        {
            ViewBag.TaskId = id;
            var list = _subtaskService.GetSubtask().Where(p => p.TaskId == id).ToList<Subtask>();
            return PartialView("_GetSubtaskFor", list);
        }
        [ChildActionOnly]
        public PartialViewResult _SubtasksForm(int id)
        {
            var task = new Subtask { TaskId = id };
            return PartialView("_SubtasksForm", task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _AddSubtask(Subtask subt)
        {
            try
            {
                _subtaskService.CreateSubtask(subt);
            }
            catch (BadParametersException e)
            {
                //помилка
            }
            ViewBag.TaskId = subt.TaskId;
            var list = _subtaskService.GetSubtask().Where(p => p.TaskId == subt.TaskId).ToList();
            return PartialView("_GetSubtaskFor", list);
        }
        public ActionResult ChangeStateOfSubtask(IEnumerable<Subtask> subtask)
        {
            _subtaskService.SetSubtaskState(subtask.Select(x => x.Id).ToArray(), subtask.Select(x => x.Complete).ToArray());
            return RedirectToAction("Details", "Tasks", new { id = subtask.FirstOrDefault().TaskId });
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
                var subtask = _subtaskService.GetSubtaskById((int)id);
                return View(subtask);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subtask subtask)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _subtaskService.SetSubtaskName(subtask.Id, subtask.Text);
                    return RedirectToAction("Details", "Tasks", new { id = subtask.TaskId.ToString() });
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
            return View(subtask);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var category = _subtaskService.GetSubtaskById((int)id);
                return View(category);
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
            var sub = _subtaskService.GetSubtaskById(id);
            _subtaskService.RemoveSubtask(id);
            return RedirectToAction("Details", "Tasks", new { id = sub.TaskId.ToString() });
        }
    }
}