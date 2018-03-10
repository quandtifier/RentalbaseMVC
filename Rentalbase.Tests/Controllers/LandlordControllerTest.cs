using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rentalbase;
using Rentalbase.Controllers;
using Rentalbase.ViewModels;
using Rentalbase.Models;
using Rentalbase.DAL;

namespace Rentalbase.Tests.Controllers
{
    [TestClass]
    public class LandlordControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new LandlordController();

            // Act
            var result = controller.Index(null,null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
