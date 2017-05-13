using CollectionManager.Models.entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManager.Models.dto
{
    public class CollectionDTO
    {

        public static IList<Collection> Collections { get; set; }

        public CollectionDTO()
        {
            Collections = retrieveMockingList();
        }

        private IList<Collection> retrieveMockingList()
        {
            IList<Collection> collections = new List<Collection>();

            collections.Add(new Book("A", "UFSC", new User("Marcelo", "(48) 98434-2715")));
            collections.Add(new Book("B", "UDESC", new User("Thiago", "(48) 98543-2112")));
            collections.Add(new Book("C", "UNISUL", new User("Karine", "(48) 98222-2123")));

            collections.Add(new CD("Green Day", "Botafogo", new User("Marcelo", "(48) 98434-2715")));
            collections.Add(new CD("Metallica", "Flamengo", new User("Thiago", "(48) 98543-2112")));
            collections.Add(new CD("The Offspring", "Santa Tereza" , new User("Karine", "(48) 98222-2123")));

            collections.Add(new DVD("Inside Out", "Centro - RJ",  new User("Marcelo", "(48) 98434-2715")));
            collections.Add(new DVD("Jurassic World",  "Centro - Fpolis", new User("Thiago", "(48) 98543-2112")));
            collections.Add(new DVD("Avangers", "Córrego Grande", new User("Karine", "(48) 98222-2123")));

            return collections;
        }
    }
}