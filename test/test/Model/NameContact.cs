using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class Contact: IEquatable<Contact>, IComparable<Contact>
    {
        

        private string nickname = "tets_nickname";
        private string address = "Grodno";
        private string home = "12345678";
        private string birthdayYear = "1982";
        private string birthdayDay = "8";
        private string birthdayMonth = "November";

        public Contact(string firstname)
        {
          Firstname = firstname;
        }

        public Contact(string firstname, string middlename, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;
           Middlename = middlename;
        }

        public Contact(string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;            
        }
        public bool Equals(Contact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Lastname == other.Lastname&&Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public int CompareTo(Contact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Firstname.CompareTo(other.Firstname);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",Firstname,Lastname);
        }

        public string Firstname { get; set; }
       
        public string Middlename { get; set; }


        public string Lastname { get; set; }
        public string Id { get; set; }
       
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string BirthdayYear
        {
            get
            {
                return birthdayYear;
            }
            set
            {
                birthdayYear = value;
            }
        }

        public string BirthdayDay
        {
            get
            {
                return birthdayDay;
            }
            set
            {
                birthdayDay = value;
            }
        }

        public string BirthdayMonth
        {
            get
            {
                return birthdayMonth;
            }
            set
            {
                birthdayMonth = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }
    }
}
