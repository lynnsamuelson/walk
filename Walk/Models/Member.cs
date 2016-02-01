using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Member
    {
        public virtual ApplicationUser RealUser { get; set; }
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Family Family { get; set; }
        public DateTime Updated { get; set; }
        public List<Activities> Activities {get; set;}
        public virtual Group Group { get; set; }

    }
}