using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class PromotionRules
    {
        public IList<SinglePromoRule> SingleRules { get; set; }
        public IList<ComboPromoRule> ComboRules { get; set; }
    }
}
