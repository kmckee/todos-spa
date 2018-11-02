using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Models;

namespace Todos.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentRepository commentRepo;

        public CommentsController(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        [HttpGet("{todoId}")]
        public IEnumerable<Comment> Get(int todoId)
        {
            return commentRepo.GetCommentsForTodoId(todoId);
        }

        [HttpPost]
        public bool Post([FromBody] Comment newComment)
        {
            newComment.CreatedAt = DateTime.UtcNow;
            commentRepo.Create(newComment);
            return true;
        }
    }
}
