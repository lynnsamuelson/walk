using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Walk.Models
{
    public class WalkContext : ApplicationDbContext
    { 
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}