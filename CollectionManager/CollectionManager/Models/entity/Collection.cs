using System;
using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Models.entity
{
    public class Collection
    {
        public Collection()
        {
            User = new User();
        }

        [Required]
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

        public void SetAvailability()
        {
            Available = !String.IsNullOrEmpty(User.Name) && !String.IsNullOrEmpty(User.Contact)
                                ? false : true;
            //Available = User != null && User.Name.Length > 0
            //                    ? false : true;
        }
    }
}
