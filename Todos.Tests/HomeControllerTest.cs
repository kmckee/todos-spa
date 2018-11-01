using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using Todos.Controllers;
using Todos.Models;
using Xunit;

namespace Todos.Tests
{
    public class HomeControllerTest
    {
        private ITodoRepository testRepo;
        private HomeController underTest;

        public HomeControllerTest()
        {
            testRepo = Substitute.For<ITodoRepository>();
            underTest = new HomeController(testRepo);
        }
        [Fact]
        public void Index_Returns_A_View()
        {
            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Displays_Todos()
        {
            var expected = new List<Todo>();
            testRepo.GetAll().Returns(expected);

            var result = underTest.Index();
            var model = result.Model;

            Assert.Same(expected, model);
        }

        [Fact]
        public void Details_Sets_Model()
        {
            var expected = new Todo() { Id = 42 };
            testRepo.GetById(expected.Id).Returns(expected);

            var result = underTest.Details(expected.Id);
            var model = result.Model;

            Assert.Same(expected, model);
        }
    }
}
