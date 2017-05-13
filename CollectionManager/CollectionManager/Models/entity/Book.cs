using CollectionManager.Models.entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManager.Models
{
    public class Book : Collection
    {
        protected override string Type => "Book";

        public Book (String description, String location, User user)
        {
            this.Description = description;                 
            this.Location = location;
            this.User = user;
        }
    }
}