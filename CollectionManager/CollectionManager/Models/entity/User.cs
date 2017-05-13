using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManager.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Contact { get; set; }

        public User (String name, String contact)
        {
            this.Name = name;
            this.Contact = contact;
        }
    }
}