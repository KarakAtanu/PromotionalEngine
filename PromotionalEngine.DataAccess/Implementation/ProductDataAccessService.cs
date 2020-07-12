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
            return _dataStore.Products;
        }
    }
}