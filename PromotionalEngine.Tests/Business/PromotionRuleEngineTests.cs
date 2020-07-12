using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Business;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace PromotionalEngine.Tests.Business
{
    [TestClass]
    public class PromotionRuleEngineTests
    {
        private readonly Mock<IProductDataAccessService> _mockProductDataAccessService;
        private readonly Mock<IPromotionRuleDataAccessService> _mockPromotionRuleDataAccessService;
        private readonly PromotionRuleEngine _promotionRuleEngine;
        private Cart _cart;
        public PromotionRuleEngineTests()
        {
            _mockProductDataAccessService = new Mock<IProductDataAccessService>();
            _mockPromotionRuleDataAccessService = new Mock<IPromotionRuleDataAccessService>();
            _promotionRuleEngine = new PromotionRuleEngine(_mockProductDataAccessService.Object
                , _mockPromotionRuleDataAccessService.Object);
            _cart = null;
        }
        [TestMethod]
        public void GetCheckoutPrice_EmptyCart_ShouldReturnZero()
        {
            //Assert
            _cart = new Cart();
            //Act
            double result = _promotionRuleEngine.GetCheckoutPrice(_cart);
            //Assert
            Assert.AreEqual(0, result);
        }
        [DataTestMethod]
        [DataRow("A", 50)]
        [DataRow("B", 30)]
        [DataRow("C", 20)]
        public void GetCheckoutPrice_SingleItemWithSingleUnitInCart_ShoudReturnItemUnitPrice(string id, double unitPrice)
        {
            //Assert
            _cart = new Cart()
            {
                CartItems = new List<CartItem> { new CartItem {
              ItemId=id, Units=1
             }
             }
            };
            _mockProductDataAccessService.Setup(x => x.GetProducts()).Returns(
                new List<ProductItem> {
                 new ProductItem{
                  Id=id,UnitPrice=unitPrice
                 }
                }
                );
            //Act
            double result = _promotionRuleEngine.GetCheckoutPrice(_cart);
            //Assert
            Assert.AreEqual(unitPrice, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCheckoutPrice_NonExistentCart_ThrowArgumentNullException()
        {
            //Assert            
            //Act
            double result = _promotionRuleEngine.GetCheckoutPrice(_cart);
            //Assert
        }
    }
}
