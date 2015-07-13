using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.DataAccess.Entities
{
    public class Subtask : BaseEntity
    {
        //[DisplayName("Name")]
        public string Text { get; set; }
        public bool Complete { get; set; }
        public int TaskId { get; set; }
        public virtual MyTask Task { get; set; }
    }
}
