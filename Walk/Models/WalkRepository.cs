using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Walk.Models
{
    public class WalkRepository
    {
        private WalkContext _context;
        public WalkContext Context { get { return _context; } }

        public WalkRepository()
        {
            _context = new WalkContext();
        }

        public WalkRepository(WalkContext a_context)
        {
            _context = a_context;
        }

        public List<Group> GetAllGroups()
        {
            var query = from Group in _context.Group select Group;
            return query.ToList();
        }

        public List<Family> GetAllFamilies()
        {
            var query = from Families in _context.Families select Families;
            return query.ToList();
        }

        public List<Member> GetAllMembers()
        {
            var query = from Members in _context.Members select Members;
            return query.ToList();
        }

        public List<Activities> GetAllActivities()
        {
            var query = from Activities in _context.Activities select Activities;
            return query.ToList();
        }

        public List<Member> GetAllFamilyMembers( Member member)
        {
            
                var query = from u in _context.Members where u.Family == member.Family select u;
                return query.ToList();
        }

        public Member GetMemberById(Member member)
        {
            //string stringMemberId = member.MemberId.ToString();
            var query = from u in _context.Members where u.MemberId == member.MemberId select u;
            return query.SingleOrDefault();
        }

        public List<Member> GetAllGroupMembers(Group testGroup)
        {
            var query = from u in _context.Members where u.Group.GroupId == testGroup.GroupId select u;
            return query.ToList();
        }
    }
    }
