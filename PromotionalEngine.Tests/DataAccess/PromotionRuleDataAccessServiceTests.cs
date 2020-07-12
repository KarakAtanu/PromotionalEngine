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
    public class PromotionRuleDataAccessServiceTests
    {
        private readonly PromotionRuleDataAccessService _promoRuleDataAccessService;
        private Mock<IStore> _mockDataStore;
        public PromotionRuleDataAccessServiceTests()
        {
            _mockDataStore = new Mock<IStore>();
            _promoRuleDataAccessService = new PromotionRuleDataAccessService(_mockDataStore.Object);
        }
        [TestMethod]
        public void GetPromotionRules_NoRuleIsAddedInTheStore_ShouldReturnEmptyListForBothSingleAndComboRules()
        {
            //Arrange            
            _mockDataStore.SetupGet(x => x.PromotionRules).Returns(new PromotionRules
            {
                SingleRules = new List<SinglePromoRule>()
             ,
                ComboRules = new List<ComboPromoRule>()
            });

            //Act
            PromotionRules result = _promoRuleDataAccessService.GetPromotionRules();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.SingleRules.Count == 0);
            Assert.IsTrue(result.ComboRules.Count == 0);
        }
        [TestMethod]
        public void GetPromotionRules_RulesAreAvailableInTheStore_ShouldNotReturnEmptyListForBothSingleAndComboRules()
        {
            //Arrange            
            _mockDataStore.SetupGet(x => x.PromotionRules).Returns(new PromotionRules
            {
                SingleRules = new List<SinglePromoRule>()
                {
                    new SinglePromoRule{Item = new PromoRuleItem{}}
                }
             ,
                ComboRules = new List<ComboPromoRule>()
                {
                   new ComboPromoRule
                   {
                       Items = new List<PromoRuleItem>()
                   }
                }
            });

            //Act
            PromotionRules result = _promoRuleDataAccessService.GetPromotionRules();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.SingleRules.Count > 0);
            Assert.IsTrue(result.ComboRules.Count > 0);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPromotionRules_PromotionRuleStoreDoesNotExist_ShouldThrowNullReferenceException()
        {
            //Arrange            
            //Act
            _promoRuleDataAccessService.GetPromotionRules();
            //Assert

        }
    }
}
