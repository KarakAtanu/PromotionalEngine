using PromotionalEngine.Common.DomainModels;

namespace PromotionalEngine.DataAccess.Interface
{
    public interface IPromotionRuleDataAccessService
    {
        PromotionRules GetPromotionRules();
    }
}
