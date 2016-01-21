using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public object Group { get; set; }
        public DateTime Updated { get; set; }
        public List<Member> Members { get; set; }
    }

    
}