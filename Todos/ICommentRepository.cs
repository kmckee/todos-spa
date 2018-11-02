using System.Collections.Generic;
using Todos.Models;

namespace Todos
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsForTodoId(int todoId);
        void Create(Comment comment);
    }
}
