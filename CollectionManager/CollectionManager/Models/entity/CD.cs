using CollectionManager.Models.entity.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionManager.Models
{
    public class CD : Collection
    {
        protected override string Type => "CD";

        public CD(String description, String location, User user)
        {
            this.Description = description;
            this.Location = location;
            this.User = user;
        }
    }
}