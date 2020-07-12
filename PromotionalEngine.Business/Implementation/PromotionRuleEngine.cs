using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.Interface;
using System;

namespace PromotionalEngine.Business
{
    public class PromotionRuleEngine
    {
        private IProductDataAccessService object1;
        private IPromotionRuleDataAccessService object2;

        public PromotionRuleEngine(IProductDataAccessService object1, IPromotionRuleDataAccessService object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public double GetCheckoutPrice(Cart cart)
        {
            return 0;
        }
    }
}