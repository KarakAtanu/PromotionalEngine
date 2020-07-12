using PromotionalEngine.Common.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PromotionalEngine.DataAccess.DataStore
{
    [ExcludeFromCodeCoverage]
    public class Store : IStore
    {
        private static IStore _storeInstance;

        private Store()
        {

        }

        public static IStore GetInstance()
        {
            if (_storeInstance == null)
                _storeInstance = new Store();

            return _storeInstance;
        }

        public IList<ProductItem> Products { get; private set; } = new List<ProductItem> {
        new ProductItem{ Id="A", UnitPrice=50.0 }
        ,new ProductItem{ Id="B", UnitPrice=30.0 }
        ,new ProductItem{ Id="C", UnitPrice=20.0 }
        ,new ProductItem{ Id="D", UnitPrice=15.0 }
        };

        public PromotionRules PromotionRules { get; private set; } = new PromotionRules
        {
            SingleRules = new List<SinglePromoRule>() {
           new SinglePromoRule{
            Item=new PromoRuleItem{Id="A",NumberOfUnit = 3},
            Price = 130
           },
           new SinglePromoRule{
            Item=new PromoRuleItem{Id="B",NumberOfUnit = 2},
            Price = 45
           }
          },

            ComboRules = new List<ComboPromoRule>() {
         new ComboPromoRule{
          Items=new List<PromoRuleItem>{
           new PromoRuleItem{ Id="C",NumberOfUnit=1 }
           ,new PromoRuleItem{ Id="D",NumberOfUnit=1 }
          }
          ,Price=30
         }
        }
        };
    }
}
