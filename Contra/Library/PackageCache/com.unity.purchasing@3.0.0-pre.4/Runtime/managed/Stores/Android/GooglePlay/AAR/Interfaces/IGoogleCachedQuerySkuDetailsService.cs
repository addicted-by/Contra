using System.Collections.Generic;
using UnityEngine;

namespace Stores
{
    interface IGoogleCachedQuerySkuDetailsService
    {
        HashSet<AndroidJavaObject> GetCachedQueriedSkus();

        void AddCachedQueriedSkus(List<AndroidJavaObject> queriedSkus);
    }
}
