using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class Family
    {
        [Key]
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public DateTime Updated { get; set; }
    }

    
}