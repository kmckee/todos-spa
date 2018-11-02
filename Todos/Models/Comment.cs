using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TodoId { get; set; }
    }
}
