using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using ToDo_List.Services.Concrete;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Infrastructure.Concrete
{
    public class ProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskService>().To<TaskService>();
            Bind<ISubtaskService>().To<SubtaskService>();
            Bind<ICategoryService>().To<CategoryService>();
        }
    }
}