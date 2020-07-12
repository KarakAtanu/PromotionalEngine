using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess;
using PromotionalEngine.DataAccess.DataStore;
using System;
using System.Collections.Generic;

namespace PromotionalEngine.Tests.DataAccess
{
    [TestClass]
    public class ProductDataAccessServiceTests
    {
        private Mock<IStore> _mockDataStore;
        private readonly ProductDataAccessService _prodDataAccessService;
        public ProductDataAccessServiceTests()
        {
            _mockDataStore = new Mock<IStore>();
            _prodDataAccessService = new ProductDataAccessService(_mockDataStore.Object);
        }
        [TestMethod]
        public void GetProducts_WhenNoProductInTheStore_ShouldReturnEmptyList()
        {
            //Arrange            
            _mockDataStore.SetupGet(x => x.Products).Returns(new List<ProductItem>());
            //Act
            IList<ProductItem> result = _prodDataAccessService.GetProducts();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        public void GetProducts_ProductsInTheStore_ShouldNotReturnEmptyList()
        {
            //Arrange            
            _mockDataStore.SetupGet(x => x.Products).Returns(new List<ProductItem> {
             new ProductItem{
              Id="x", UnitPrice=10
             }
            });
            //Act
            var result = _prodDataAccessService.GetProducts();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetProducts_ProductStoreDoesNotExist_ShouldThrowNullReferenceException()
        {
            //Arrange            
            //Act
            _prodDataAccessService.GetProducts();
            //Assert

        }
    }
}
