using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Web;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Infrastructure.Exceptions;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CategoryService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        

        public List<Category> GetCategorys()
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                return unitOfWork.GetRepository<Category>().GetAll().ToList();
            }
        }

        public void CreateCategory(Category task)
        {
            if (task.Text == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                unitOfWork.GetRepository<Category>().AddItem(task);
                unitOfWork.Commit();
            }
        }

        public void RemoveCategory(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _categoryRepository = unitOfWork.GetRepository<Category>();
                var task = _categoryRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Category with specified id does not exist");
                }

                _categoryRepository.DeleteItem(task);
                unitOfWork.Commit();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _categoryRepository = unitOfWork.GetRepository<Category>();
                var task = _categoryRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Category with specified id does not exist");
                }

                return task;
            }
        }

        public void SetCategoryName(int id, string name)
        {
            if (name == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _categoryRepository = unitOfWork.GetRepository<Category>();
                var task = _categoryRepository.GetOne(x => x.Id == id);

                if (task == null)
                {
                    throw new InstanceNotFoundException("Category with specified id does not exist");
                }
                task.Text = name;
                _categoryRepository.UpdateItem(task);
                unitOfWork.Commit();
            }
        }

        // TODO : delete all done task in category




    }
}