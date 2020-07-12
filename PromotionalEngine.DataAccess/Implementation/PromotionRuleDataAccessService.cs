using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.DataStore;
using System;

namespace PromotionalEngine.DataAccess
{
    public class PromotionRuleDataAccessService
    {
        private IStore _dataStore;

        public PromotionRuleDataAccessService(IStore dataStore)
        {
            _dataStore = dataStore;
        }

        public PromotionRules GetPromotionRules()
        {
            var promoRules = _dataStore.PromotionRules;
            if (promoRules == null)
                throw new NullReferenceException("Promotion Rules store does not exists");
            return promoRules;
        }
    }
}