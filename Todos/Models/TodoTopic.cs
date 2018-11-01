using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Models
{
    public class TodoTopic
    {
        public int Id { get; set; }

        public int TodoId { get; set; }
        public virtual Todo Todo { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
