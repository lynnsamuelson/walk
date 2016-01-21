using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public object Family { get; set; }
        public DateTime Updated { get; set; }
        public List<Activities> Activities {get; set;}
    }
}