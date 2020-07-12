using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class SinglePromoRule : PromoRuleBase
    {
        public PromoRuleItem Item { get; set; }
    }
}
