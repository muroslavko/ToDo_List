using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using Ninject;
using Ninject.Extensions.Factory;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Repositories;

namespace ToDo_List.DataAccess.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IUnitOfWorkFactory>().ToFactory();
            Bind<IRepositoryFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitOfWork>();


            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IRepository<MyTask>>().To<MyTaskRepository>();
            Bind<IRepository<Subtask>>().To<SubtaskRepository>();

        }
    }
    public interface IRepositoryFactory
    {
        IRepository<T> Resolve<T>(DataBaseContext dbContext) where T : IEntity;

        //T ResolveTyped<T>(ISession session);
    }

    public interface IUnitOfWorkFactory
    {
        IUnitOfWork NewUnitOfWork();
    }
}
