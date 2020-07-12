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
            return _dataStore.PromotionRules;
        }
    }
}