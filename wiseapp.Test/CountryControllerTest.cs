using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using wiseapp.Service;
using wiseapp.Controllers;
using wiseapp.Business;



namespace wiseapp.Test
{
    [TestClass]
    public class CountryControllerTest
    {
        private Mock<ICountryService> _countryServiceMock;
        CountryController objController;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {

            _countryServiceMock = new Mock<ICountryService>();
            objController = new CountryController(_countryServiceMock.Object);
            listCountry = new List<Country>() {
           new Country() { Id = 1, Name = "Chile" },
           new Country() { Id = 2, Name = "Bolivia" },
           new Country() { Id = 3, Name = "Japon" }
          };
        }



        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _countryServiceMock.Setup(x => x.GetAll()).Returns(listCountry);

            //Act
            var result = ((objController.Index() as ViewResult ).Model) as List<Country>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Chile", result[0].Name);
            Assert.AreEqual("Bolivia", result[1].Name);
            Assert.AreEqual("Japon", result[2].Name);

        }

        [TestMethod]
        public void Valid_Country_Create()
        {
            //Arrange
            Country c = new Country() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert 
            _countryServiceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_Country_Create()
        {
            // Arrange
            Country c = new Country() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _countryServiceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}
