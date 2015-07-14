using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Infrastructure.Exceptions;

namespace ToDo_List.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategorys();
        void CreateCategory(Category task);
        void RemoveCategory(int id);
        Category GetCategoryById(int id);
        void SetCategoryName(int id, string name);
    }
}
