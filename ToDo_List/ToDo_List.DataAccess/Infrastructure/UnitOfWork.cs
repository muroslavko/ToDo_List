using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IRepositoryFactory _repositoryFactory;
        private readonly DataBaseContext _dataContext = new DataBaseContext();

        public UnitOfWork(IRepositoryFactory repoFactory)
        {
            _repositoryFactory = repoFactory;
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            return _repositoryFactory.Resolve<T>(_dataContext);
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
