using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.Interface;
using System.Linq;

namespace PromotionalEngine.Business
{
    public class PromotionRuleEngine
    {
        private IProductDataAccessService _productDataAccessService;
        private IPromotionRuleDataAccessService _promotionRuleDataAccessService;

        public PromotionRuleEngine(IProductDataAccessService productDataAccessService, IPromotionRuleDataAccessService promotionRuleDataAccessService)
        {
            this._productDataAccessService = productDataAccessService;
            this._promotionRuleDataAccessService = promotionRuleDataAccessService;
        }

        public double GetCheckoutPrice(Cart cart)
        {
            if (cart.CartItems.Count == 1)
            {
                return _productDataAccessService.GetProducts().Single(x => x.Id.Equals(cart.CartItems[0].ItemId)).UnitPrice;
            }
            return 0;
        }
    }
}