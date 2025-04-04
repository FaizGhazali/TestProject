using FrontEnd.MVVM.Services;
using FrontEnd.MVVM.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Test.ViewModelTests
{
    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void MainViewModel_Should_Return_Correct_Message()
        {
            // Arrange
            var mockService = new Mock<IMyService>();
            mockService.Setup(s => s.GetMessage()).Returns("Test Message");

            // Act
            var viewModel = new MainViewModel(mockService.Object);

            // Assert
            Assert.That(viewModel.Message, Is.EqualTo("Test Message"));

        }
    }
}
