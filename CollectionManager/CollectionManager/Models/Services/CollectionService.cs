using CollectionManager.ElasticSearch;
using CollectionManager.Models.entity;
using System;
using System.Collections.Generic;

namespace CollectionManager.Models
{
    public class CollectionService
    {
        public static int CdCollection { get; private set; }
        private ESManager esManager = new ESManager();


        public static void reset()
        {
            CdCollection = 0;
        }

        private int nextVal()
        {
            CdCollection = (CdCollection + 1);
            return CdCollection;
        }

        public List<Collection> FindAllCollections()
        {
            List<Collection> collections = esManager.FindAllDocument();
            if (collections.Count > 0 && CdCollection == 0)
            {
                IniatializeCdCollection(collections);

            }
            return collections;
        }
        public void IniatializeCdCollection (List<Collection> collections)
        {
            collections.Sort( (a, b) => (
                                    a.CdCollection.ToString().CompareTo(
                                        b.CdCollection.ToString() ) ) );

            CdCollection = collections[collections.Count - 1].CdCollection;
        }

        //Insert a new collection
        public bool InsertCollection(Collection collection)
        {
            IList<Collection> collections = esManager.FindAllDocument();
            foreach (Collection c in collections)
            {
                if (SameTypeDiscriptionLocation(collection, c))
                {
                    return false;
                }
            }
            collection.SetAvailability();
            collection.CdCollection = nextVal();
            return esManager.InsertDocument(collection);
        }

        //Update an existing collection
        public bool UpdateCollection(Collection collection)
        {
            IList<Collection> collections = esManager.FindAllDocument();
            foreach (Collection c in collections)
            {
                foreach (Collection x in collections)
                {
                    if (SameTypeDiscriptionLocation(collection, x))
                    {
                        return false;
                    }
                }

                bool sameTypeDiscriptionLocation = SameTypeDiscriptionLocation(collection, c);
                bool sameCollections = c.CdCollection == collection.CdCollection;

                if ( !(!sameTypeDiscriptionLocation && sameCollections) ||
                        (!sameTypeDiscriptionLocation && sameCollections))
                {
                    collection.SetAvailability();
                    esManager.UpdateDocument(collection);
                    break;
                }
            }
            return true;
        }

        public bool DeleteCollection(int cdCollection)
        {
            return esManager.DeleteDocument(cdCollection); 
        }

        //RN001: Two collections may only have the same values for 'Type' and 'Discription', whether they don't share the same 'Location'.
        //'collection' is User input; 'c' is from the list
        private bool SameTypeDiscriptionLocation(Collection collection, Collection c)
        {
            bool sameTypeDiscriptionLocation = c.Type.Equals(collection.Type, StringComparison.InvariantCultureIgnoreCase) &&
                c.Description.Equals(collection.Description, StringComparison.InvariantCultureIgnoreCase) &&
                 c.Location.Equals(collection.Location, StringComparison.InvariantCultureIgnoreCase);

            //In order to allow an update in the 'User' of the same collection
            bool sameCollection = collection.CdCollection == c.CdCollection;

            if( sameTypeDiscriptionLocation && sameCollection )
            {
                return false;
            }
            return sameTypeDiscriptionLocation;
        }
    }
}