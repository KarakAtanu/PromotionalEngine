using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class PromoRuleItem
    {
        public string Id { get; set; }
        public int NumberOfUnit { get; set; }
    }
}
