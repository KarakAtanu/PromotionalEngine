using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess;
using PromotionalEngine.DataAccess.DataStore;
using System.Collections.Generic;

namespace PromotionalEngine.Tests.DataAccess
{
    [TestClass]
    public class PromotionRuleDataAccessServiceTests
    {
        [TestMethod]
        public void GetPromotionRules_NoRuleIsAddedInTheStore_ShouldReturnEmptyListForBothSingleAndComboRules()
        {
            //Arrange
            var mockDataStore = new Mock<IStore>();
            var promoRuleDataAccessService = new PromotionRuleDataAccessService(mockDataStore.Object);
            mockDataStore.SetupGet(x => x.PromotionRules).Returns(new PromotionRules
            {
                SingleRules = new List<SinglePromoRule>()
             ,
                ComboRules = new List<ComboPromoRule>()
            });

            //Act
            PromotionRules result = promoRuleDataAccessService.GetPromotionRules();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.SingleRules.Count == 0);
            Assert.IsTrue(result.ComboRules.Count == 0);
        }
    }
}
