using PromotionalEngine.Common.DomainModels;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PromotionalEngine.DataAccess.DataStore
{    
    public interface IStore
    {
        IList<ProductItem> Products { get; }
        PromotionRules PromotionRules { get; }
    }
}
