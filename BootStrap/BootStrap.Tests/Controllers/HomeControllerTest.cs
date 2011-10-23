using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootStrap;
using BootStrap.Controllers;

namespace BootStrap.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            //JsonResult test = controller.GrabNews();

            //Console.WriteLine(test.Data.ToString());

            var res = LoadNews.GetNews();
            res.ForEach(ds =>
                            {
                                Console.WriteLine(ds.NewsItems);
                            });

        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
