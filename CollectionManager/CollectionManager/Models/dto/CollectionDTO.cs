using CollectionManager.Models.entity;
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

        public static IList<Collection> retrieveMockingList()
        {
            IList<Collection> collections = new List<Collection>();

            collections.Add(new Collection { CdCollection = 1, Description = "A", Type = "Livro", Location = "UFSC", Available = true,User = new User { Name = "Marcelo", Contact = "(48) 98434-2715" } } );
            collections.Add(new Collection { CdCollection = 2, Description = "B", Type = "Livro", Location = "UDESC", Available = false });
            collections.Add(new Collection { CdCollection = 3, Description = "C", Type = "Livro", Location = "UNISUL", Available = true, User = new User { Name = "Karine", Contact = "(48) 98222-2123" } });

            collections.Add(new Collection { CdCollection = 4, Description = "Green Day", Type = "CD", Location = "Botafogo", Available = true, User = new User { Name = "Marcelo", Contact = "(48) 98434-2715" } });
            collections.Add(new Collection { CdCollection = 5, Description = "Metallica", Type = "CD", Location = "Flamengo", Available = true, User = new User { Name = "Thiago", Contact = "(48) 98543-2112" } });
            collections.Add(new Collection { CdCollection = 6, Description = "The Offspring", Type = "CD", Location = "Santa Tereza", Available = false });

            collections.Add(new Collection { CdCollection = 7, Description = "Inside Out", Type = "DVD", Location = "Centro - RJ", Available = false });
            collections.Add(new Collection { CdCollection = 8, Description = "Jurassic World", Type = "DVD", Location = "Centro - Fpolis", Available = true, User = new User { Name = "Thiago", Contact = "(48) 98543-2112" } });
            collections.Add(new Collection { CdCollection = 9, Description = "Avangers", Type = "DVD", Location = "Córrego Grande", Available = true, User = new User { Name = "Karine", Contact = "(48) 98222-2123" } });

            return collections;
        }
    }
}