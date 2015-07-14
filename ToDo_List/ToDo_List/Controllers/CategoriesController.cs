using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Infrastructure.Exceptions;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService { get; set; }

        public CategoriesController()
        {
            _categoryService = MvcApplication.Container.Get<CategoryService>();
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_categoryService.GetCategorys());
        }

        public ActionResult Manage()
        {
            return View(_categoryService.GetCategorys());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.CreateCategory(category);
                    return RedirectToAction("Manage");
                }
                catch (BadParametersException e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    //return View(category); // повідомляти про помилку
                }
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var category = _categoryService.GetCategoryById((int) id);
                return View(category);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.SetCategoryName(category.Id, category.Text);
                    return RedirectToAction("Manage");
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var category = _categoryService.GetCategoryById((int) id);
                return View(category);
            }
            catch (InstanceNotFoundException e)
            {
                return HttpNotFound();
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.RemoveCategory(id);
            return RedirectToAction("Manage");
        }
    }
}