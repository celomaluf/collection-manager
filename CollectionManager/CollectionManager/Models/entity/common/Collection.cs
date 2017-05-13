using System;
using CollectionManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Models.entity.common
{
    public abstract class Collection
    {
        [Required]
        protected String Description{ get; set; }

        [Required]
        protected String Location { get; set; }

        protected User User { get; set; }

        protected Boolean IsBorrowed ()
        {
            if ( this.User == null)
            {
                return false;
            }
            return true;
        }
        protected abstract String Type { get; }
    }
}
