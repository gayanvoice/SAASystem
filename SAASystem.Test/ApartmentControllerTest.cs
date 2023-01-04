using Microsoft.AspNetCore.Mvc;
using Moq;
using SAASystem.Context.Interface;
using SAASystem.Controllers;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using Xunit;

namespace SAASystem.Test
{
    public class ApartmentControllerTest
    {
        private readonly Mock<IApartmentContext> _mockApartmentContext;
        private readonly Mock<IPropertyContext> _mockPropertyContext;
        private readonly Mock<ISuiteContext> _mockSuiteContext;
        private readonly ApartmentController _controller;

        public ApartmentControllerTest()
        {
            _mockApartmentContext = new Mock<IApartmentContext>();
            _mockPropertyContext = new Mock<IPropertyContext>();
            _mockSuiteContext = new Mock<ISuiteContext>();
            _controller = new ApartmentController(
                _mockApartmentContext.Object,
                _mockPropertyContext.Object,
                _mockSuiteContext.Object);
        }

        [Fact]
        public void Index_ReturnView()
        {
            ApartmentContextSingleton apartmentContextSingleton = ApartmentContextSingleton.Instance;
            ApartmentContextModel apartmentContextModel = apartmentContextSingleton.Select(1);
            //var result = _controller.Index();
            //Assert.IsType<ViewResult>(result);
            Assert.Equal(1, apartmentContextModel.ApartmentId);
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
