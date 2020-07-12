using PromotionalEngine.Common.DomainModels;
using System.Collections.Generic;

namespace PromotionalEngine.DataAccess.Interface
{
    public interface IProductDataAccessService
    {
        IList<ProductItem> GetProducts();
    }
}
