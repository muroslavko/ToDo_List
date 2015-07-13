using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IRepository<Category>_repositoryCategory;

        //public HomeController(IRepository<Category> repositoryCategory)
        //{
        //    _repositoryCategory = repositoryCategory;
        //}
        public ActionResult Index()
        {
            return View();//_repositoryCategory.GetAll().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}