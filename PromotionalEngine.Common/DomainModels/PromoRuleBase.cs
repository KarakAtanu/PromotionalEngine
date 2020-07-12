using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class PromoRuleBase
    {
        public double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
