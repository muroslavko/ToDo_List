using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using ToDo_List.DataAccess.Entities;
using ToDo_List.Infrastructure.Exceptions;

namespace ToDo_List.Services.Interfaces
{
    public interface ISubtaskService
    {
        List<Subtask> GetSubtask();
        void CreateSubtask(Subtask subtask);
        void RemoveSubtask(int id);
        Subtask GetSubtaskById(int id);
        void SetSubtaskName(int id, string name);
    }
}