using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Business;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.Interface;

namespace PromotionalEngine.Tests.Business
{
    [TestClass]
    public class PromotionRuleEngineTests
    {
        [TestMethod]
        public void CalculateCheckoutPrice_EmptyCart_ShouldReturnZero()
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
    }
}
