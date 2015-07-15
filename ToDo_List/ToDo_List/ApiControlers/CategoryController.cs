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
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService { get; set; }

        public CategoryController()
        {
            _categoryService = MvcApplication.Container.Get<CategoryService>();
        }
        // GET: api/Task
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllCategories()
        {
            var data = _categoryService.GetCategorys();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("category")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _categoryService.GetCategoryById(id));
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateCategory(Category category)
        {
            try
            {
                _categoryService.CreateCategory(category);
                return Request.CreateResponse(HttpStatusCode.OK, category);
            }
            catch (BadParametersException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPut]
        [Route("edit")]
        public HttpResponseMessage PutCategoryName(int id, string name)
        {
            try
            {
                _categoryService.SetCategoryName(id, name);
                return Request.CreateResponse(HttpStatusCode.OK, _categoryService.GetCategoryById(id));
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
        public HttpResponseMessage RemoveTask(int id)
        {
            try
            {
                _categoryService.RemoveCategory(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (InstanceNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e);
            }
        }
    }
}
