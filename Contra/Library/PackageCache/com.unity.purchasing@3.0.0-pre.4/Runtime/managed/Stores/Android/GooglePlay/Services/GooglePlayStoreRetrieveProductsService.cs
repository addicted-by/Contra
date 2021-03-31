using System.Collections.ObjectModel;
using UnityEngine.Purchasing.Extension;
using UnityEngine.Purchasing.Interfaces;

namespace UnityEngine.Purchasing
{
    class GooglePlayStoreRetrieveProductsService : IGooglePlayStoreRetrieveProductsService
    {
        IGooglePlayStoreService m_GooglePlayStoreService;
        IGoogleFetchPurchases m_GoogleFetchPurchases;
        IStoreCallback m_StoreCallback;
        internal GooglePlayStoreRetrieveProductsService(IGooglePlayStoreService googlePlayStoreService, IGoogleFetchPurchases googleFetchPurchases)
        {
            m_GooglePlayStoreService = googlePlayStoreService;
            m_GoogleFetchPurchases = googleFetchPurchases;
        }

        public void SetStoreCallback(IStoreCallback storeCallback)
        {
            m_StoreCallback = storeCallback;
        }

        public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
        {
            if (m_StoreCallback != null)
            {
                m_GooglePlayStoreService.RetrieveProducts(products, retrievedProducts =>
                {
                    m_StoreCallback.OnProductsRetrieved(retrievedProducts);
                    m_GoogleFetchPurchases.FetchPurchases();
                });
            }
        }
    }
}
