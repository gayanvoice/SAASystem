using Microsoft.AspNetCore.Mvc;
using SAASystem.Controllers;
using Xunit;

namespace SAASystem.Test.Controller
{
    /// <summary>
    /// PropertyControllerTest.cs executes the tests to check if each action returns view
    public class PropertyControllerTest
    {
        private readonly PropertyController _controller;

        public PropertyControllerTest()
        {
            _controller = new PropertyController();
        }

        //[Fact]
        //public void Index_ReturnView()
        //{
        //    var result = _controller.Index();
        //    Assert.IsType<ViewResult>(result);
        //}

        [Fact]
        public void List_ReturnView()
        {
            var result = _controller.List(null);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Show_ReturnView()
        {
            var result = _controller.Show(1);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Edit_ReturnView()
        {
            var result = _controller.Edit(1);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact]
        public void Delete_ReturnView()
        {
            var result = _controller.Delete(1);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
