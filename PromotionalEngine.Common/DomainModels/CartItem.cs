using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class CartItem
    {
        public string ItemId { get; set; }
        public int Units { get; set; }
    }
}
