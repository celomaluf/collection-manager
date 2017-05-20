using CollectionManager.Models.entity;
using System.Collections.Generic;

namespace CollectionManager.ElasticSearch
{
    internal class ESManager
    {
        internal bool InsertDocument(Collection collection)
        {
            var response = ESConnection.CollectionESClient().Index(collection, i => i
                .Id(collection.CdCollection));
            return response.IsValid;
        }

        internal bool UpdateDocument(Collection collection)
        {
            var response = ESConnection.CollectionESClient().Index(collection, i => i
                .Id(collection.CdCollection));
            return response.IsValid;
        }

        internal List<Collection> FindAllDocument()
        {
            var response = ESConnection.CollectionESClient().Search<Collection>(s => s
                .Query(q => q.MatchAll()));
            List<Collection> collections = new List<Collection>();
            foreach (var hit in response.Hits)
            {
                collections.Add(hit.Source);
            }
            return collections;
        }

        internal bool DeleteDocument(int cdCollection)
        {
            var response = ESConnection.CollectionESClient().Delete<Collection>(cdCollection);
            return response.Found;
        }

    }
}