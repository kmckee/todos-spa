using System;
using Microsoft.AspNetCore.Mvc;

namespace Todos.Controllers
{
    public class HomeController : Controller
    {
        private ITodoRepository todoRepo;

        public HomeController(ITodoRepository todoRepo)
        {
            this.todoRepo = todoRepo;
        }

        public ViewResult Index()
        {
            var model = todoRepo.GetAll();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            var model = todoRepo.GetById(id);
            return View(model);
        }
    }
}
