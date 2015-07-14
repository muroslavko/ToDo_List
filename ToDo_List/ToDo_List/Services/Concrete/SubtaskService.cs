using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using ToDo_List.DataAccess.Entities;
using ToDo_List.DataAccess.Infrastructure;
using ToDo_List.Infrastructure.Exceptions;
using ToDo_List.Services.Interfaces;

namespace ToDo_List.Services.Concrete
{
    public class SubtaskService : ISubtaskService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SubtaskService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }


        public List<Subtask> GetSubtask()
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                return unitOfWork.GetRepository<Subtask>().GetAll().ToList();
            }
        }

        public void CreateSubtask(Subtask subtask)
        {
            if (subtask.Text == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                unitOfWork.GetRepository<Subtask>().AddItem(subtask);
                unitOfWork.Commit();
            }
        }

        public void RemoveSubtask(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _subtaskRepository = unitOfWork.GetRepository<Subtask>();
                var subtask = _subtaskRepository.GetOne(x => x.Id == id);

                if (subtask == null)
                {
                    throw new InstanceNotFoundException("Subtask with specified id does not exist");
                }

                _subtaskRepository.DeleteItem(subtask);
                unitOfWork.Commit();
            }
        }

        public Subtask GetSubtaskById(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _subtaskRepository = unitOfWork.GetRepository<Subtask>();
                var subtask = _subtaskRepository.GetOne(x => x.Id == id);

                if (subtask == null)
                {
                    throw new InstanceNotFoundException("Subtask with specified id does not exist");
                }

                return subtask;
            }
        }

        public void SetSubtaskName(int id, string name)
        {
            if (name == String.Empty)
            {
                throw new BadParametersException("Missed a name");
            }
            using (var unitOfWork = _unitOfWorkFactory.NewUnitOfWork())
            {
                var _subtaskRepository = unitOfWork.GetRepository<Subtask>();
                var subtask = _subtaskRepository.GetOne(x => x.Id == id);

                if (subtask == null)
                {
                    throw new InstanceNotFoundException("Subtask with specified id does not exist");
                }
                subtask.Text = name;
                _subtaskRepository.UpdateItem(subtask);
                unitOfWork.Commit();
            }
        }


    }
}