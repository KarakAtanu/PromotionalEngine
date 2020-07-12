using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess;
using PromotionalEngine.DataAccess.DataStore;
using System.Collections.Generic;

namespace PromotionalEngine.Tests.DataAccess
{
    [TestClass]
    public class ProductDataAccessServiceTests
    {
        [TestMethod]
        public void GetProducts_WhenNoProductInTheStore_ShouldReturnEmptyList()
        {
            //Arrange   
            var mockDataStore = new Mock<IStore>();
            var prodDataAccessService = new ProductDataAccessService(mockDataStore.Object);
            mockDataStore.SetupGet(x => x.Products).Returns(new List<ProductItem>());
            //Act
            IList<ProductItem> result = prodDataAccessService.GetProducts();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
    }
}
