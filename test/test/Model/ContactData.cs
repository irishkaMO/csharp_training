using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        

        private string nickname = "tets_nickname";
        private string birthdayYear = "1982";
        private string birthdayDay = "8";
        private string birthdayMonth = "November";
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname)
        {
          Firstname = firstname;
        }

        public ContactData(string firstname, string middlename, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;
           Middlename = middlename;
        }

        public ContactData(string firstname, string lastname)
        {
           Firstname = firstname;
           Lastname = lastname;            
        }
        public bool Equals(ContactData other)
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

        public int CompareTo(ContactData other)
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

        public string Address { get; set; }

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
        public string HomePhone { get; set; }
        public string HomePhoneDop { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)+ CleanUpPhone(HomePhoneDop)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null||phone=="")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";



           
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpPhone(Email) + CleanUpPhone(Email2) + CleanUpPhone(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "").Replace("-", "") + "\r\n";




        }
    }
}
