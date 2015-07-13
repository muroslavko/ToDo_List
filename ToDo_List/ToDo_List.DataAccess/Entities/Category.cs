using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_List.DataAccess.Infrastructure;

namespace ToDo_List.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        //[DisplayName("Category")]
        public string Text { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public Category()
        {
            Tasks = new List<Task>();
        }
    }
}
