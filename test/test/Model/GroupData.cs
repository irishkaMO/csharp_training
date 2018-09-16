﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table (Name= "group_list")]
    public class GroupData:IEquatable<GroupData>, IComparable<GroupData>
    {
       
        public GroupData(string name)
        {
           Name = name;
        }
        public GroupData()
        {
            
        }

        public GroupData(string name, string header, string footer)
        {
          Name = name;
          Header = header;
          Footer = footer;
        }
         
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name +"\nheader =" + Header + "\nfooter=" + Footer;
        }
        [Column(Name= "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name ="group_id"),PrimaryKey,Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
                return (from g in db.Groups select g).ToList();
        }
        public List<ContactData> GetContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contact
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }
}
