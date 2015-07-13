using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.Services.Concrete
{
    public class CategoryService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CategoryService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }




    }
}