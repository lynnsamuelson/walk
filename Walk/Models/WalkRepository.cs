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

        public List<Activities> GetMembersActivities(Member member)
        {
            if (member != null)
            {
                var person = GetMemberById(member);
                var ActivityQuery = from activity in _context.Activities where activity.Participant.MemberId == person.MemberId select activity;
                var memberActivities = ActivityQuery.ToList();
                return memberActivities;
            }
            else
            {
                return new List<Activities> { new Activities() { ActivityName = "Please Add and Activity" } };
            }
        }

        public List<Activities> GetGroupActivities(Group groupToTest)
        {
            List<Activities> allActivities = new List<Activities>
            {

            };
            if (groupToTest != null)
            {
                var thisGroup = GetAllGroupMembers(groupToTest);
                foreach (Member person in thisGroup)
                {
                    var personActivities = GetMembersActivities(person);
                    allActivities.AddRange(personActivities);
                }
            }
            return allActivities;

        }

        public bool CreateGroup(Member member1, string groupName)
        {
            Group a_group = new Group { GroupName = groupName, Members = new List<Member> {  member1 }, Updated = DateTime.Now };
            bool is_added = true;
            try
            {
                Group added_group = _context.Group.Add(a_group);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public bool CreateMember(string firstName, string lastName, Family family1, Group group1)
        {
            Member a_member = new Member { FirstName = firstName, LastName = lastName, Family = family1, Group = group1, Updated = DateTime.Now };
            bool is_added = true;
            try
            {
                Member added_member = _context.Members.Add(a_member);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public bool CreateFamily(string familyName)
        {
            Family a_family = new Family { FamilyName = familyName, Updated = DateTime.Now };
            bool is_added = true;
            try
            {
                Family added_famiily = _context.Families.Add(a_family);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }

        public bool CreateActivity(string activityName, double distance, Member member1)
        {
            Activities an_activity = new Activities { ActivityName = activityName, Distance = distance, Participant = member1, Date = DateTime.Now };
            bool is_added = true;
            try
            {
                Activities added_activities = _context.Activities.Add(an_activity);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
    }
