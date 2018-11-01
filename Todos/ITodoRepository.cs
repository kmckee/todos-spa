using System.Collections.Generic;
using Todos.Models;

namespace Todos
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
    }
}