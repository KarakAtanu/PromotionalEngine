using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.Common.DomainModels
{
    [ExcludeFromCodeCoverage]
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
    }
}
