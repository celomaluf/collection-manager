using System;
using CollectionManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Models.entity.common
{
    public class Collection
    {
        public int CdCollection
        {
            get;
            set;
        }

        public Boolean Available
        {
            get;
            set;
        }

        [Required]
        public String Type {
            get;
            set;
        }

        [Required]
        public String Description{
            get;
            set;
        }

        [Required]
        public String Location {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }
       
    }
}
