using Microsoft.AspNetCore.Mvc;
using Moq;
using SAASystem.Context.Interface;
using SAASystem.Controllers;
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
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
