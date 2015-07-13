﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Controllers
{
    public class HomeController : Controller
    {
        //[Inject]
        //private readonly IRepository<Category> _repositoryCategory;
        //private readonly ITaskService _taskService;

        //public HomeController(ITaskService taskService)//IRepository<Category> repositoryCategory)
        //{
        //    //_repositoryCategory = repositoryCategory;
        //    _taskService = taskService;
        //}
        public ActionResult Index()
        {
            
            return View();
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