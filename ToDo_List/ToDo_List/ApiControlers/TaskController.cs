using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Infrastructure.Exceptions;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.ApiControlers
{
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private ITaskService _taskService { get; set; }

        public TaskController()
        {
            _taskService = MvcApplication.Container.Get<TaskService>();
        }
        // GET: api/Task
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllTasks()
        {
            var data = _taskService.GetMyTasks();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("task/{id:int}")]
        public HttpResponseMessage GetTaskById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _taskService.GetMyTaskById(id));
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateMyTask(MyTask task)
        {
            try
            {
                _taskService.CreateMyTask(task);
                return Request.CreateResponse(HttpStatusCode.OK, task);
            }
            catch (BadParametersException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPut]
        //[Route("edit/{id:int}/{name:string}")]
        public HttpResponseMessage PutTaskName(int id, string name)
        {
            try
            {
                _taskService.SetMyTaskName(id, name);
                return Request.CreateResponse(HttpStatusCode.OK, _taskService.GetMyTaskById(id));
            }
            catch (BadParametersException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpDelete]
        [Route("remove/{id:int}")]
        public HttpResponseMessage RemoveTask(int id)
        {
            try
            {
                _taskService.RemoveMyTask(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpDelete]
        [Route("removedone/{id:int}")]
        public HttpResponseMessage RemoveAllDoneTask(int id)
        {
            try
            {
                _taskService.DeleteAllDone(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPut]
        [Route("changestate")]
        public HttpResponseMessage PutStateOfTask(IEnumerable<MyTask> tasks)
        {
            _taskService.ChangeStateOfTask(tasks);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
