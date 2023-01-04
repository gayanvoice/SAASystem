using Microsoft.AspNetCore.Mvc;
using SAASystem.Controllers;
using Xunit;

namespace SAASystem.Test
{
    public class ApartmentControllerTest
    {
        private readonly ApartmentController _controller;

        public ApartmentControllerTest()
        {
            _controller = new ApartmentController();
        }

        [Fact]
        public void Index_ReturnView()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

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
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Edit_ReturnView()
        {
            var result = _controller.Edit(1);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Delete_ReturnView()
        {
            var result = _controller.Delete(1);
            Assert.IsType<ViewResult>(result);
        }
    }
}