using Microsoft.AspNetCore.Mvc;
using Moq;
using SAASystem.Context.Interface;
using SAASystem.Controllers;
using SAASystem.Models.Context;
using Xunit;

namespace SAASystem.Test
{
    public class ContractControllerTest
    {
        private readonly ContractController _controller;

        public ContractControllerTest()
        {
            _controller = new ContractController();
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
            var result = _controller.Show(2);
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
