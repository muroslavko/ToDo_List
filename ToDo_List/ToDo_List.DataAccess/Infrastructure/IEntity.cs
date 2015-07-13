using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.DataAccess.Infrastructure
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
