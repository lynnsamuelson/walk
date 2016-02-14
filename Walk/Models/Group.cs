using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Walk.Models
{
    public class Group 
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime Updated { get; set; }
        public List<Member> Members { get; set; }
    }
}