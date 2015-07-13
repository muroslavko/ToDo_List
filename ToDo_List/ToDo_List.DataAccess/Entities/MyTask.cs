using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.DataAccess.Entities
{
    public class MyTask : BaseEntity
    {
        public DateTime Date { get; set; }
        //[DisplayName("Name")]
        public string Text { get; set; }
        public bool Complete { get; set; }
        //[DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Subtask> Subtasks { get; set; }
        public MyTask()
        {
            Subtasks = new List<Subtask>();
        }
    }
}
