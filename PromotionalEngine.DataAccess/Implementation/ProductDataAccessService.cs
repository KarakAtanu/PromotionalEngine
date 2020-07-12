using PromotionalEngine.Common.DomainModels;
using PromotionalEngine.DataAccess.DataStore;
using System;
using System.Collections.Generic;

namespace PromotionalEngine.DataAccess
{
    public class ProductDataAccessService
    {
        private IStore _dataStore;

        public ProductDataAccessService(IStore dataStore)
        {
            _dataStore = dataStore;
        }

        public IList<ProductItem> GetProducts()
        {
            var products = _dataStore.Products;
            if (products == null)
                throw new NullReferenceException("Product store does not exist");
            return products;
        }
    }
}