using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.DataAccess.Infrastructure
{
    public abstract class BaseEntity : IEntity
    {
        public virtual int Id { get;set;}
    }
}
