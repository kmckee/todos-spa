using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<TodoTopic> TodoTopics { get; set; }
    }
}
