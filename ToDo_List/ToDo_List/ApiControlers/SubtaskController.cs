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
    public class SubtaskController : ApiController
    {
                private ISubtaskService _subtaskService { get; set; }

                public SubtaskController()
        {
            _subtaskService = MvcApplication.Container.Get<SubtaskService>();
        }
        // GET: api/Task
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllSubtask()
        {
            var data = _subtaskService.GetSubtask();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("task")]
        public HttpResponseMessage GetSubtaskById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _subtaskService.GetSubtaskById(id));
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateSubtask(Subtask subtask)
        {
            try
            {
                _subtaskService.CreateSubtask(subtask);
                return Request.CreateResponse(HttpStatusCode.OK, subtask);
            }
            catch (BadParametersException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPut]
        [Route("edit")]
        public HttpResponseMessage PutSubtaskName(int id, string name)
        {
            try
            {
                _subtaskService.SetSubtaskName(id, name);
                return Request.CreateResponse(HttpStatusCode.OK, _subtaskService.GetSubtaskById(id));
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
        [Route("remove")]
        public HttpResponseMessage RemoveSubtask(int id)
        {
            try
            {
                _subtaskService.RemoveSubtask(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }


        [HttpPut]
        [Route("changestate")]
        public HttpResponseMessage PutStateOfSubtask(IEnumerable<Subtask> subtasks)
        {
            //_subtaskService.ChangeStateOfTask(tasks);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
