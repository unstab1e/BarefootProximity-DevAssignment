using DevAssignment.Controllers;
using DevAssignment.Models;
using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevAssignment.Tests.Controllers
{
    [TestClass]
    public class BarefootProximityControllerTest
    {
        // Difine and inialize class level objects and variables.
        BarefootProximityController controller = new BarefootProximityController();
        BarefootProximityModel model = new BarefootProximityModel();

        [TestMethod]
        public void PopulateItemsList()
        {
            // Act
            model = controller.PopulateItemsList(model);

            // Assert
            Assert.AreNotEqual(0, model.Items.Count);
        }

        [TestMethod]
        public void SearchForEmptyString()
        {
            // Act
            model = controller.PopulateItemsList(model);
            model = controller.ExecuteSearch(model);

            // Assert
            Assert.AreEqual(0, model.SearchResults.Count);
        }

        [TestMethod]
        public void SearchForLove()
        {
            // Arrange
            model.SearchCriteria = "Love";

            // Act
            model = controller.PopulateItemsList(model);
            model = controller.ExecuteSearch(model);

            // Assert
            Assert.AreEqual(1, model.SearchResults.Count);
        }

        [TestMethod]
        public void SearchForOr()
        {
            // Arrange
            model.SearchCriteria = "or";

            // Act
            model = controller.PopulateItemsList(model);
            model = controller.ExecuteSearch(model);

            // Assert
            Assert.AreEqual(2, model.SearchResults.Count);
        }

        [TestMethod]
        public void SearchForNonExistantBlah()
        {
            // Arrange
            model.SearchCriteria = "blah";

            // Act
            model = controller.PopulateItemsList(model);
            model = controller.ExecuteSearch(model);

            // Assert
            Assert.AreEqual(0, model.SearchResults.Count);
        }

        [TestMethod]
        public void SearchForExistingBlahs()
        {
            // Arrange
            model.SearchList += ", BLAH, Blah, blah";
            model.SearchCriteria = "blah";

            // Act
            model = controller.PopulateItemsList(model);
            model = controller.ExecuteSearch(model);

            // Assert
            Assert.AreEqual(3, model.SearchResults.Count);
        }

    }
}
