using CollectionManager.Models.entity;
using System;
using System.Collections.Generic;

namespace CollectionManager.Models.dto
{
    public class CollectionDTO
    {
        //Generate next value for CdCollection
        private static int nextVal()
        {
            return CdCollection = ++CdCollection;
        }

        //Start the app with an empty list or a mocking list
        public static void Start(bool testingPurpose)
        {
            if (Collections != null)
            {
                return;
            }

            Collections = new List<Collection>();
            if (testingPurpose)
            {
                Collections = retrieveMockingList();
            }
            CdCollection = Collections.Count;
        }

        //Insert a new collection
        public static bool InsertCollection(Collection collection)
        {
            foreach (Collection c in Collections)
            {
                if (SameTypeDiscriptionLocation(collection, c))
                {
                    return false;
                }
            }
            collection.SetAvailability();
            collection.CdCollection = nextVal();
            Collections.Add(collection);
            return true;
        }

        //Update an existing collection
        public static bool UpdateCollection(Collection collection)
        {
            foreach (Collection c in Collections)
            {
                if (SameTypeDiscriptionLocation(collection, c))
                {
                    return false;
                }

                if (c.CdCollection == collection.CdCollection)
                {
                    collection.SetAvailability();
                    Collections[Collections.IndexOf(c)] = collection;
                    break;
                }
            }
            return true;
        }

        //Delete an existing collection
        public static bool DeleteCollection(int cdCollection)
        {
            foreach (Collection c in Collections)
            {
                if (c.CdCollection == cdCollection)
                {
                    return Collections.Remove(c);
                    //Collections.RemoveAt(Collections.IndexOf(c));
                    //return true;
                }

            }
            return false;
        }

        //RN001: Two collections may have the same values for 'Type' and 'Discription', only whether they don't share 'Location'.
        //'collection' is User input; 'c' is from the list
        private static bool SameTypeDiscriptionLocation(Collection collection, Collection c)
        {
            bool SameTypeDiscriptionLocation = c.Type.Equals(collection.Type, StringComparison.InvariantCultureIgnoreCase) &&
                c.Description.Equals(collection.Description, StringComparison.InvariantCultureIgnoreCase) &&
                 c.Location.Equals(collection.Location, StringComparison.InvariantCultureIgnoreCase);

            //In order to allow an update in the 'User' of the same collection
            bool sameCollection = collection.CdCollection == c.CdCollection;

            if (SameTypeDiscriptionLocation && sameCollection)
            {
                return false;
            }
            return SameTypeDiscriptionLocation;
        }


        //This is a starting List of Collection
        public static IList<Collection> retrieveMockingList()
        {
            IList<Collection> collections = new List<Collection>();

            collections.Add(new Collection { CdCollection = 1, Description = "A", Type = "Livro", Location = "UFSC", Available = false, User = new User { Name = "Marcelo", Contact = "(48) 98434-2715" } });
            collections.Add(new Collection { CdCollection = 2, Description = "B", Type = "Livro", Location = "UDESC", Available = true });
            collections.Add(new Collection { CdCollection = 3, Description = "C", Type = "Livro", Location = "UNISUL", Available = false, User = new User { Name = "Karine", Contact = "(48) 98222-2123" } });

            collections.Add(new Collection { CdCollection = 4, Description = "Green Day", Type = "CD", Location = "Botafogo", Available = false, User = new User { Name = "Marcelo", Contact = "(48) 98434-2715" } });
            collections.Add(new Collection { CdCollection = 5, Description = "Metallica", Type = "CD", Location = "Flamengo", Available = false, User = new User { Name = "Thiago", Contact = "(48) 98543-2112" } });
            collections.Add(new Collection { CdCollection = 6, Description = "The Offspring", Type = "CD", Location = "Santa Tereza", Available = true });

            collections.Add(new Collection { CdCollection = 7, Description = "Inside Out", Type = "DVD", Location = "Centro - RJ", Available = true });
            collections.Add(new Collection { CdCollection = 8, Description = "Jurassic World", Type = "DVD", Location = "Centro - Fpolis", Available = false, User = new User { Name = "Thiago", Contact = "(48) 98543-2112" } });
            collections.Add(new Collection { CdCollection = 9, Description = "Avangers", Type = "DVD", Location = "Córrego Grande", Available = false, User = new User { Name = "Karine", Contact = "(48) 98222-2123" } });

            return collections;
        }

        public static int CdCollection
        {
            get;
            set;
        }

        public static IList<Collection> Collections
        {
            get;
            set;
        }
    }
}