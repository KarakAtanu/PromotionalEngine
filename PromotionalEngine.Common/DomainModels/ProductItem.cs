using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class ProductItem
    {
        public string Id { get; set; }
        public double UnitPrice { get; set; }
    }
}
