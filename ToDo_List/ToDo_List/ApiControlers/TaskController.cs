using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.ApiControlers
{
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService = MvcApplication.Container.Get<TaskService>();

        //public TaskController(ITaskService taskService)
        //{
        //    _taskService = taskService;
        //}
        // GET: api/Task
        [HttpGet]
        [Route("all")]
        public IEnumerable<MyTask> Get()
        {
            //var task = new MyTask();
            var item = _taskService.GetMyTasks(); //_taskService.GetMyTasks();
            return item;
        }

        // GET: api/Task/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Task
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
        }
    }
}
