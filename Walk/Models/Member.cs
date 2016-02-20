using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Member
    {
        public virtual ApplicationUser RealUser { get; set; }
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Family Family { get; set; }
        public DateTime Updated { get; set; }
        //public virtual List<Activities> Activities {get; set;}
        public virtual Group Group { get; set; }

    }
}