using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class ComboPromoRule : PromoRuleBase
    {
        public List<PromoRuleItem> Items { get; set; }
    }
}
