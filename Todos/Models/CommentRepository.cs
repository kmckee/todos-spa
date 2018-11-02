using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Models
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(TodoContext db) : base(db)
        {
        }

        public IEnumerable<Comment> GetCommentsForTodoId(int todoId)
        {
            /*
            var matches = new List<Comment>();
            foreach (var comment in GetAll())
            {
                if (comment.TodoId == todoId)
                {
                    matches.Add(comment.Text);
                }
            }
            return comment;
            */

            return from comment in GetAll()
                   where comment.TodoId == todoId
                   orderby comment.CreatedAt 
                   select comment;
        }
    }
}
