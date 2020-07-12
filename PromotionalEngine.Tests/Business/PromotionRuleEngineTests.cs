using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Business;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.Interface;
using System.Collections.Generic;

namespace PromotionalEngine.Tests.Business
{
    [TestClass]
    public class PromotionRuleEngineTests
    {
        [TestMethod]
        public void GetCheckoutPrice_EmptyCart_ShouldReturnZero()
        {
            //Arrange
            var cart = new Cart();
            var mockProductDataAccessService = new Mock<IProductDataAccessService>();
            var mockPromotionRuleDataAccessService = new Mock<IPromotionRuleDataAccessService>();
            var promotionRuleEngine = new PromotionRuleEngine(mockProductDataAccessService.Object
                , mockPromotionRuleDataAccessService.Object);
            //Act
            double result = promotionRuleEngine.GetCheckoutPrice(cart);
            //Assert
            Assert.AreEqual(0, result);
        }
        [DataTestMethod]
        [DataRow("A",50)]
        [DataRow("B", 30)]
        [DataRow("C", 20)]
        public void GetCheckoutPrice_SingleItemWithSingleUnitInCart_ShoudReturnItemUnitPrice(string id, double unitPrice)
        {
            //Assert            
            var mockProductDataAccessService = new Mock<IProductDataAccessService>();
            var mockPromotionRuleDataAccessService = new Mock<IPromotionRuleDataAccessService>();
            var promotionRuleEngine = new PromotionRuleEngine(mockProductDataAccessService.Object
                , mockPromotionRuleDataAccessService.Object);
            var cart = new Cart()
            {
                CartItems = new List<CartItem> { new CartItem {
              ItemId=id, Units=1
             }
             }
            };
            mockProductDataAccessService.Setup(x => x.GetProducts()).Returns(
                new List<ProductItem> {
                 new ProductItem{
                  Id=id,UnitPrice=unitPrice
                 }
                }
                );
            //Act
            double result = promotionRuleEngine.GetCheckoutPrice(cart);
            //Assert
            Assert.AreEqual(unitPrice, result);
        }
    }
}
